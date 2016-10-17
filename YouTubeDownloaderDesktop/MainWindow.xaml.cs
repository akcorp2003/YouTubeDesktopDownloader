using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YouTubeDownloaderDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startDownload_Click(object sender, RoutedEventArgs e)
        {
            Progress progressWindow = new Progress(YouTubeURL.Text, DownloadType.video);
            progressWindow.Show();
        }

        private void startDownloadMP3_Click(object sender, RoutedEventArgs e)
        {
            Progress progressWindow = new Progress(YouTubeURL.Text, DownloadType.mp3);
            progressWindow.Show();
        }

        private void YouTubeURL_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            YouTubeURL.Text = "";
        }

        private void YouTubeURL_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            YouTubeURL.Text = "";
        }

        private void YouTubeURL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            YouTubeURL.Text = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if(item.Name == "UserSettings")
            {
                Settings newSettings = new Settings();
                newSettings.ShowDialog();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create("UserSettings.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("GlobalVar");

                writer.WriteStartElement("SaveLocation");
                writer.WriteElementString("Path", GlobalVar.saveLocation);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("UserSettings.xml"))
            {
                using (XmlReader reader = XmlReader.Create("UserSettings.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "GlobalVar":
                                    break;
                                case "SaveLocation":
                                    break;
                                case "Path":
                                    if (reader.Read())
                                    {
                                        //this will be the actual user specified path
                                        GlobalVar.saveLocation = reader.Value.Trim();
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void youtubeThumbnail_Loaded(object sender, RoutedEventArgs e)
        {
            string ytID = DownloadManager.getVideoID(YouTubeURL.Text);
            if(!String.IsNullOrEmpty(ytID))
            {
                BitmapImage thumbnail = new BitmapImage();
                thumbnail.BeginInit();
                thumbnail.UriSource = new Uri("http://img.youtube.com/vi/" + ytID + @"/0.jpg");
                thumbnail.EndInit();

                var image = sender as Image;
                image.Source = thumbnail;
            }
            
        }

        private void YouTubeURL_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ytID = DownloadManager.getVideoID(YouTubeURL.Text);
            if (!String.IsNullOrEmpty(ytID))
            {
                BitmapImage thumbnail = new BitmapImage();
                thumbnail.BeginInit();
                thumbnail.UriSource = new Uri("http://img.youtube.com/vi/" + ytID + @"/0.jpg");
                thumbnail.EndInit();

                youtubeThumbnail.Source = thumbnail;
            }
        }
    }
}
