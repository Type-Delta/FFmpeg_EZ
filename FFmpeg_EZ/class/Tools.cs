using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace FFmpeg_EZ
{
    public static class Tools
    {


        




        ////////    Functions   /////////


        /// Extension Functions
        
        /// <summary>
        /// Perform a deep Copy of the object, using Json as a serialization method. 
        /// NOTE1: Private members are not cloned using this method.
        /// NOTE2: Requires Newtonsoft.Json.dll
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneJson<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null)) return default;

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(
                JsonConvert.SerializeObject(
                    source, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                ),
                deserializeSettings
            );
        }






        /// <summary>
        /// parse String to Bool, Simple!
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool ToBool(this string str)
        {
            str = str.Trim().ToLower();
            if (str == "true") return true;
            if (str == "false") return false;
            throw new Exception($"this string cannot parse to bool: \"{str}\"");
        }







        /// <summary>
        /// Generate unique ID
        /// </summary>
        /// <param name="idLength"></param>
        /// <param name="existedIDs"></param>
        /// <returns></returns>
        public static string generateID(byte idLength, List<string> existedIDs)
        {
            string id = "";
            Random rngGen = new Random();

            while (true)
            {
                while (id.Length < idLength) id += (rngGen.Next(10)).ToString(); //generate ID

                // check if that ID match any existed ID, if not return it
                int i = 0;
                do
                {
                    if (existedIDs.Count() == 0 || (existedIDs[i] != id && i == (existedIDs.Count() - 1)))
                    {
                        existedIDs.Add(id);
                        return id;
                    }

                    i++;
                } while (i < existedIDs.Count());
            }
        }

        public static string ToCharID(this ushort num)
        {
            if (num <= 0) throw new Exception("Tools.ToCharID: given number cannot be 0");

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
            string res = "";
            if(num < 25) return chars[num - 1].ToString();

            for(float overTimes = (float)num / 25; overTimes > 0; overTimes--)
            {
                if(overTimes < 1) res += chars[num % 25];
                res += chars.Last();
            }
            return res.Reverse().ToString();
        }

        /// <summary>
        /// convert time in `hh:MM:ss.fff` to total MS count
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns></returns>
        public static uint ToTimeMS(this string timeStr)
        {
            string[] timeArr = timeStr.Trim()
                .Replace('.', ':')
                .Split(':')
                .ToArray();
            uint[] time = new uint[timeArr.Length];
            for(int i = 0; i < timeArr.Length; i++)
            {
                if(i < 3)
                {
                    time[i] = Convert.ToUInt32(timeArr[i]);
                    continue;
                }
                time[3] = Convert.ToUInt32(timeArr[3].PadRight(3, '0'));
            }

            time[1] += (ushort)(time[0] * 60);
            time[2] += (uint)(time[1] * 60);
            return time[3] += time[2] * 1000;
        }



        public static string ToTimeString(this uint timeMS, string style = "full")
        {
            // import from JS
            double year = 0, month = 0, days = 0, hr = 0, min = 0, sec = 0;
            bool useDDMMYYYformat = (timeMS > 262800200);
            while (timeMS >= 1000)
            {
                timeMS -= 1000;
                sec++;
            }
            while (sec >= 60)
            {
                sec -= 60;
                min++;
            }
            while (min >= 60)
            {
                min -= 60;
                hr++;
            }

            if (useDDMMYYYformat)
            {
                while (hr >= 24)
                {
                    hr -= 24;
                    days++;
                }
                while (days >= 30.4167)
                {
                    days -= 30.4167;
                    month++;
                }
                days = Math.Round(days);
                while (month >= 12)
                {
                    month -= 12;
                    year++;
                }

            }


            string timeMSstr = timeMS.ToString();
            while (timeMSstr.Length < 3 && timeMSstr != "00")
            {
                timeMS = '0' + timeMS;
            }



            if (useDDMMYYYformat)
            {
                if (style == "full") return $"{year}/{month}/{days}T{hr}:{min}:{sec}.{timeMS}";
                else if (style == "modern") { 
                    if (year + month + days + sec + min + hr == 0)
                    {
                        return $"{timeMS}ms";
                    }
                    else if (year + month + days + min + hr == 0)
                    {
                        return $"{sec}.{timeMS}s";
                    }
                    else if (year + month + days + hr == 0)
                    {
                        return $"{min}min {sec}s";
                    }
                    else if (year + month + days == 0)
                    {
                        return $"{hr}hr {min}min";
                    }
                    else if (year + month == 0)
                    {
                        return $"{days}days {hr}hr";
                    }
                    else if (year == 0)
                    {
                        return $"{month}months {days}days";
                    }
                    else return $"{year}year {month}months";
                }
            }
            else
            {

                if (style == "full") return $"{hr}:{min}:{sec}.{timeMS}";
                else if (style == "modern")
                {
                    if (sec + min + hr == 0)
                    {
                        return $"{timeMS}ms";
                    }
                    else if (min + hr == 0)
                    {
                        return $"{sec}.{timeMS}s";
                    }
                    else if (hr == 0)
                    {
                        return $"{min}min {sec}s";
                    }
                    else return $"{hr}hr {min}min";
                }
            }
            return null;
        }



        public static string extractNum(string s)
        {
            string res = Regex.Replace(s, @"[^0-9]+", "");
            return (res == "") ? null : res;
        }


        

        public static string ToModernTime(this string oldTimeformat)
        {
            //oldTimeFormat = "00:02:41.87" (hr:min:sec.ms)
            List<string> timeStrArr = oldTimeformat.Trim()
                .Replace(".", ":")
                .Split(':')
                .ToList();
            List<short> timeArr = timeStrArr.ToArray().Select((strTime, i) => 
                Convert.ToInt16(strTime)
            ).ToList();

            bool hasOtherTime = false;
            string res = "";
            if (timeArr[0] > 0)
            {
                res += $"{timeArr[0]} hr";
                hasOtherTime = true;
            }
            if (timeArr[1] > 0)
            {
                res += $" {timeArr[1]} min";
                hasOtherTime = true;
            }
            if (timeArr[2] > 0)
            {
                res += $" {timeArr[2]} sec";
                hasOtherTime = true;
            }
            if (timeArr[3] > 0||!hasOtherTime) res += $" {timeArr[3]} ms";

            return res.Trim();
        }

        public static string ToPlaceNum(this uint num)
        {
            switch (num)
            {
                case 0: return "zero";
                case 1: return "first";
                case 2: return "second";
                case 3: return "third";
                case 4: return "forth";
                case 5: return "fifths";
                case 6: return "sixths";
                case 7: return "sevenths";
                case 8: return "eighths";
                case 9: return "nineths";
                case 10: return "tenths";
                default: return num.ToString() + "th";
            }
        }


        /// <summary>
        /// cast func any Function to func object Function
        /// this type of function can then be store in var func object  for future use
        /// </summary>
        /// <typeparam name="i1"></typeparam>
        /// <typeparam name="i2"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<object> BuildMethod<i1, i2, T>(Func<i1, i2, T> func)
        {
            return () => func;
        }



        public static bool isExeGloballyCallable(string ExeName)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ExeName.Trim();
            startInfo.UseShellExecute = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = $"/C -h";
            process.StartInfo = startInfo;

            try
            {
                process.Start(); // try to call the App
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                process.Close();
                if (ex.Message.Contains("The system cannot find the file specified")) return false;
                else return true;
            }


            //process.WaitForExit();
            process.Kill();
            process.Close();
            return true;
        }




        public static void testCMD1()
        {

            int lineCount = 0;
            string output = "";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                // Prepend line numbers to each line of the output.
                if (!String.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    output += ("\n[" + lineCount + "]: " + e.Data);
                    Console.WriteLine("\n[" + lineCount + "]: " + e.Data);
                }
            });
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                // Prepend line numbers to each line of the output.
                if (!String.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    output += ("\n[E" + lineCount + "]: " + e.Data);
                    Console.WriteLine("\n[E" + lineCount + "]: " + e.Data);
                }
            });
            // cd to Dive C: incase the Exe is in the CMD's start diretory
            // request for help msg to prevent app from start up by calling just its name
            startInfo.Arguments = $"/C -hjj";
            process.StartInfo = startInfo;

            try
            {
                process.Start(); // try to call the App
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                process.Close();
                if (ex.Message.Contains("The system cannot find the file specified")) return;
                else return;
            }
            process.BeginOutputReadLine();
            process.WaitForExit();

            // Write the redirected output to this application's window.
            // for debug
            //Console.WriteLine(output);

            process.WaitForExit();

            process.Close();
            // those output dont contains Error message 
            // and if it did Error it should not contains any output
            if (output.Trim() == "") return;
            return;
        }


        public static bool ContainsAny(this string str, List<string> strList)
        {
            foreach(string s in strList.ToList())
            {
                if(str.Contains(s)) return true;
            }
            return false;
        }


        public static Func<object> CastFunc<T>(Func<T> func)
        {
            return () => func();
        }


        public class Remote
        {
            private static bool _triggered = false;

            public async Task WaitForTrigger()
            {
                await Task.Run(() =>
                {
                    while (!_triggered)
                    {
                        Application.DoEvents();
                    }

                    if(_triggered) _triggered = false;
                });
            }

            public void Trigger()
            {
                _triggered = true;
            }
        }


        public class Promise
        {
            // 0: inactive
            // 1: pending
            // 2: resolved
            // 3: rejected
            private byte _status = 0;


            public Promise(Func<object> func)
            {
                func();
            }



            public T Resolve<T>(T value)
            {
                this._status = 2;
                return value;
            }

            public T Reject<T>(T value)
            {
                this._status = 3;
                return value;
            }
        }


        public class _Promise
        {

        }

    }
}
