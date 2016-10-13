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

            File.WriteAllBytes(@"C:\Users\Aland\Documents" + video.FullName, video.GetBytes());

            MessageBox.Show("It's finished!");

        }
    }
}
