﻿using System;
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
            if(item.Name == "Settings")
            {

            }
        }
    }
}