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
using System.Windows.Forms;

namespace YouTubeDownloaderDesktop
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            folderPathDialog.ShowDialog();
            saveDirectory.Text = folderPathDialog.SelectedPath;
        }

        private void saveSettings_Click(object sender, RoutedEventArgs e)
        {
            GlobalVar.saveLocation = saveDirectory.Text;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveDirectory.Text = GlobalVar.saveLocation;

            if(GlobalVar.saveKBPS == "128k")
            {
                res128k.IsChecked = true;
            }
            else
            {
                res256k.IsChecked = true;
            }

            if(GlobalVar.saveVideoP == "720")
            {
                quality720p.IsChecked = true;
            }
            else
            {
                quality480p.IsChecked = true; 
            }
        }

        private void res128k_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVar.saveKBPS = "128k";
        }

        private void res256k_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVar.saveKBPS = "256k";
        }

        private void quality480p_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVar.saveVideoP = "480";
        }

        private void quality720p_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVar.saveVideoP = "720";
        }
    }
}
