   M S B A M L   `   `   `  ���� A  =Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ReaderReader      Reader.VisibleWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &localclr-namespace:Reader     -     �Name$  VisibleWindow1�� � Title$ Reader��$��51��$��183.668�����	#FF474747 � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Icon$ Resources/Lips.png�� � TaskbarItemInfo *  $System.Windows.Shell.TaskbarItemInfo     ThumbButtonInfos 4  .System.Windows.Shell.ThumbButtonInfoCollection  *  $System.Windows.Shell.ThumbButtonInfo  -      SettingsImage   ImageSource# [     Description$ Settings��	 � 	Resources	   
PlayButton
 �� ImageSource j� Stretch  RestartButton  PauseButton  
StopButton  CloseButton  mouseOnBorder �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ButtonTemplate��%;  &	       &	 2     &	 g     &	 �     &	 �     &	 �     '��     &	 S    �� $
 Resources/PlayButton.png��$ Uniform=��� $!
 Resources/RestartButton.png��$ Uniform=��� $
 Resources/PauseButton.png��$ Uniform=��� $
 Resources/StopButton.png��$ Uniform=��� $
 Resources/CloseButton.png��$ Uniform=��� 
����� ��� " �� P�  � {� .  . ���  �@J�Opacity$	 0.2Q��� .R��� $
��30px��$
��30px��#��z������ " ��.���  � ��
 ����  P�  �@J�IsMouseOver . . ���  � �� �	#FF00DCFF.��� .+��� -    ��Name$ 
PlayButton��$��	10,0,0,11q�$��30��$��Bottom=�$
��Left=�$��30�� J� RenderTransformOrigin$ 2.833,2.767&�#��[ {���  �� Path$ canPlay����� $
 Resources/PlayButton.png��$ Uniform=��� -   $ PauseButton��$��45,11,109,10q�$
��30px��$
��30px��$ 
-0.3,0.467&�#��[ {��� $ canPause���Z� ���� $
 Resources/PauseButton.png��$ Uniform=��� -   $ 
StopButton��$�� ��$
��Left=�$��	75,10,0,0q�$
��30px��$
��30px��$	��Top=�#��[ $ -0.467,-0.8&�{��� $ canStop���Z� ���� $
 Resources/StopButton.png��$ Uniform=��� -   $ SettingsButton��$�� ��$
��Left=�$��
110,10,0,0q�$
��30px��$
��30px��$	��Top=�#��[ ��Z� ��Z� ���� $
 Resources/Settings.png��$ Uniform=��� -   $��X��$
��Left=�$��145,10,-39,-9q�$	��Top=�$
��30px��$
��30px��#��[ ���� $
 Resources/CloseButton.png��$ Uniform=�