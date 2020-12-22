using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace YouTubeDownloaderDesktop
{
    public class DownloadManager
    {
        private string m_filename = "";
        public void SaveVideo(string link, BackgroundWorker saver)
        {
            getFileName(link, saver);
            getMP4(link, saver);
        }

        public void SaveMP3(string link, BackgroundWorker saver)
        {
            getFileName(link, saver);
            getMp3(link, saver);
            saver.ReportProgress(100);
        }

        private void getFileName(string url, BackgroundWorker worker)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"youtube-dl.exe {url} --get-filename",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            worker.ReportProgress(1);
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string fullName = proc.StandardOutput.ReadLine();
                m_filename = fullName.Substring(0, fullName.LastIndexOf('.'));
            }
            proc.Close();
            worker.ReportProgress(10);

        }

        private void getMP4(String url, BackgroundWorker saver)
        {
            saver.ReportProgress(30);
            if (hasMP4(url, saver))
            {
                
                string command = $"youtube-dl.exe {url} -f \"mp4\"";
                Process powershell = Process.Start("powershell.exe", command);
                powershell.WaitForExit();
            }
            else
            {
                // ask ffmpeg to convert the file
                string command = $"youtube-dl.exe {url} --recode-format \"mp4\"";
                Process powershell = Process.Start("powershell.exe", command);
                powershell.WaitForExit();
            }

            // for some odd reason, running youtube-dl.exe in Powershell causes it to be unable to read
            // its .conf file even though I use the same string in a separate Powershell console and it works...
            // string commandFile = $"\"{Directory.GetCurrentDirectory()}\\youtube-dl.conf\"";
            // string command = $"youtube-dl.exe {url} --config-location {commandFile}";
            string destination = $"{GlobalVar.saveLocation}\\{m_filename}.mp4";
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
            string source = $"{m_filename}.mp4";
            File.Move(source, destination);

            saver.ReportProgress(100);
        }

        private bool hasMP4(String url, BackgroundWorker worker)
        {
            bool isMp4 = false;
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"youtube-dl.exe {url} -F",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            worker.ReportProgress(11);
            proc.Start();
            while (!proc.StandardOutput.EndOfStream && !isMp4)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line.Contains(" mp4 "))
                {
                    isMp4 = true;
                }
            }
            proc.Close();
            if (isMp4)
            {
                worker.ReportProgress(20);
            }
            else
            {
                worker.ReportProgress(19);
            }
            return isMp4;
        }

        private void getMp3(String url, BackgroundWorker worker)
        {
            worker.ReportProgress(31);
            string command = $"youtube-dl.exe {url} -x --audio-format \"mp3\"";
            Process powershell = Process.Start("powershell.exe", command);
            powershell.WaitForExit();

            string destination = $"{GlobalVar.saveLocation}\\{m_filename}.mp3";
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
            string source = $"{m_filename}.mp3";
            File.Move(source, destination);

            worker.ReportProgress(100);
        }

        //taken from http://codesnippets.fesslersoft.de/get-the-youtube-videoid-from-url/
        public static string getVideoID(string videoURL)
        {
            string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
            Regex youtubeRegex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in youtubeRegex.Matches(videoURL))
            {
                //Console.WriteLine(match);
                foreach (var groupdata in match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://") && !groupdata.ToString().StartsWith("https://") && !groupdata.ToString().StartsWith("youtu") && !groupdata.ToString().StartsWith("www.")))
                {
                    return groupdata.ToString();
                }
            }
            return string.Empty;
        }
    }
}
