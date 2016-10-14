using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using VideoLibrary;

namespace YouTubeDownloaderDesktop
{
    public class DownloadManager
    {
        public void SaveVideo(string link)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            getMP4(video);
            MessageBox.Show("It's finished!");

        }

        public void SaveMP3(string link)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(link);
            getMP4(video);

            string videoName = getFileName(video.FullName);
            string convertToMP3Command = "/C ffmpeg -i " + "\"C:\\Users\\Aland\\Documents\\" + video.FullName + "\"" + " -vn -ab 256k " + "\"C:\\Users\\Aland\\Documents\\" + videoName + ".mp3\"";
            System.Diagnostics.Process.Start("CMD.exe", convertToMP3Command);

            File.Delete("C:\\Users\\Aland\\Documents\\" + video.FullName);
            File.Delete("C:\\Users\\Aland\\Documents\\" + videoName + ".mp4");
            MessageBox.Show("It's finished!");

        }

        private void getMP4(YouTubeVideo video)
        {
            string fileextension = video.FileExtension;

            File.WriteAllBytes(@"C:\Users\Aland\Documents\" + video.FullName, video.GetBytes());


            if (!fileextension.Contains("mp4"))
            {
                //string videoFileName = video.FullName.Substring(0, video.FullName.LastIndexOf('.'));
                string videoFileName = getFileName(video.FullName);
                //convert the video into a mp4
                string convertToMP4Command = "/C ffmpeg -i " + "\"C:\\Users\\Aland\\Documents\\" + video.FullName + "\"" + " -c:v libx264 " + "\"C:\\Users\\Aland\\Documents\\" + videoFileName + ".mp4\"";
                System.Diagnostics.Process.Start("CMD.exe", convertToMP4Command);
            }
        }

        private string getFileName(string fullName)
        {
            return fullName.Substring(0, fullName.LastIndexOf('.'));
        }
    }
}
