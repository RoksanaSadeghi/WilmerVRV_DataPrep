   M S B A M L   `   `   `  ���� M  IWilmerVRV_DataPrep, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WilmerVRV_DataPrepWilmerVRV_DataPrep  #    WilmerVRV_DataPrep.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:WilmerVRV_DataPrep       � Title$   WilmerVRV DataPrep Program��$	��870��$	��550�� � 
ResizeMode$ CanResizeWithGrip=� � 	Resources    lB �� 
TargetType �� Property �� Value � Orientation��%�   &	        �� " ��.���  � ��$ Disabled=���  � ��$ Disabled=���  � ��$
 Left=���  � ��$	 Top=���  � ��$	 Top=���  � ��$
 Left=���  � �� �� .R�� $ 
Horizontal=�.���� $
��Auto=�.��� -    �Name$ MainGrid�� � RowDefinitions �� -   	 ��Name$	 LabelsGR��$
��Auto ��� -   $	 ListGR��$
��Auto ��� -   $	 	OptionsGR��$
��Auto ��� -   $	 SubmitGR��$
��Auto �.+��� -   
 ��Name$
 TestNameLabel��$��
Scene Name��$��12(�
�������$	��100��$��20��$��0��$
��Left=�$��	10,10,0,0q�$��2��$	��Top=��� -   $
 	EasyLabel��$
��Easy��$��12(�$��Center=�
�������$��60��$
��Auto��$��0��$
��Left=�$��
140,10,0,0q��� -   $
 MediumLabel��$��Medium��$��12(�$��Center=�
�������$��60��$
��Auto��$��0��$
��Left=�$��
210,10,0,0q��� -	   $
 	HardLabel��$
��Hard��$��12(�$��Center=�
�������$��60��$
��Auto��$��0��$
��Left=�$��
280,10,0,0q��� -
    ��Name$ TaskListBox�����	#FF202020���#FAFAFA$��	10,0,10,0q�$
��Auto=�$��Disabled=�$��1������ .R�� $ 
Horizontal=��� -    ��Name$ NumberofTestsLabel��$��Number of Tests:��$��12(�
�������$
��Auto��$��25��$��2��$	��Top=�$
��Left=�$��	10,10,0,0q��� -    ��Name$ NumberOfTestsTextBox��$��3��$��Center=�$��12(�
�������$��60��$��20��$��2��$	��Top=�$
��Left=�$��
150,15,0,0q��� -   $ 	TimeLabel��$��Time Between Scenes (s):��$��12(�
�������$
��Auto��$��25��$��2��$	��Top=�$
��Left=�$��	10,45,0,0q��� -   $ TimeTextBox��$��1��$��Center=�$��12(�
�������$��60��$��20��$��2��$	��Top=�$
��Left=�$��
150,50,0,0q��� -   $ NumberofPlaylistsLabel��$��Number of Playlists:��$��12(�
�������$
��Auto��$��25��$��2��$	��Top=�$
��Left=�$��	10,80,0,0q��� -   $ NumberOfPlaylistsTextBox��$��1��$��Center=�$��12(�
�������$��60��$��20��$��2��$	��Top=�$
��Left=�$��
150,85,0,0q��� -   $
 CreatePlaylist��$��Create Playlist��$��14(�$	��200��$��50��$��2��$	��Top=�$��Right=�$��	0,30,60,0q�