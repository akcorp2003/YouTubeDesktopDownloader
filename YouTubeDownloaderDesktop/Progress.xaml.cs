using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YouTubeDownloaderDesktop
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        private string m_videoURL;
        private DownloadType m_val;
        public Progress(String videoURL, DownloadType val)
        {
            InitializeComponent();
            m_videoURL = videoURL;
            m_val = val;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DownloadManager myManager = new DownloadManager();
            if (m_val == DownloadType.video)
            {               
                myManager.SaveVideo(m_videoURL);
            }
            else
            {
                myManager.SaveMP3(m_videoURL);
            }
            this.Close();
        }
    }
}
