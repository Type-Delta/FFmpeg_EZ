using FFmpeg_EZ.subform;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FFmpeg_EZ.App;

namespace FFmpeg_EZ
{
    public static partial class App
    {
        ////////    Var     /////////
        public static List<InputFile> Sim_inputFiles = new List<InputFile>();
        public static OutputFile Sim_outputFile = null;
        //public static ProcessOptions Sim_processOptions = new ProcessOptions();
        public static ProcessOptions Sim_processOpt_temp = new ProcessOptions();


        public static List<string> IDlist = new List<string>();
        //render
        /*public static uint renderStartMS = 0;
        public static bool renderModeCopy = false;*/
        public static RenderOptions Sim_renderOpt = new RenderOptions();


        // debug
        public static string stdOut = null;
        public static string lastStrStdout = "";
        public static string stdError = null;
        public static long lastStdError = DateTime.Now.Ticks;
        public static bool makeMenuPanelVisible = false;
        public static bool cmdRunning = false;
        public static bool cmdKill = false;
        public static bool usingPATHExe = false;
        public static int fileSystemWatcherTriggerCount = 0;

        // system
        public static Preferences prefs = null;  //prefs & config
        public static string lastChooseFileExt = null;
        public static Tools.Remote addFileRemote = null;


        // systemStats
        public static bool MissingLocalDep = false;
        public static bool MissingConfig = false;
        public static bool MissingFFmpeg = false;
        public static bool MissingMpv = false;
        public static bool MissingFFprobe = false;
        public static bool MissingNodeJS = false;
        public static bool MissingJS = false;
        public static bool appClosing = false;
        public const string Version = @"beta 1.2.2P";


        // const & readonly
        public readonly static Preferences defaultConfig = new Preferences();
        public const string configPath = @"./prefs.json";
        public readonly static string[] FFmpegDocs = new string[4] {
            @"https://www.ffmpeg.org/documentation.html",
            @"https://ostechnix.com/20-ffmpeg-commands-beginners/",
            @"https://trac.ffmpeg.org/wiki/HWAccelIntro",
            @"https://askubuntu.com/questions/1107782/how-to-use-gpu-acceleration-in-ffmpeg-with-amd-radeon"
        };
        public readonly static List<string> FFmpegRenderEndKeyWords = new List<string>()
        {
            "] Qavg:",
            "muxing overhead",
            "global headers"
        };
        public readonly static List<string> FFmpegErrorKeyWords = new List<string>()
        {
            "Invalid",
            "Unable",
            "Unknown",
            "Error",
            "Option not found",
            "Unrecognized",
            "cannot be used together",
            "not support",
            "incorrect parameter",
            "Conversion failed",
            "must be specified",
            "No such file or directory"
        };
        public const string inputFileFilter = "MP4 files (*.mp4)|*.mp4|MP3 files (*.mp3)|*.mp3|MKV files (*.mkv)|*.mkv|WAV files (*.wav)|*.wav|WebMedia files (*.webm)|*.webm|Quick time format files (*.MOV)|*.mov|Advanced audio coding files (*.aac)|*.aac|Ogg Vorbis files|*.ogg|disk format video file (*.ts)|*.ts|Moving Picture experts Group (*.mpg)|*.mpg|raw bitstream format (*.h264)|*.h264|raw bitstream format (*.h265)|*.h265|Flash Video (*.flv)|*.flv|Plain Text (*.txt)|*.txt|All files, use only what you know works|*.*";
        public const string outputFileFilter = "MP4 files (*.mp4)|*.mp4|MP3 files (*.mp3)|*.mp3|MKV files (*.mkv)|*.mkv|WAV files (*.wav)|*.wav|WebMedia files (*.webm)|*.webm|Quick time format files (*.MOV)|*.mov|Advanced audio coding files (*.aac)|*.aac|Ogg Vorbis files|*.ogg|disk format video file (*.ts)|*.ts|Moving Picture experts Group (*.mpg)|*.mpg|raw bitstream format (*.h264)|*.h264|raw bitstream format (*.h265)|*.h265|Flash Video (*.flv)|*.flv|All files, use only what you know works|*.*";
        public const string terminal_js = @"const { spawn } = require('child_process');
const { writeFileSync, readFileSync, existsSync } = require('fs');


// command: node terminal.js <outputfilename> <commandName> <args>
const nodeArgs = process.argv.slice(2);
const CMDargs = nodeArgs.slice(2);
let stdout = """";
let lastCall = (new Date).getTime() - 251;
console.log(nodeArgs, CMDargs);


const child = spawn(nodeArgs[1], CMDargs);

setInterval(() => {
    try{
        if (!existsSync('./.controller')) return;

        const content = readFileSync(`./.controller`, { encoding: 'utf-8', flag: 'r' });
        if (!content) return;

        if (content == 'stop'){
            writeFileSync('./.controller', """");
           
            process.exit();
        }
    }
    catch (error){
        return;
    }
}, 500);


child.on('exit', function(code, signal){
    console.log('child process exited with ' + `code ${ code}
 and signal ${ signal}`);
    process.exit();
});

child.on('close', (code, sig) => {
   process.exit();
});


child.stdout.on('data', (data) => {
   stdout += data;
   writeData(lastCall);
    console.log(""[od]""+data);
});

child.stdout.on('error', (data) => {
    stdout += data;
    writeData(lastCall);
    console.log(""[oe]"" + data);
});

child.stderr.on('data', (data) => {
    stdout += data;
    writeData(lastCall);
    console.log(""[ED]"" + data);
});



function writeData(lastcall)
{
    if (lastcall + 250 > (new Date).getTime()) return;
    writeFileSync(nodeArgs[0], stdout);
    stdout = """";
}
";




        









        



        /// Extension Functions
        public static System.Drawing.Font changeFontSize(this System.Drawing.Font oldFont, float newSize)
        {
            if (newSize <= 0) throw new ArgumentOutOfRangeException("Internal Error: font size too small");
            return new System.Drawing.Font(
                oldFont.FontFamily,
                newSize,
                oldFont.Style,
                System.Drawing.GraphicsUnit.Point,
                ((byte)(0))
            );
        }

        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static InputFile getFileByID(this List<InputFile> files, string ID)
        {
            foreach(InputFile file in files)
            {
                if (file.ID == ID) return file;
            }
            return null;
        }

        public static InputFile getBestFile(this List<InputFile> files, string fileType)
        {
            ushort[] bestDimension = null;
            byte bestAChannelsQual = 0;
            short bestFileIndex = -1;


            for (byte i = 0; i < files.Count; i++)
            {
                InputFile file = files[i];
                if (file.info == null)
                {
                    throw new Exception("Internal Error: file info not set");
                }
                FileInfo.StreamInfo bestStrm = file.info.getBestStream(fileType);
                if (bestStrm == null) continue;

                if (bestStrm.streamType == "video")
                {
                    if (bestDimension == null)
                    {
                        bestDimension = bestStrm.dimension;
                        bestFileIndex = i;
                        continue;
                    }
                    int bestRes = bestDimension[0] * bestDimension[1];
                    int strmRes = bestStrm.dimension[0] * bestStrm.dimension[1];
                    if (bestRes < strmRes)
                    {
                        bestDimension = bestStrm.dimension;
                        bestFileIndex = i;
                    }
                }
                else if (bestStrm.streamType == "audio")
                {
                    switch (bestStrm.channelType)
                    {
                        case "mono":
                            if (bestAChannelsQual < 1)
                            {
                                bestAChannelsQual = 1;
                                bestFileIndex = i;
                            }
                            break;
                        case "stereo":
                            if (bestAChannelsQual < 2)
                            {
                                bestAChannelsQual = 2;
                                bestFileIndex = i;
                            }
                            break;
                        case "2.1":
                            if (bestAChannelsQual < 3)
                            {
                                bestAChannelsQual = 3;
                                bestFileIndex = i;
                            }
                            break;
                        case "3.1":
                            if (bestAChannelsQual < 4)
                            {
                                bestAChannelsQual = 4;
                                bestFileIndex = i;
                            }
                            break;
                        case "4.1":
                            if (bestAChannelsQual < 5)
                            {
                                bestAChannelsQual = 5;
                                bestFileIndex = i;
                            }
                            break;
                        case "5.1":
                            if (bestAChannelsQual < 6)
                            {
                                bestAChannelsQual = 6;
                                bestFileIndex = i;
                            }
                            break;
                        case "6.1":
                            if (bestAChannelsQual < 7)
                            {
                                bestAChannelsQual = 7;
                                bestFileIndex = i;
                            }
                            break;
                        case "7.1":
                            if (bestAChannelsQual < 8)
                            {
                                bestAChannelsQual = 8;
                                bestFileIndex = i;
                            }
                            break;
                        case "7.1.2":
                            if (bestAChannelsQual < 9)
                            {
                                bestAChannelsQual = 9;
                                bestFileIndex = i;
                            }
                            break;
                        case "7.2":
                            if (bestAChannelsQual < 10)
                            {
                                bestAChannelsQual = 10;
                                bestFileIndex = i;
                            }
                            break;
                        case "9.1":
                            if (bestAChannelsQual < 11)
                            {
                                bestAChannelsQual = 11;
                                bestFileIndex = i;
                            }
                            break;
                        case "9.1.2":
                            if (bestAChannelsQual < 12)
                            {
                                bestAChannelsQual = 12;
                                bestFileIndex = i;
                            }
                            break;
                        case "10.1":
                            if (bestAChannelsQual < 13)
                            {
                                bestAChannelsQual = 13;
                                bestFileIndex = i;
                            }
                            break;
                        case "12.2":
                            if (bestAChannelsQual < 14)
                            {
                                bestAChannelsQual = 14;
                                bestFileIndex = i;
                            }
                            break;
                        case "13.1":
                            if (bestAChannelsQual < 15)
                            {
                                bestAChannelsQual = 15;
                                bestFileIndex = i;
                            }
                            break;
                        case "22.2":
                            if (bestAChannelsQual < 16)
                            {
                                bestAChannelsQual = 16;
                                bestFileIndex = i;
                            }
                            break;
                    }
                }
            }


            if (bestFileIndex == -1) return null;
            return files[bestFileIndex];
        }



        





        /// PUBPLIC Functions
        public static string generateCommand(List<InputFile> inputFiles, List<OutputFile> outputFiles)
        {
            string cmd = "ffmpeg";


            // Gobal Options
            if (prefs.FF_autoReplaceWhenAsk) cmd += " -y";


            // INPUT
            foreach(InputFile file in inputFiles)
            {
                //fillter
                if (file.info == null) continue;

                // trimming
                if(file.trimming != null&&!file.trimming.selectedAll)
                {
                    if (file.trimming.fromDuration)
                        cmd += $" -t {file.trimming.from}";
                    else
                    {
                        if (!file.trimming.fromStart)
                            cmd += $" -ss {file.trimming.from}";
                        if (!file.trimming.toEnd)
                            cmd += $" -to {file.trimming.to}";
                    }
                }

                // offset
                if(file.offset != 0)
                    cmd += $" -itsoffset {file.offset}";

                // path
                cmd += $" -i \"{file.path}\"";
            }



            foreach (OutputFile file in outputFiles)
            {
                bool needVProcessing = false;

                // since `-c copy` is to untouch stream processing but some option requires to process it
                // putting them together will throw and Error, needVProcessing will tell if this command
                // needs any and prvent this Error from happening
                if (file.processOption.v_scale != null || file.processOption.v_crop != null)
                    needVProcessing = true;


                // PROCESS
                // map

                {
                    SimStrmMappingForm.Selection mapping = file.processOption.strmMapping;
                    if (mapping != null)
                    {
                        if (mapping.disableVideo) cmd += " -vn";
                        if (mapping.disableAudio) cmd += " -an";
                        if (mapping.disableSubtitle) cmd += " -sn";
                        if (mapping.disableData) cmd += " -dn";

                        if (mapping.stringSelectCode.Count != 0)
                        {
                            foreach (string map in mapping.stringSelectCode)
                                cmd += $" -map {map}";
                        }
                    }
                }



                {
                    // codec
                    P_OptionQuality qual = file.processOption.quality;
                    if (qual?.vQuality > -1 || qual?.aQuality > -1) needVProcessing = true;
                    if (!needVProcessing)
                    {
                        if (qual == null)
                            cmd += " -c copy";
                        else
                        {
                            if (qual.vQuality == -1 && qual.aQuality == -1) cmd += " -c copy";
                            else if (qual.vQuality == -1) cmd += " -c:v copy";
                        }
                    }
                    else
                    {
                        if (prefs.FF_hardwareAccelDecodeCodec != null&& prefs.FF_hardwareAccelDecodeCodec != "")
                        { //Note: Decode hardware acceleration cannot work with other `-c:v` or `-c`
                            cmd += $" -c:v {prefs.FF_hardwareAccelDecodeCodec}";
                        }
                        //try to preserve vdo quality(still lost ~10-20% quality) and got larger file size in the process
                        if (qual?.vQuality == -1) cmd += " -qscale 0";
                    }

                    if (qual?.aQuality == -1) cmd += " -c:a copy";


                    // bitrate & quality
                    if (qual?.vQuality > -1) cmd += $" -b:v {qual.vQuality}k";
                    if (qual?.aQuality > -1) cmd += $" -b:a {qual.aQuality}k";
                }


                // stream fillters
                {
                    V_scaleSelectForm.Selection vscale = file.processOption.v_scale;
                    V_cropSelectForm.Selection vcrop = file.processOption.v_crop;
                    bool hasOtherArg = false;

                    if (vscale != null || vcrop != null) cmd += " -vf \"";
                    if (vscale != null)
                    {
                        cmd += $"scale={vscale.width}:{vscale.height}";
                        hasOtherArg = true;
                    }

                    if (vcrop != null)
                    {
                        cmd += (hasOtherArg ? "," : "") + $"crop={vcrop.width}:{vcrop.height}:{vcrop.x}:{vcrop.y}";
                        hasOtherArg = true;
                    }

                    if (vscale != null || vcrop != null)
                        cmd += "\"";
                }


                // metadata
                {
                    Metadata meta = file.processOption.metadata;
                    //bool metaAdded = false;
                    if (meta != null)
                    {
                        if (meta.title != null) cmd += $" -metadata \"title={meta.title}\"";
                        if (meta.author != null) cmd += $" -metadata \"author={meta.author}\"";
                        if (meta.composter != null) cmd += $" -metadata \"composter={meta.composter}\"";
                        if (meta.description != null) cmd += $" -metadata \"description={meta.description}\"";
                        if (meta.creation_time != null) cmd += $" -metadata \"creation_time={meta.creation_time}\"";
                        if (meta.copyright != null) cmd += $" -metadata \"copyright={meta.copyright}\"";
                        if (meta.comment != null) cmd += $" -metadata \"comment={meta.comment}\"";
                        if (meta.grouping != null) cmd += $" -metadata \"grouping={meta.grouping}\"";
                        if (meta.album != null) cmd += $" -metadata \"album={meta.album}\"";
                        if (meta.album_artist != null) cmd += $" -metadata \"album_artist={meta.album_artist}\"";
                        if (meta.genre != null) cmd += $" -metadata \"genre={meta.genre}\"";
                    }
                }




                // output format
                {
                    string OPFormat = file.processOption.forceOutputFormat;
                    if (OPFormat != null)
                    {
                        cmd += $" -f {OPFormat}";
                    }
                }


                // output file
                if (file.requiredCaching)
                {
                    if (!Directory.Exists("./.cache/")) Directory.CreateDirectory("./.cache/");
                    cmd += $" \"../.cache/{file.ID}\"";
                }else
                {
                    if (Sim_renderOpt.renderModeRepeat)
                    {
                       // string name = file.name.Substring(0, file.name.LastIndexOf('.'));
                        string path = file.path.Substring(0, file.path.LastIndexOf('.'));
                        string ext = file.name.Substring(file.name.LastIndexOf('.') + 1);

                        cmd += $" \"{path + Sim_renderOpt.step}.{ext}\"";
                    }else cmd += $" \"{file.path}\"";
                }
            }


            return cmd;

        }




        public static string generateWhatItDoesMsg(List<InputFile> inputFiles, List<OutputFile> outputFiles)
        {
            string res = "";
            if (Sim_renderOpt.requiredMutiStep)
            {
                res += $"#Command for Step {Sim_renderOpt.step} of {Sim_renderOpt.step_total}\n\n";
            }


            byte stepIndex = 1;
            res += $"{stepIndex++}. first, call FFmpeg.exe (if exsit in the PATH)\n";
           


            // Gobal Options
            if (prefs.FF_autoReplaceWhenAsk) res += $"{stepIndex++}. then spicify `-y` argument telling FFmpeg to replace file with the same name without asking\n";


            // INPUT
            uint fileIndex = 1;
            foreach (InputFile file in inputFiles)
            {
                //fillter
                if (file.info == null) continue;

                // trimming
                if (file.trimming != null && !file.trimming.selectedAll)
                {
                    if (file.trimming.fromDuration)
                        res += $"{stepIndex++}. use `-t` argument to tell FFmpeg to only parse {file.name} from start with length of {file.trimming.from.ToString().ToModernTime()}\n";
                    else
                    {
                        if (!file.trimming.fromStart)
                        {
                            res += $"{stepIndex++}. use `-ss`" + (!file.trimming.toEnd?" and `-to`":"");
                            res += $" argument to tell FFmpeg to only parse {file.name} from {file.trimming.from.ToString().ToModernTime()}";
                            if (file.trimming.toEnd) res += " to end of File\n";
                            else res += "\n";
                        }
                        if (!file.trimming.toEnd)
                        {
                            if(file.trimming.fromStart)
                                res += $"{stepIndex++}. use `-to` argument to tell FFmpeg to only parse {file.name} from start to {file.trimming.to.ToString().ToModernTime()}\n";

                            if (!file.trimming.fromStart)
                                res += $" to {file.trimming.to.ToString().ToModernTime()}\n";
                        }
                    }
                }

                // offset
                if (file.offset != 0)
                    res += $"{stepIndex++}. specify `-itsoffset` argument to Offset {file.name} by {file.offset}s\n";

                // path
                res += $"{stepIndex++}. declared {fileIndex++.ToPlaceNum()} input file from \"{file.path}\"\n";
            }


            fileIndex = 1;
            foreach (OutputFile file in outputFiles)
            {
                bool needVProcessing = false;

                // since `-c copy` is to untouch stream processing but some option requires to process it
                // putting them together will throw and Error, needVProcessing will tell if this command
                // needs any and prvent this Error from happening
                if (file.processOption.v_scale != null || file.processOption.v_crop != null)
                    needVProcessing = true;


                // PROCESS
                // map
                {
                    SimStrmMappingForm.Selection mapping = file.processOption.strmMapping;
                    if (mapping != null)
                    {
                        bool hasOtherDisable = false;
                        if (mapping.disableVideo ||
                            mapping.disableAudio ||
                            mapping.disableSubtitle ||
                            mapping.disableData
                        )
                        {
                            res += $"{stepIndex++}. disable ";
                            if (mapping.disableVideo)
                            {
                                res += "Video";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableAudio)
                            {
                                res += (hasOtherDisable ? ", " : "") + "Audio";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableSubtitle)
                            {
                                res += (hasOtherDisable ? ", " : "") + "Subtitle";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableData)
                            {
                                res += (hasOtherDisable ? ", " : "") + "Data";
                                hasOtherDisable = true;
                            }
                            
                            res += " streams with ";

                            hasOtherDisable = false;
                            if (mapping.disableVideo)
                            {
                                res += "`-vn`";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableAudio)
                            {
                                res += (hasOtherDisable ? ", " : "") + "`-an`";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableSubtitle)
                            {
                                res += (hasOtherDisable ? ", " : "") + "`-sn`";
                                hasOtherDisable = true;
                            }
                            if (mapping.disableData)
                            {
                                res += (hasOtherDisable ? ", " : "") + "`-an`";
                                hasOtherDisable = true;
                            }

                            res += " argument\n";
                        }
                        

                        if (mapping.stringSelectCode.Count != 0)
                        {
                            foreach (string map in mapping.stringSelectCode)
                            {
                                string[] mapArg = map.Split(':');
                                res += $"{stepIndex++}. map ";
                                switch (mapArg[1])
                                {
                                    case "v": res += $"{(mapArg.Length != 3?"":(Convert.ToUInt32(mapArg[2]) + 1).ToPlaceNum())} Video";
                                        break;
                                    case "a": res += $"{(mapArg.Length != 3 ? "" : (Convert.ToUInt32(mapArg[2]) + 1).ToPlaceNum())} Audio";
                                        break;
                                    case "s": res += $"{(mapArg.Length != 3 ? "" : (Convert.ToUInt32(mapArg[2]) + 1).ToPlaceNum())} Subtitle";
                                        break;
                                }
                                res += $" from {(Convert.ToUInt32(mapArg[0]) + 1).ToPlaceNum()} Input file";
                                res += $" to Output file {file.name}\n";
                            } 
                        }
                    }
                }


                {
                    // codec
                    P_OptionQuality qual = file.processOption.quality;
                    if (qual?.vQuality > -1 || qual?.aQuality > -1) needVProcessing = true;
                    if (!needVProcessing)
                    {
                        if (qual == null)
                            res += $"{stepIndex++}. set Codec for {file.name} to `copy`\n   (copy all maped stream to Output: no quality lost) with `-c copy`\n";
                        else
                        {
                            if (qual.vQuality == -1 && qual.aQuality == -1)
                                res += $"{stepIndex++}. set Codec for {file.name} to `copy`\n   (copy all maped stream to Output: no quality lost) with `-c copy`\n";
                            else if (qual.vQuality == -1)
                                res += $"{stepIndex++}. set Codec for Video stream from {file.name} to `copy`\n   (copy maped stream to Output: no quality lost) with `-c:v copy`\n";
                        }
                    }
                    else
                    {
                        if (prefs.FF_hardwareAccelDecodeCodec != null&& prefs.FF_hardwareAccelDecodeCodec != "")
                        { //Note: Decode hardware acceleration cannot work with other `-c:v` or `-c`
                            res += $"{stepIndex++}. set codec for Video stream from \"{file.name}\" to Hardware Accelerated Codec (rendered by GPU)";
                            res += $" using `-c:v` argument\n";
                        }
                        //try to preserve vdo quality(still lost ~10-20% quality) and got larger file size in the process
                        if (qual?.vQuality == -1)
                        {
                            res += $"{stepIndex++}. try to preserve Video quality by using `-qscale 0` but still lost 10-20% quality,\n";
                            res += "   for using this instead of `-c:v copy`(which has on quality lost) is because";
                            if (prefs.FF_hardwareAccelDecodeCodec != null)
                                res += " Codec has been set to\n    Hardware Accelerated Codec, which only one `-c:v` is alowed at the time\n";
                            else if (needVProcessing)
                                res += " other argument\n   requires Video stream processing which conflict with `-c:v copy`\n";
                        }

                    }

                    if (qual?.aQuality == -1) 
                        res += $"{stepIndex++}. set Codec for Audio stream from {file.name}\n   to `copy` (copy maped stream to Output: no quality lost) with `-c:a copy`\n";


                    // bitrate & quality
                    if (qual?.vQuality > -1) 
                        res += $"{stepIndex++}. use `-b:v` to set Video bitrate to {qual.vQuality}kbps,\n   (`:v` is here to tell FFmpeg what stream to set bitrate, in this case Video)\n";
                    if (qual?.aQuality > -1)
                        res += $"{stepIndex++}. use `-b:a` to set Audio bitrate to {qual.aQuality}kbps,\n   (`:a` is here to tell FFmpeg what stream to set bitrate, in this case Audio)\n";

                }


                // stream fillters
                {
                    V_scaleSelectForm.Selection vscale = file.processOption.v_scale;
                    V_cropSelectForm.Selection vcrop = file.processOption.v_crop;
                    bool hasOtherArg = false;

                    if (vscale != null || vcrop != null) 
                        res += $"{stepIndex++}. specify Video stream Filtergraph to modify Video stream using `-vf` argument\n   and set";
                    if (vscale != null)
                    {
                        res += $" Video Scaling to {vscale.width}px X {vscale.height}px";
                        hasOtherArg = true;
                    }

                    if (vcrop != null)
                    {
                        res += (hasOtherArg ? ", " : "") + $" Video Cropping to {vcrop.width}px width {vcrop.height}px height  at {vcrop.x}x {vcrop.y}y of the screen";
                        hasOtherArg = true;
                    }

                    if (vscale != null || vcrop != null)
                        res += "\"";
                }


                // metadata
                {
                    Metadata meta = file.processOption.metadata;
                    bool metaAdded = false;
                    if (meta != null)
                    {
                        if (meta.title != null) metaAdded = true;
                        if (meta.author != null) metaAdded = true;
                        if (meta.composter != null) metaAdded = true;
                        if (meta.description != null) metaAdded = true;
                        if (meta.creation_time != null) metaAdded = true;
                        if (meta.copyright != null) metaAdded = true;
                        if (meta.comment != null) metaAdded = true;
                        if (meta.grouping != null) metaAdded = true;
                        if (meta.album != null) metaAdded = true;
                        if (meta.album_artist != null) metaAdded = true;
                        if (meta.genre != null) metaAdded = true;
                    }
                    if (metaAdded) res += $"{stepIndex++}. Set Metedata using `-metadata` argument";
                }



                // output format
                {
                    string OPFormat = file.processOption.forceOutputFormat;
                    if (OPFormat != null)
                    {
                        res += $"{stepIndex++}. specify Output fommat to {OPFormat} with `-f` argument\n";
                    }
                }


                // output file
                if (file.requiredCaching) 
                    res += $"{stepIndex++}. declared {fileIndex++.ToPlaceNum()} Output file that point to .cache folder\nbecause FFmpeg aren't allowed Output of the same file\nthe Output has be cache when rendering";
                else res += $"{stepIndex++}. declared {fileIndex++.ToPlaceNum()} Output file from \"{file.path}\"\n";
            }


            return res;

        }



        public static int estimateOutputSize(List<InputFile> inputFiles, List<OutputFile> outputFiles)
        {
            // temporary
            int expectedOutputSize = 0;
            foreach (OutputFile opf in outputFiles)
            { 
                foreach (InputFile file in inputFiles)
                {
                    expectedOutputSize += file.info.sizekB;
                }
            }
            return expectedOutputSize;
        }





        public static uint estimateOutputDuration(List<InputFile> inputFiles, List<OutputFile> outputFiles)
        {
            uint finalDurationMS = 0;

            foreach (OutputFile opf in outputFiles)
            {
                ProcessOptions processOpt = opf.processOption;

                if (processOpt.concatMode)
                {
                    foreach (InputFile ipf in inputFiles)
                    {
                        if (ipf.info == null) continue;

                        if (ipf.trimming == null)
                            finalDurationMS += ipf.info.durationMS;
                        else
                        {
                            ipf.UpdateFinalLength();
                            finalDurationMS += ipf.info.durationMS_final;
                        }
                    }
                    return finalDurationMS;
                }
                else
                {
                    if(processOpt.strmMapping != null)
                    {
                        uint longestStrmLength = 0;
                        foreach(SimStrmMappingForm.DragAble mapedInfo in processOpt.strmMapping.infoList)
                        {// mapedInfo -> all inputFiles that has been maped (can be duplicates)
                            inputFiles[mapedInfo.fileIndex].UpdateFinalLength();
                            uint thisStrmLength = inputFiles[mapedInfo.fileIndex].info.durationMS_final;

                            if(thisStrmLength > longestStrmLength)
                                longestStrmLength = thisStrmLength;
                            
                        }

                        if(longestStrmLength > finalDurationMS)
                            finalDurationMS = longestStrmLength;
                    }
                    else
                    {
                        foreach(InputFile ipf in inputFiles)
                        {
                            if (ipf.info == null) continue;
                            ipf.UpdateFinalLength();
                            if(ipf.info.durationMS_final > finalDurationMS)
                                finalDurationMS = ipf.info.durationMS_final;
                        }
                    }
                }

            }

            return finalDurationMS;
        }






        public static void loadConfig()
        {
            JObject JSONconfig = null;
            if(System.IO.File.Exists(configPath))
                JSONconfig = JObject.Parse(System.IO.File.ReadAllText(configPath));
            if (JSONconfig == null)
            {
                MissingConfig = true;
                return;
            }

            prefs = new Preferences();
            prefs.js_controllerP = JSONconfig.GetValue("js_controllerP")?.ToString() ?? defaultConfig.js_controllerP;
            prefs.js_folderP = JSONconfig.GetValue("js_folderP")?.ToString() ?? defaultConfig.js_folderP;
            prefs.FF_autoReplaceWhenAsk = (bool)(JSONconfig.GetValue("FF_autoReplaceWhenAsk") ?? defaultConfig.FF_autoReplaceWhenAsk);

            prefs.hideCMD = (bool)(JSONconfig.GetValue("hideCMD") ?? defaultConfig.hideCMD);
            prefs.hideFFmpegOutput = (bool)(JSONconfig.GetValue("hideFFmpegOutput") ?? defaultConfig.hideFFmpegOutput);
            prefs.bin_folderP = JSONconfig.GetValue("bin_folderP")?.ToString() ?? defaultConfig.bin_folderP;
            prefs.defOpenInputP = JSONconfig.GetValue("defOpenInputP")?.ToString() ?? defaultConfig.defOpenInputP;
            prefs.defOpenOutputP = JSONconfig.GetValue("defOpenOutputP")?.ToString() ?? defaultConfig.defOpenOutputP;
            prefs.internalReadDelay = Convert.ToInt16(JSONconfig.GetValue("internalReadDelay") ?? defaultConfig.internalReadDelay);
            prefs.FF_inputArg = JSONconfig.GetValue("FF_inputArg")?.ToString() ?? defaultConfig.FF_inputArg;
            prefs.FF_processArg = JSONconfig.GetValue("FF_processArg")?.ToString() ?? defaultConfig.FF_processArg;
            prefs.FF_hardwareAccelDecodeCodec = JSONconfig.GetValue("FF_hardwareAccelDecodeCodec")?.ToString() ?? defaultConfig.FF_hardwareAccelDecodeCodec;
            prefs.saveSettingToFile = (bool)(JSONconfig.GetValue("saveSettingToFile") ?? defaultConfig.saveSettingToFile);

            prefs.lastSelInputExt = JSONconfig.GetValue("lastSelInputExt")?.ToString() ?? defaultConfig.lastSelInputExt;



            // set init value
            App.lastChooseFileExt = prefs.lastSelInputExt;
        }


        public static void saveConfig()
        {
            try
            {
                string cfg = JsonConvert.SerializeObject(prefs);
                System.IO.File.WriteAllText(configPath, cfg);

            }
            catch
            {
                return;
            }
        }



        public static void checkMissingDep()
        {
            if (!System.IO.File.Exists($"{prefs.bin_folderP}ffmpeg.exe"))// if cant find in ./_bin/
            {
                MissingLocalDep = true;
                MissingFFmpeg = !Tools.isExeGloballyCallable("ffmpeg"); // see if its in PATH
                if (!MissingFFmpeg) usingPATHExe = true;
            } 

            if (!System.IO.File.Exists($"{prefs.bin_folderP}mpv.exe"))
            {
                MissingLocalDep = true;
                MissingMpv = !Tools.isExeGloballyCallable("mpv");
                if (!MissingMpv) usingPATHExe = true;
            }
            
            if (!System.IO.File.Exists($"{prefs.bin_folderP}ffprobe.exe"))
            {
                MissingLocalDep = true;
                MissingFFprobe = !Tools.isExeGloballyCallable("ffprobe");
                if (!MissingFFprobe) usingPATHExe = true;
            }

            if (!System.IO.File.Exists($"{prefs.js_folderP}node.exe"))
                MissingNodeJS = !Tools.isExeGloballyCallable("node");

            MissingJS = !System.IO.File.Exists($"{prefs.js_folderP}terminal.js");

            // for config file (prefs.json) would be checked in this.loadconfig()
        }



        public static void generateMissingDep()
        {
            try
            {
                if (!Directory.Exists(prefs.js_folderP))
                    Directory.CreateDirectory(prefs.js_folderP);


                if (MissingConfig&&prefs.saveSettingToFile)
                {
                    string cfg = JsonConvert.SerializeObject(defaultConfig);
                    System.IO.File.WriteAllText(configPath, cfg);
                    MissingConfig = false;
                }

                if(MissingJS && !MissingNodeJS)
                {
                    System.IO.File.WriteAllText($"{prefs.js_folderP}terminal.js", terminal_js);
                    MissingJS = false;
                }
            }
            catch
            {
                return;
            }
            
        }


        /// <summary>
        /// check all Inputs Outputs and Options befor start generating
        /// command and fix some of them in the process
        /// (for mode Simple)
        /// </summary>
        public static void Sim_checkValidity()
        {
            // check for same input output file
            foreach (string id in Sim_outputFile.childInputFilesID)
            {
                foreach (App.InputFile file in App.Sim_inputFiles)
                {
                    if (file.ID != id) continue;
                    if (file.path != App.Sim_outputFile.path) continue;
                    App.Sim_outputFile.requiredCaching = true;
                }
            }

        }




        public static void Sim_prepareToRunCommand()
        {
            RenderOptions opt = Sim_renderOpt;

            // generate var for render step
            if (opt.requiredMutiStep&&opt.step_total == -1)
            {
                if (opt.renderModeRepeat)
                {
                    opt.fileToRepeat = new List<string>() { };
                    List<string> fileToRepeat_paths = new List<string>() { };

                    foreach(InputFile file in App.Sim_inputFiles)
                    {
                        if (file.info == null) continue;
                        if (fileToRepeat_paths.Contains(file.path)) continue; // exclude file with same path

                        opt.fileToRepeat.Add(file.ID);
                        fileToRepeat_paths.Add(file.path);
                    }
                    opt.step_total = (short) opt.fileToRepeat.Count();
                }
            }



            if (opt.renderModeRepeat)
            {
                // fileToRepeat file IDs will be remove one by one for each step done
                opt.step = (short) (opt.step_total - opt.fileToRepeat.Count() + 1);
            }
        }
    }
}
