   M S B A M L   `   `   `  ���� S  OYouTubeDownloaderDesktop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:YouTubeDownloaderDesktopYouTubeDownloaderDesktop  )    #YouTubeDownloaderDesktop.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:YouTubeDownloaderDesktop     -     � Title$  
GetYouTube��$	��457��$	��525�� � 	Resources    sbShowPanel �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  sbHidePanel��%�   &	        &	 Q     �� .��t� $ Margin�$ 
0,0,-360,0X�$ 
0,0,-110,0X�$ .9Q�$ 0:0:1D��� .��t� $ Margin�$ 
0,0,-183,0X�$ 
0,0,-360,0X�$ .9Q�$ 0:0:1D�.��� .+��� 
�������
�������$��1q�$
��Left=�$	��180��$��
119,40,0,0q�$	��Top=�$	��304���� -    ��Name$ WelcomeText��$��Type in the YouTube URL:��$
��Left=�$��184,234,0,0q�$	��Top=��� -    ��Name$ 
YouTubeURL��$
��Left=�$��23��$��
98,265,0,0q�	 �� TextWrapping$
	 Wrap=�$��YouTube URL��$	��Top=�$	��316���� -   
 ��Name$
 startDownload��$��Download Video!��$
��Left=�$��192,311,0,0q�$	��Top=�$	��128���� -   $
 startDownloadMP3��$��Download MP3!��$
��Left=�$��192,358,0,0q�$	��Top=�$	��128��o� -    o�Name$
 menu��$
��Left=�$��20��$	��Top=�$	��517��.@�m� -    m�Name$ 	File_Menu��$
��File��.@�m� -   $ UserSettings��$��Settings���� -	    ��Name$ youtubeThumbnail��$
��Left=�$	��142��$��
162,59,0,0q�$	��Top=�$	��217��$��UniformToFill=��� -
   $��	SidePanel�� K� ZIndex$ 2��$	��406�� �� Orientation$ 
Horizontal=�$��Right=�$��
0,0,-356,0q�.+�� .+��� -   $
 	hidePanel��$��56��$��48��$
��Hide��$y�Hidden=��� -   $
 	showPanel��$��56��$��48��$
��Show���� ���	#FFDCE9FF$��1q�$	��165�����	#FFDCE9FF._��� -    ��Name$ recentVideos��$��	0,0,-78,0q� �� View �� .P��� $
��Name�� �� Width$	 243�� �� DisplayMemberBinding ��  �� Path$
 Name�