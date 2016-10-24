using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using VideoLibrary;

namespace YouTubeDownloaderDesktop
{
    public class DownloadManager
    {
        public void SaveVideo(string link, BackgroundWorker saver)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            getMP4(video, saver);

        }

        public void SaveMP3(string link, BackgroundWorker saver)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            getMP4(video, saver);

            string videoName = getFileName(video.FullName);
            //string convertToMP3Command = "/C ffmpeg -i " + "\"C:\\Users\\Aland\\Documents\\" + video.FullName + "\"" + " -vn -ab 256k " + "\"C:\\Users\\Aland\\Documents\\" + videoName + ".mp3\"";
            //string convertToMP3Command = "/C ffmpeg -i " + "\"" + GlobalVar.saveLocation + @"\" + video.FullName + "\"" + " -vn -ab 256k " + "\"" +GlobalVar.saveLocation + @"\" + videoName + ".mp3\"";
            string convertToMP3Command = "/C ffmpeg -i " + "\"" + GlobalVar.saveLocation + @"\" + video.FullName + "\"" + " -vn -ab " + GlobalVar.saveKBPS + " " + "\"" + GlobalVar.saveLocation + @"\" + videoName + ".mp3\"";
            saver.ReportProgress(75);
            Process ffmpegProcess = Process.Start("CMD.exe", convertToMP3Command);
            ffmpegProcess.WaitForExit();

            if(File.Exists(GlobalVar.saveLocation + @"\" + video.FullName))
            {
                File.Delete(GlobalVar.saveLocation + @"\" + video.FullName);
            }

            if(File.Exists(GlobalVar.saveLocation + @"\" + videoName + ".mp4"))
            {
                File.Delete(GlobalVar.saveLocation + @"\" + videoName + ".mp4");
            }

            saver.ReportProgress(99);

        }

        private void getMP4(YouTubeVideo video, BackgroundWorker saver)
        {
            string fileextension = video.FileExtension;

            File.WriteAllBytes(GlobalVar.saveLocation + @"\" + video.FullName, video.GetBytes());


            if (!fileextension.Contains("mp4"))
            {
                //string videoFileName = video.FullName.Substring(0, video.FullName.LastIndexOf('.'));
                string videoFileName = getFileName(video.FullName);
                //convert the video into a mp4
                //string convertToMP4Command = "/C ffmpeg -i " + "\"C:\\Users\\Aland\\Documents\\" + video.FullName + "\"" + " -c:v libx264 " + "\"C:\\Users\\Aland\\Documents\\" + videoFileName + ".mp4\"";
                string convertToMP4Command = "/C ffmpeg -i " + "\"" + GlobalVar.saveLocation + @"\" + video.FullName + "\"" + " -c:v libx264 " + "\"" + GlobalVar.saveLocation + @"\" + videoFileName + ".mp4\"";
                saver.ReportProgress(50);
                Process ffmpegProcess = Process.Start("CMD.exe", convertToMP4Command);
                ffmpegProcess.WaitForExit();
                
            }

            saver.ReportProgress(99);
        }

        private string getFileName(string fullName)
        {
            return fullName.Substring(0, fullName.LastIndexOf('.'));
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
