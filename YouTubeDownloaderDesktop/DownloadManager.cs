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

            string videoFileName = getFileName(video.FullName);
            if (!fileextension.Contains("mp4"))
            {
                //convert the video into a mp4
                string convertToMP4Command = "/C ffmpeg -i " + "\"" + GlobalVar.saveLocation + @"\" + video.FullName + "\"" + " -s hd" + GlobalVar.saveVideoP + " -c:v libx264 " + "\"" + GlobalVar.saveLocation + @"\" + videoFileName + ".mp4\"";
                saver.ReportProgress(50);
                Process ffmpegProcess = Process.Start("CMD.exe", convertToMP4Command);
                ffmpegProcess.WaitForExit();    
            }

            //ffmpeg -i input.mp4 -s hd480 -c:v libx264 -profile:v high -preset medium -b:v 500k -maxrate 500k -c:a aac -b:a 128k -threads 0 output.mp4
            //convert the video into the desired resolution, skip for 720p as it automatically downloads 720
            //helpful site: https://www.virag.si/2012/01/web-video-encoding-tutorial-with-ffmpeg-0-9/
            if (GlobalVar.saveVideoP != "720")
            {
                string scaleMP4Command = "/C ffmpeg -i " + "\"" + GlobalVar.saveLocation + @"\" + video.FullName + "\"" + " -s hd" + GlobalVar.saveVideoP + " -c:v libx264 -profile:v high -preset medium -b:v 500k -maxrate 500k -c:a aac -b:a 128k -threads 0 " + "\"" + GlobalVar.saveLocation + @"\" + videoFileName + "-" + GlobalVar.saveVideoP + "p.mp4\"";
                saver.ReportProgress(80);
                Process ffmpegScalingProcess = Process.Start("CMD.exe", scaleMP4Command);
                ffmpegScalingProcess.WaitForExit();

                if (File.Exists(GlobalVar.saveLocation + @"\" + videoFileName + ".mp4"))
                {
                    File.Delete(GlobalVar.saveLocation + @"\" + videoFileName + ".mp4");
                }
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
