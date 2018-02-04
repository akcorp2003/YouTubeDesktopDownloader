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
using System.ComponentModel;

namespace YouTubeDownloaderDesktop
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        private string m_videoURL;
        private DownloadType m_val;
        private readonly BackgroundWorker saver = new BackgroundWorker();
        public Progress(String videoURL, DownloadType val)
        {
            InitializeComponent();
            m_videoURL = videoURL;
            m_val = val;
            saver.DoWork += Saver_DoWork;
            // saver.RunWorkerCompleted += Saver_RunWorkerCompleted;
            saver.WorkerReportsProgress = true;
            saver.ProgressChanged += Saver_ProgressChanged;
        }

        private void Saver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage == 50)
            {
                updateText.Text = "Got your video! Now we're converting it into MP4 format.";
            }
            else if(e.ProgressPercentage == 75)
            {
                updateText.Text = "Converted to MP4! Now we're converting it into MP3 format.";
            }
            else if(e.ProgressPercentage == 99)
            {
                updateText.Text = "Finished converting your YouTube video! Enjoy!!";
                progressBar.Visibility = Visibility.Hidden;
                confirmFinished.Visibility = Visibility.Visible;
            }
        }

        private void Saver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("It's finished!");
            this.Close();
        }

        private void Saver_DoWork(object sender, DoWorkEventArgs e)
        {
            SaverArguments args = e.Argument as SaverArguments;

            DownloadManager myManager = new DownloadManager();
            if (args.Val == DownloadType.video)
            {
                myManager.SaveVideo(args.VideoURL, saver);
            }
            else
            {
                myManager.SaveMP3(args.VideoURL, saver);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            SaverArguments args = new SaverArguments(m_val, m_videoURL);
            saver.RunWorkerAsync(args);
        }

        private void confirmFinished_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class SaverArguments
    {
        private DownloadType m_val;
        private string m_videoURL;

        public SaverArguments(DownloadType val, string videoURL)
        {
            m_val = val;
            m_videoURL = videoURL;
        }

        public DownloadType Val
        {
            get
            {
                return m_val;
            }
            set
            {
                m_val = value;
            }
        }

        public string VideoURL
        {
            get
            {
                return m_videoURL;
            }
            set
            {
                m_videoURL = value;
            }
        }
    }
}
