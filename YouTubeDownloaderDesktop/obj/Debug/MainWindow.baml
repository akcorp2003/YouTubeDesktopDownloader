   M S B A M L   `   `   `  ����S  OYouTubeDownloaderDesktop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:YouTubeDownloaderDesktopYouTubeDownloaderDesktop  5   	   )    #YouTubeDownloaderDesktop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:YouTubeDownloaderDesktop     5   	   -   5          � Title$  
GetYouTube��5   	   $	��457��6   $	��525��6)    � 	Resources 5	         sbShowPanel �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  sbHidePanel��%  &	        &	 �     �� 5
   
   .��5      t� $ Margin�6!   $ 
0,0,-360,0X�6D   $ 
0,0,-110,0X�6V   $ .9Q�6f   $ 0:0:1D�6}   5      �� 5   
   .��5      t� $ Margin�6!   $ 
0,0,-183,0X�6D   $ 
0,0,-360,0X�6V   $ .9Q�6f   $ 0:0:1D�6}   5      5      .��5      � .+�5   
   �� 
�������
�������$��1q�6F   $
��Left=�6Z   $	��180��6u   $��
119,40,0,0q�6�   $	��Top=�6�   $	��304��6�   �� 5   
   -   5         ��Name$ WelcomeText��5      $��Type in the YouTube URL:��6%   $
��Left=�6H   $��184,234,0,0q�6c   $	��Top=�6x   �� 5   
   -   5         ��Name$ 
YouTubeURL��5      $
��Left=�6&   $��23��6A   $��
98,265,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6a   $��YouTube URL��6u   $	��Top=�6�   $	��316��6�   6A  �� 5   
   -   5        
 ��Name$
 startDownload��5      $��Download Video!��6(   $
��Left=�6B   $��192,311,0,0q�6]   $	��Top=�6r   $	��128��6�   6�   �� 5   
   -   5        $
 startDownloadMP3��5      $��Download MP3!��6+   $
��Left=�6C   $��192,358,0,0q�6^   $	��Top=�6s   $	��128��6�   6�   o� 5   
   -   5         o�Name$
 menu��5      $
��Left=�6   $��20��68   $	��Top=�6D   $	��517��6\   .@�5      m� -   5         m�Name$ 	File_Menu��5      $
��File��6*   .@�5      m� -   5        $ UserSettings��5      $��Settings��61   6C   5      5      �� 5   
   -	   5         ��Name$ youtubeThumbnail��5      $
��Left=�6*   $	��142��6E   $��
162,59,0,0q�6R   $	��Top=�6f   $	��217��6~   $��UniformToFill=�6�   �� 5!   
   -
   5        $��	SidePanel��5!   &    K� ZIndex$ 2��6   $	��406��67    �� Orientation$ 
Horizontal=�6C   $��Right=�6\   $��
0,0,-356,0q�6x   .+�5"      � .+�5#      �� -   5        $
 	hidePanel��5#      $��56��6,   $��48��67   $
��Hide��6C   $y�Hidden=�6R   6f   �� 5$      -   5        $
 	showPanel��5$      $��56��6,   $��48��67   $
��Show��6C   6R   5&      �� 5'      ���	#FFDCE9FF$��1q�6-   $	��165��6A   ���	#FFDCE9FF._�5(      �� -   5         ��Name$ recentVideos��5(      $��	0,0,-78,0q�61    �� View 5)      �� 5*      .P�5+      �� $
��Name��6-    �� Width$	 243��6;    �� DisplayMemberBinding 6G   ��  �� Path$
 Name�5,      5.      5/      51      53      54      