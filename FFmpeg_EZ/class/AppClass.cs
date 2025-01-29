using FFmpeg_EZ.subform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ 
{
    public static partial class App
    {
        ////////    Class   /////////
        public class Animetible
        {
            public double keyFrame = 0;
            public Size startSize = Size.Empty;
            public Point startPoint = Point.Empty;
            public dynamic control = null;

            public bool TriggerOpen = false;
            public bool TriggerClose = false;
            public string triggerTag = null;


            /// <summary>
            /// reset Animation Var
            /// </summary>
            public void AnimReset()
            {
                this.TriggerOpen = false;
                this.TriggerClose = false;
                this.triggerTag = null;
                this.keyFrame = 0;
            }
        }


        public class InputFile //store options declar on `INPUTS` group
        {
            public string name;
            public string ID = null;
            public string path = null;


            public TimeSessionSelectForm.Selection trimming = null;
            public double offset = 0;
            public FileInfo info = null;
            public bool hidden = false; // for file that import indirectly (from text file)


            public void UpdateFinalLength()
            {
                if (this.info == null)
                    throw new Exception("file info is null cannot calculate file length");
                if (this.trimming == null)
                {
                    this.info.durationMS_final = this.info.durationMS;
                    return;
                }


                if (this.trimming.fromDuration)
                {
                    this.info.durationMS_final = $"{trimming.from.hr}:{trimming.from.min}:{trimming.from.sec}.{trimming.from.ms}".ToTimeMS();
                    return;
                }

                this.info.durationMS_final = this.info.durationMS;
                if (this.trimming.selectedAll) return;

                if (!this.trimming.toEnd)
                    this.info.durationMS_final -= (this.info.durationMS - this.trimming.to.ToString().ToTimeMS());

                if (!this.trimming.fromStart)
                    this.info.durationMS_final -= this.trimming.from.ToString().ToTimeMS();
            }

            
        }

        public class OutputFile
        {
            public string name;
            public string ID = null;
            public string path = null;
            public string directory = null;

            // whether this file needed to cache some where when rendering
            // for some situation that Input and Output file are the same
            public bool requiredCaching = false;
            public ProcessOptions processOption = null;
            public TimeSessionSelectForm.Selection trimming = null;
            public short offset = 0;
            public List<string> childInputFilesID = new List<string>();
        }




        public class ProcessOptions //store options declar on `PROCESS` group
        {
            public P_OptionQuality quality = null;
            public V_scaleSelectForm.Selection v_scale = null;
            public V_cropSelectForm.Selection v_crop = null;
            public SimStrmMappingForm.Selection strmMapping = null;
            public string forceOutputFormat = null;
            public Metadata metadata = null;
            public bool concatMode = false;
        }

        public class RenderOptions
        {
            public uint renderStartMS = 0;
            public short step = -1;
            public short step_total = -1;
            public bool renderModeCopy = false;
            public bool renderModeRepeat = false;
            /// <summary>
            /// Note: only contains file's ID and the first ID is always the next file to repeat
            /// </summary>
            public List<string> fileToRepeat = null;
            public bool requiredMutiStep = false;

            public void Reset()
            {
                this.renderStartMS = 0;
                this.step = -1;
                this.step_total = -1;
                this.renderModeCopy = false;
                this.renderModeRepeat = false;
                this.fileToRepeat = null;
                this.requiredMutiStep = false;
            }
        }

        public class P_OptionQuality
        {
            // "Quality" is bitrate as Kbps (`-b` option)
            public bool enable = false;

            public int vQuality = -1; // -1 means not set
            public int aQuality = -1;
        }


        public class Preferences
        { // default pref...
            public bool hideCMD = false;
            public bool hideFFmpegOutput = false;
            public bool saveSettingToFile = true;
            public string js_controllerP = @"./_js/.controller";
            public string js_folderP = @"./_js/";
            public string bin_folderP = @"./_bin/";
            public string defOpenInputP = null;
            public string defOpenOutputP = null;
            public short internalReadDelay = 1000;

            public bool FF_autoReplaceWhenAsk = true;
            public string FF_inputArg = null;
            public string FF_processArg = null;
            public string FF_hardwareAccelDecodeCodec = null;

            public string lastSelInputExt = null;
        }


        public class Metadata
        {
            public string title = null;
            public string author = null;
            public string composter = null;
            public string description = null;
            public string creation_time = null;
            public string copyright = null;
            public string comment = null;
            public string grouping = null;
            public string album = null;
            public string album_artist = null;
            public string genre = null;

            public string GetValue(string key)
            {
                switch (key)
                {
                    case "title": return this.title;
                    case "author": return this.author;
                    case "composter": return this.composter;
                    case "description": return this.description;
                    case "creation_time": return this.creation_time;
                    case "copyright": return this.copyright;
                    case "comment": return this.comment;
                    case "grouping": return this.grouping;
                    case "album": return this.album;
                    case "album_artist": return this.album_artist;
                    case "genre": return this.genre;
                    default: return null;
                }
            }

            public void SetValue(string key, string value)
            {
                switch (key)
                {
                    case "title": this.title = value; break;
                    case "author": this.author = value; break;
                    case "composter": this.composter = value; break;
                    case "description": this.description = value; break;
                    case "creation_time": this.creation_time = value; break;
                    case "copyright": this.copyright = value; break;
                    case "comment": this.comment = value; break;
                    case "grouping": this.grouping = value; break;
                    case "album": this.album = value; break;
                    case "album_artist": this.album_artist = value; break;
                    case "genre": this.genre = value; break;
                }
            }

            public bool isAllNull()
            {
                return (
                    this.title ?? this.author ??
                    this.composter ?? this.description ??
                    this.creation_time ?? this.copyright ??
                    this.comment ?? this.grouping ??
                    this.album ?? this.album_artist ??
                    this.genre ?? "Heyy_its_All_NULLL!!!"
                ) == "Heyy_its_All_NULLL!!!" ? true : false;
            }
        }



        public class FileInfo
        {
            public string name;
            public int sizekB;

            public bool hasVideoStream;
            public bool hasAudioStream;
            public bool hasSubtitleStream;
            public byte v_streamCount = 0;
            public byte a_streamCount = 0;
            public byte s_streamCount = 0;
            public byte other_streamCount;

            public List<string> types = new List<string>();
            public List<string> metadata = new List<string>();
            public string duration;
            public uint durationMS; // original duration
            public uint durationMS_final; //duration after some change made (Ex: trimming)
            public int bitrateKbps;
            public List<StreamInfo> streams = null;

            public class _request
            {
                public static bool showFileInfoWhenReady = false;
            }

            public class StreamInfo
            {
                /// <summary>
                /// can be 'video', 'audio', 'subtitle'
                /// </summary>
                public string streamType;
                public int bitrateKbps;
                public float fps_Hz; // for video and audio
                public string codec = null;
                public string _codec = null; // codec complex name 
                public string channelType; // for audio
                public ushort[] dimension = new ushort[2]; // for video
                public float[] ratio = new float[2]; // for video
                public string lang; // for subtitle
                public string error = null;
                
                public bool available() => error == null;
            }






            public override string ToString()
            {
                string res = "";
                bool hasOtherStream = false;

                res += $"Infomation for \"{this.name}\":\n             --------------------------------    \n";
                res += $"Duration:     {this.duration}  ({this.durationMS}ms)\n";
                res += $"Bitrate:         {this.bitrateKbps} Kbps\n";
                if (this.types.Count != 0)
                    res += $"Alias:            {string.Join(", ", this.types)}\n";
                res += $"Metadata:\n     {string.Join("\n ", this.metadata)}\n";

                if (!(this.hasVideoStream || this.hasAudioStream || this.hasSubtitleStream)) return res;

                res += $"Streams: (";
                if (this.hasVideoStream)
                {
                    res += $"video x{this.v_streamCount}";
                    hasOtherStream = true;
                }
                if (this.hasAudioStream)
                {
                    res += (hasOtherStream ? " | " : "") + $"audio x{this.a_streamCount}";
                    hasOtherStream = true;
                }
                if (this.hasSubtitleStream)
                {
                    res += (hasOtherStream ? " | " : "") + $"subtitleTrack x{this.s_streamCount}" + ((this.other_streamCount != 0) ? " | " : "");
                    hasOtherStream = true;
                }
                if (this.other_streamCount != 0)
                    res += (hasOtherStream ? " | " : "") + $"other x{other_streamCount}";
                res += ")\n";

                for (byte i = 0; i < this.streams.Count; i++)
                {
                    StreamInfo strmInfo = this.streams[i];

                    res += $"     Stream{i + 1}:  ({strmInfo.streamType})" + (strmInfo.available()? "\n": " Unavailable\n");
                    if(!strmInfo.available())
                        res += $"          Error:           {strmInfo.error}\n";
                    if (strmInfo.bitrateKbps != 0)
                        res += $"          bitrate:           {strmInfo.bitrateKbps} Kbps\n";
                    if (strmInfo.codec != null)
                        res += $"          codec:             {strmInfo.codec}  ({strmInfo._codec})\n";
                    switch (strmInfo.streamType)
                    {
                        case "video":
                            res += $"          fps:                 {strmInfo.fps_Hz}\n";
                            res += $"          dimension:     {string.Join("x", strmInfo.dimension)}\n";
                            res += $"          ratio:              {string.Join(":", strmInfo.ratio)}\n";
                            break;
                        case "audio":
                            if (strmInfo.fps_Hz != 0)
                                res += $"          sample rate:    {strmInfo.fps_Hz} Hz\n";
                            if (strmInfo.channelType != null)
                                res += $"          channels:        {strmInfo.channelType}\n";
                            break;
                        case "subtitle":
                            if (strmInfo.lang != null)
                                res += $"          lang:               {strmInfo.lang}\n";
                            break;
                    }
                }

                return res;
            }

            /// <summary>
            /// get FFmpeg prefered stream
            /// </summary>
            /// <param name="streamType"></param>
            /// <returns>prefered streamInfo or `null`</returns>
            public StreamInfo getBestStream(string streamType)
            {
                ushort[] bestDimension = null;
                byte bestAChannelsQual = 0;
                short bestStreamIndex = -1;

                for (byte i = 0; i < this.streams.Count; i++)
                {
                    StreamInfo stream = this.streams[i];
                    if (stream.streamType != streamType) continue;
                    if (stream.error != null) continue;
                    if (stream.streamType == "video")
                    {
                        if (bestDimension == null)
                        {
                            bestDimension = stream.dimension;
                            bestStreamIndex = i;
                            continue;
                        }
                        int bestRes = bestDimension[0] * bestDimension[1];
                        int strmRes = stream.dimension[0] * stream.dimension[1];
                        if (bestRes < strmRes)
                        {
                            bestDimension = stream.dimension;
                            bestStreamIndex = i;
                        }
                    }
                    else if (stream.streamType == "audio")
                    {
                        switch (stream.channelType)
                        {
                            case "mono":
                                if (bestAChannelsQual < 1)
                                {
                                    bestAChannelsQual = 1;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "stereo":
                                if (bestAChannelsQual < 2)
                                {
                                    bestAChannelsQual = 2;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "2.1":
                                if (bestAChannelsQual < 3)
                                {
                                    bestAChannelsQual = 3;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "3.1":
                                if (bestAChannelsQual < 4)
                                {
                                    bestAChannelsQual = 4;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "4.1":
                                if (bestAChannelsQual < 5)
                                {
                                    bestAChannelsQual = 5;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "5.1":
                                if (bestAChannelsQual < 6)
                                {
                                    bestAChannelsQual = 6;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "6.1":
                                if (bestAChannelsQual < 7)
                                {
                                    bestAChannelsQual = 7;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "7.1":
                                if (bestAChannelsQual < 8)
                                {
                                    bestAChannelsQual = 8;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "7.1.2":
                                if (bestAChannelsQual < 9)
                                {
                                    bestAChannelsQual = 9;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "7.2":
                                if (bestAChannelsQual < 10)
                                {
                                    bestAChannelsQual = 10;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "9.1":
                                if (bestAChannelsQual < 11)
                                {
                                    bestAChannelsQual = 11;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "9.1.2":
                                if (bestAChannelsQual < 12)
                                {
                                    bestAChannelsQual = 12;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "10.1":
                                if (bestAChannelsQual < 13)
                                {
                                    bestAChannelsQual = 13;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "12.2":
                                if (bestAChannelsQual < 14)
                                {
                                    bestAChannelsQual = 14;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "13.1":
                                if (bestAChannelsQual < 15)
                                {
                                    bestAChannelsQual = 15;
                                    bestStreamIndex = i;
                                }
                                break;
                            case "22.2":
                                if (bestAChannelsQual < 16)
                                {
                                    bestAChannelsQual = 16;
                                    bestStreamIndex = i;
                                }
                                break;
                        }
                    }
                }

                if (bestStreamIndex == -1) return null;
                return this.streams[bestStreamIndex];
            }


            /// <summary>
            /// get the best Video stream Dimension for this file
            /// FFmpeg will auto select only the highest resolution available for the file
            /// if none return `null`
            /// </summary>
            /// <returns>null or best Dimension for this file</returns>
            /// <exception cref="Exception"></exception>
            public ushort[] getDimension()
            {
                ushort[] bestDimension = null;

                for (byte i = 0; i < this.streams.Count; i++)
                {
                    StreamInfo stream = this.streams[i];
                    if (stream.streamType != "video" && bestDimension == null && i == this.streams.Count - 1)
                        return null; // if no video stream found
                    if (stream.streamType != "video") continue;

                    if (bestDimension == null)
                    {
                        bestDimension = stream.dimension;
                        continue;
                    }
                    int bestRes = bestDimension[0] * bestDimension[1];
                    int strmRes = stream.dimension[0] * stream.dimension[1];
                    if (bestRes < strmRes) bestDimension = stream.dimension;
                }
                return bestDimension;
            }






            /// <summary>
            /// request file infomation from `terminal.js`
            /// after request has been fulfill `.cache02` would be overwritten
            /// to retrieve those infomation, use FileInfo.parse() 
            /// </summary>
            /// <param name="filePath"></param>
            public static void request(string filePath)
            {
                if ((MissingNodeJS && !usingPATHExe && MissingLocalDep) || MissingFFprobe) return;
                if (MissingLocalDep)
                    System.IO.File.WriteAllText(App.prefs.js_folderP + ".cache02", "");
                cmdRunning = true;
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "CMD.exe";
                startInfo.Arguments = $"/C cd {prefs.js_folderP} && node.exe terminal.js \"./.cache02\" " + (usingPATHExe ? "" : $".{prefs.bin_folderP}") + $"ffprobe.exe -i \"{filePath}\" -hide_banner";

                try
                {
                    process.StartInfo = startInfo;
                    fileSystemWatcherTriggerCount = 0;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                }
                catch
                {
                    MessageBox.Show(
                        "Ops. an error while processing Input file\n\nsome features may not function properly",
                        "Unexpected Error"
                    );
                    return;
                }

            }

            /// <summary>
            /// get file name from FFprobe info
            /// </summary>
            /// <param name="stringInfo"></param>
            /// <returns></returns>
            public static string getName(string stringInfo)
            {
                StringSplitOptions OptNone = StringSplitOptions.None;
                string[] s = stringInfo.Split(new string[] { "Duration:" }, OptNone);

                string nearName = s[0]
                    .Split(new string[] { ", from " }, OptNone)[1];
                return nearName
                    .Substring(nearName.LastIndexOf("\\") + 1)
                    .Split(':')[0] // "'d.mp4'"
                    .Replace("'", ""); // "d.mp4"
            }


            public static FileInfo parse(string stringInfo, FileInfo f = null)
            {
                StringSplitOptions OptNone = StringSplitOptions.None;

                if (f == null) f = new FileInfo();

                //string res = "";
                List<string> resS = new List<string>();
                string[] s = stringInfo.Split(new string[] { "Duration:" }, OptNone);
                string[] sST = s[1].Split(new string[] { "Stream" }, OptNone);
                if (sST[0].Contains("Chapters:"))
                {
                    sST[0] = sST[0].Split(new string[] { "Chapters:" }, OptNone)[0]; // remove `Chapters` section
                }


                string typeStr = s[0] // aka alias
                    .Split(new string[] { ", from " }, OptNone)[0];
                if (typeStr.Contains("from"))
                    f.types = typeStr
                        .Replace(" ", "") //clean up white-space
                        .Split(',') //split "Input #0, mov,mp4,m4a,3gp,3g2,mj2"(example) with ','
                        .Skip(1) //skip "Input #0"
                        .ToList(); //convert to List
                f.name = s[0]
                    .Split(new string[] { ", from " }, OptNone)[1]; // "'d.mp4':Metadata: major_brand: isom..."
                f.name = f.name
                    .Substring(f.name.LastIndexOf("\\") + 1)
                    .Split(':')[0] // "'d.mp4'"
                    .Replace("'", ""); // "d.mp4"
                if (s[0].Contains(":\r\n  Metadata:"))
                    f.metadata = s[0]
                        .Split(new string[] { "Metadata:" }, OptNone)[1]
                        .Trim()
                        .Split('\n')
                        .ToList();
                f.duration = sST[0].Split(',')[0].Trim();
                f.durationMS = f.duration.ToTimeMS();
                f.bitrateKbps = Convert.ToInt32(Tools.extractNum(sST[0].Split(',').Length > 2? sST[0].Split(',')[2]: sST[0].Split(',')[1])); // sST[0] = " 00:02:41.87, start: 0.000000, bitrate: 1602 kb/s" (example)
                
                /* f.v_streamCount = Convert.ToByte(
                     stringInfo.Split(new string[] { "Video:" }, OptNone).Length - 1 //count occurrences of string "VideoHandler"
                 );
                 f.a_streamCount = Convert.ToByte(
                     stringInfo.Split(new string[] { "Audio:" }, OptNone).Length - 1
                 );
                 f.s_streamCount = Convert.ToByte(
                     stringInfo.Split(new string[] { "Data:" }, OptNone).Length - 1
                 );*/

                /*
                  strm = 
                  "#0:0[0x1](und): Video: h264 (Main) (avc1 / 0x31637661), yuv420p(tv, bt709, progressive), 1920x1080 [SAR 1:1 DAR 16:9], 1466 kb/s, 23.98 fps, 23.98 tbr, 24k tbn (default)
                      Metadata:
                      handler_name    : VideoHandler
                      vendor_id       : [0][0][0][0]"
                 */
                f.streams = new List<StreamInfo>();
                foreach (string strm in sST.Skip(1))
                {
                    string info = null;
                    //string metadat = null;  stream's metadata but no use for now
                    if (strm.Contains("Metadata:"))
                    {
                        info = strm.Split(new string[] { "Metadata:" }, OptNone)[0];
                        //metadat = strm.Split(new string[] { "Metadata:" }, OptNone)?[1];
                    }
                    else info = strm;
                    StreamInfo streamInfo = new StreamInfo();

                    if (info.Contains("Video:"))
                    {
                        f.v_streamCount++;
                        streamInfo.streamType = "video";
                        string[] infoArr = info.Split(',');
                        foreach (string inf in infoArr)
                        {
                            if (inf.Contains("Video:") && inf.Contains("/"))
                            {
                                streamInfo.codec = inf.Split(':') // [ " #0:0[0x1](und)", " Video", " h264 (Main) (avc1 / 0x31637661)" ]
                                    .Last() // " h264 (Main) (avc1 / 0x31637661)"
                                    .Split('(') // [ " h264 ", "Main) ", "avc1 / 0x31637661)" ]
                                    [0].Trim(); // "h264"
                                streamInfo._codec = inf.Split(':') // [ " #0:0[0x1](und)", " Video", " h264 (Main) (avc1 / 0x31637661)" ]
                                    .Last() // " h264 (Main) (avc1 / 0x31637661)"
                                    .Split('(') // [ " h264 ", "Main) ", "avc1 / 0x31637661)" ]
                                    .Last() // "avc1 / 0x31637661)"
                                    .Split('/')[0].Trim(); // "avc1"
                            }
                            else if (Regex.IsMatch(inf, @"[0-9]x[0-9]") || inf.Contains("SAR"))
                            {
                                if (Regex.IsMatch(inf, @"[0-9]x[0-9]"))
                                    streamInfo.dimension = inf.Trim()
                                        .Split(' ')[0]
                                        .Split('x')
                                        .Select(S => Convert.ToUInt16(S))
                                        .ToArray();

                                if (inf.Contains('['))
                                    streamInfo.dimension = inf.Split('[')[0] // " 1280x720 "
                                    .Trim() // "1280x720"
                                    .Split('x') // [ "1280", "720" ]  as (string[])
                                    .Select(S => Convert.ToUInt16(S)) // [ 1280, 720 ]  as (IEnumerable<ushort>)
                                    .ToArray(); // [ 1280, 720 ]  as (ushort[])

                                if (inf.Contains("DAR ")) streamInfo.ratio = inf.Split(new string[] { "DAR " }, OptNone)
                                    .Last() // "16:9]"
                                    .Replace("]", "")
                                    .Split(':') // [ "16", "9" ]  as (string[])
                                    .Select(S => Convert.ToSingle(S)) // [ "16", "9" ]  as (IEnumerable<ushort>)
                                    .ToArray(); // [ 16.0, 9.0 ]  as (float[])
                            }
                            else if (inf.Contains("kb/s")) streamInfo.bitrateKbps = Convert.ToInt32(
                                    inf.Trim() // "1466 kb/s"
                                        .Split(' ')[0]); // 1466
                            else if (inf.Contains("fps")) streamInfo.fps_Hz = (float)Math.Round(
                                Convert.ToDouble(
                                    inf.Trim() // "23.98 fps"
                                        .Split(' ')[0]), // 23.98
                                2,
                                MidpointRounding.AwayFromZero
                            );
                        }
                    }
                    else if (info.Contains("Audio:"))
                    {
                        f.a_streamCount++;
                        streamInfo.streamType = "audio";
                        string[] infoArr = info.Split(',');
                        //foreach (string inf in infoArr)

                        for (byte i = 0; i < infoArr.Length; i++)
                        {
                            string inf = infoArr[i];
                            if (inf.Contains("Audio:") && inf.Contains("/"))
                            {
                                streamInfo.codec = inf.Split(':') // [ " #0:0[0x1](und)", " Video", " h264 (Main) (avc1 / 0x31637661)" ]
                                    .Last() // " h264 (Main) (avc1 / 0x31637661)"
                                    .Split('(') // [ " h264 ", "Main) ", "avc1 / 0x31637661)" ]
                                    [0].Trim(); // "h264"
                                streamInfo._codec = inf.Split(':') // [ " #0:0[0x1](und)", " Video", " h264 (Main) (avc1 / 0x31637661)" ]
                                    .Last() // " h264 (Main) (avc1 / 0x31637661)"
                                    .Split('(') // [ " h264 ", "Main) ", "avc1 / 0x31637661)" ]
                                    .Last() // "avc1 / 0x31637661)"
                                    .Split('/')[0].Trim(); // "avc1"

                            }
                            else if (inf.Contains("kb/s")) streamInfo.bitrateKbps = Convert.ToInt32(
                                    inf.Trim() // "146 kb/s (default)"
                                        .Split(' ')[0]); // 146
                            else if (inf.Contains("Hz")) streamInfo.fps_Hz = Convert.ToSingle(
                                    inf.Trim() // "48000 Hz"
                                        .Split(' ')[0]); // 48000.0
                            if (i == 2) streamInfo.channelType = inf.Trim();
                        }
                    }
                    else if (info.Contains("Data:") || info.Contains("Subtitle:"))
                    {
                        f.s_streamCount++;
                        streamInfo.streamType = "subtitle";
                        if (info.Contains("Data:") && info.Contains("/"))
                        {
                            streamInfo.codec = info.Split(':') // [ " #0:0[0x1](und)", " Video", " h264 (Main) (avc1 / 0x31637661)" ]
                                    .Last() // " h264 (Main) (avc1 / 0x31637661)"
                                    .Split('(') // [ " h264 ", "Main) ", "avc1 / 0x31637661)" ]
                                    [0].Trim(); // "h264"
                            streamInfo._codec = info.Split(':') // [ " #0:2[0x3](eng)", " Data", " bin_data (text / 0x74786574)" ]
                                .Last() // " bin_data (text / 0x74786574)"
                                .Split('(') // [ " bin_data ", "text / 0x74786574)" ]
                                .Last() // "text / 0x74786574)"
                                .Split('/')[0].Trim(); // "text"
                        }
                        if (info.Contains("):")) streamInfo.lang = info
                                .Split(new string[] { "):" }, OptNone)[0]
                                .Split('(')
                                .Last()
                                .Replace(")", "");
                    }
                    else if (info.Contains("Attachment:"))
                    {
                        f.other_streamCount++;
                        streamInfo.streamType = "attachment";
                    }
                    else
                    {
                        f.other_streamCount++;
                        streamInfo.streamType = "unknown";
                    }

                    // each stream
                    f.streams.Add(streamInfo);
                }


                // catch Errors
                {
                    string footer = sST.Last();
                    if(footer.Contains("Unsupported codec with id")){
                        string[] unsupCodecs = footer.Split(new string[] { "Unsupported codec with id" }, OptNone).Skip(1).ToArray();

                        foreach(string unsupCodec in unsupCodecs){
                            if(!unsupCodec.Contains("for input stream")) continue;

                            int invalidStreamIndex = Convert.ToInt32(unsupCodec.Split(' ').Last());
                            if(invalidStreamIndex >= f.streams.Count()) continue;

                            f.streams[invalidStreamIndex].error = "Unsupported codec with id" + unsupCodec;
                        }
                    }
                }


                f.hasVideoStream = f.v_streamCount > 0;
                f.hasAudioStream = f.a_streamCount > 0;
                f.hasSubtitleStream = f.s_streamCount > 0;
                //resS.AddRange(s);
                //resS.AddRange(sST);
                //foreach (string s2 in resS) res += $">\n{s2}\n\n";
                //MessageBox.Show(f.ToString());
                return f;
            }
        }

        
        
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode l = new ListNode();

    }
}
