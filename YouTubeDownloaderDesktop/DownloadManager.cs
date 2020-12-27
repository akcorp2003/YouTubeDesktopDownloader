using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YouTubeDownloaderDesktop
{
    public class DownloadManager
    {
        private BackgroundWorker worker;
        private string link;

        public DownloadManager(string url, BackgroundWorker downloadWorker)
        {
            link = url;
            worker = downloadWorker;
        }

        public string SaveVideo()
        {
            return getMP4();
        }

        public string SaveMP3()
        {
            return getMp3();
        }

        private string getMP4()
        {
            worker.ReportProgress(30);
            if (hasMP4())
            {
                
                string command = $"youtube-dl.exe {link} -f \"mp4\"";
                Process powershell = Process.Start("powershell.exe", command);
                powershell.WaitForExit();
            }
            else
            {
                // ask ffmpeg to convert the file
                string command = $"youtube-dl.exe {link} --recode-format \"mp4\"";
                Process powershell = Process.Start("powershell.exe", command);
                powershell.WaitForExit();
            }

            // for some odd reason, running youtube-dl.exe in Powershell causes it to be unable to read
            // its .conf file even though I use the same string in a separate Powershell console and it works...
            // string commandFile = $"\"{Directory.GetCurrentDirectory()}\\youtube-dl.conf\"";
            // string command = $"youtube-dl.exe {url} --config-location {commandFile}";
            string destination = moveDownloadedFile(".mp4");

            if (destination.Length == 0)
            {
                worker.ReportProgress(99);
            }
            else
            {
                worker.ReportProgress(100);
            }

            return destination;
        }

        private bool hasMP4()
        {
            bool isMp4 = false;
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"youtube-dl.exe {link} -F",
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

        private string moveDownloadedFile(string fileType)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            // find the most recently created MP3 file
            FileInfo[] files = currentDirectory
                   .GetFiles()
                   .OrderByDescending(f => f.CreationTime)
                   .Where(f => f.Extension == fileType)
                   .ToArray();
            try
            {
                FileInfo downloadedFile = files[0];
                string destination = $"{GlobalVar.saveLocation}\\{downloadedFile.Name}";
                File.Move(downloadedFile.FullName, destination);

                return destination;
            }
            catch (Exception e)
            {
                string message = $"An error occured: {e.Message}";
                MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            
        }

        private string getMp3()
        {
            worker.ReportProgress(31);
            string command = $"youtube-dl.exe {link} -x --audio-format \"mp3\"";
            Process powershell = Process.Start("powershell.exe", command);
            powershell.WaitForExit();

            string destination = moveDownloadedFile(".mp3");

            if (destination.Length == 0)
            {
                worker.ReportProgress(99);
            }
            else
            {
                worker.ReportProgress(100);
            }

            powershell.Close();

            return destination;
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
