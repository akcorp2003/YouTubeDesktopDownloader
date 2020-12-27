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
        private string m_filename;
        public Progress(String videoURL, DownloadType val)
        {
            InitializeComponent();
            m_videoURL = videoURL;
            m_val = val;
            saver.DoWork += Saver_DoWork;
            saver.WorkerReportsProgress = true;
            saver.ProgressChanged += Saver_ProgressChanged;
        }

        public string getDownloadedFile()
        {
            return m_filename;
        }

        private void Saver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10)
            {
                updateText.Text = "Succeesfully gotten the name of your file!";
            }
            else if (e.ProgressPercentage == 11)
            {
                updateText.Text = "Determining if mp4 is available...";
            }
            else if (e.ProgressPercentage == 19)
            {
                updateText.Text = "There is no mp4 available for your video but we will convert it to one! It might take a little extra time.";
            }
            else if (e.ProgressPercentage == 20)
            {
                updateText.Text = "mp4 is available for your video!";
            }
            else if (e.ProgressPercentage == 30)
            {
                updateText.Text = "Beginning your download. Please check the window that opens for more updates";
            }
            else if (e.ProgressPercentage == 31)
            {
                updateText.Text = "Beginning your download and converting it to an mp3";
            }
            else if (e.ProgressPercentage == 99)
            {
                updateText.Text = @"We're sorry. Something went wrong. Please try again.";
                progressBar.Visibility = Visibility.Hidden;
                confirmFinished.Visibility = Visibility.Visible;
            }
            else if(e.ProgressPercentage == 100)
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

            DownloadManager myManager = new DownloadManager(args.VideoURL, saver);
            if (args.Val == DownloadType.video)
            {
                m_filename = myManager.SaveVideo();
            }
            else
            {
                m_filename = myManager.SaveMP3();
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
