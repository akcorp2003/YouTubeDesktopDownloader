using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeDownloaderDesktop
{
    public enum DownloadType
    {
        video,
        mp3
    };

    public static class GlobalVar
    {
        public static string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    }
}
