# YouTubeDesktopDownloader
Are your favourite YouTube downloading websites getting taken down? Use this free app: GetYouTube! No installation required! It can convert most, if not all, YouTube videos into MP4 and also MP3 format. 

## Screenshots ##

![](https://i.imgur.com/dX6A7SG.png)

![](https://i.imgur.com/dBvjW6V.png)

![](https://i.imgur.com/I8Kyojc.png)

![](https://i.imgur.com/glARU6h.png)

## Requirements ##

- .NET Framework 4.5+
- Windows 7 or higher
- youtube-dl (Get it [here](https://yt-dl.org/latest/youtube-dl.exe))
- ffmpeg 4.3.1 Windows essentials build (Get it [here](https://www.gyan.dev/ffmpeg/builds/).)

## How Do I Get Started? ##

1. Download the .exe file in the [latest release assets folder](https://github.com/akcorp2003/YouTubeDesktopDownloader/releases/download/v2.0/YouTubeDownloaderDesktop.exe). Place it somewhere in your computer.
2. Make sure you have the latest v4 of .NET Framework installed. (Compatibility with .NET 5.0 is uncertain)
3. Configure your firewall to allow this program to access the internet. 
4. Download ffmpeg. Follow [this](http://www.wikihow.com/Install-FFmpeg-on-Windows) amazing tutorial on how to set it up.
5. Download youtube-dl. Follow [their guide](https://github.com/ytdl-org/youtube-dl) on GitHub.
6. Make sure you have ffmpeg and youtube-dl defined in your PATH on Windows. Check [here](https://docs.microsoft.com/en-us/previous-versions/office/developer/sharepoint-2010/ee537574(v=office.14)) for instructions on adding a PATH variable in Windows.

## How Do I Use It? 

1. After you open it, go to *File > Settings* and select a folder you want to save your music/videos in. The application saves your location but be sure to update it when you decide to change download locations!
2. Copy and paste the YouTube link into the text box with "YouTube URL."
3. Click your desired output!
4. During the converting process, Powershell will open up. That's youtube-dl converting your video to either a video or a MP3!

## What's Next? ##

- Store the most recent downloaded files
- Making a sexier UI
- Exposing more youtube-dl options
