   M S B A M L   `   `   `  ����A  =Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ReaderReader  5          Reader.VisibleWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      &localclr-namespace:Reader     5      -   5          �Name$  VisibleWindow1��5   (    � Title$ Reader��5      $��51��6   $��183.668��6    ���	#FF474747 � 
ResizeMode$ NoResize=�6G    � WindowStyle$
 None=�5   *    � Icon$ Resources/Lips.png��6=    � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5	   
      ThumbButtonInfos 5      4  .System.Windows.Shell.ThumbButtonInfoCollection  *  $System.Windows.Shell.ThumbButtonInfo  5      -   5           SettingsImage   ImageSource# [  5   &      Description$ Settings��6S   6j   5      5      	 � 	Resources	 5        
PlayButton
 �� ImageSource j� Stretch  RestartButton  PauseButton  
StopButton  CloseButton  mouseOnBorder �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ButtonTemplate��%�  &	       &	 N     &	 �     &	 �     &	 <    &	 �    '�� �    &	 1    �� 5   
   $
 Resources/PlayButton.png��6(   $ Uniform=�6O   5      �� 5   
   $!
 Resources/RestartButton.png��6+   $ Uniform=�6U   5      �� 5   
   $
 Resources/PauseButton.png��6)   $ Uniform=�6Q   5      �� 5   
   $
 Resources/StopButton.png��6(   $ Uniform=�6O   5      �� 5   
   $
 Resources/CloseButton.png��6)   $ Uniform=�6Q   5      �� 5   
   
����� �5      �� 5   
   " ��6    5       P� 5!       � {� .  . �5"      ��  �@J�Opacity$	 0.2Q�60   5#      5%      �� 5&   
   .R�5'      �� $
��30px��6   $
��30px��6%   #��z��63   ��5(      �� 5)      " ��6   .�5*      ��  � ��
 ���� 61    5+      P� 5,       �@J�IsMouseOver . . �5-   "   ��  � �� �	#FF00DCFF6;   5.      50      52      53      54      .��56      � .+�57   
   �� -   5         ��Name$ 
PlayButton��57      $��	10,0,0,11q�6%   $��30��58   4   $��Bottom=�6@   $
��Left=�6[   $��30��59       J� RenderTransformOrigin$ 2.833,2.767&�6   #��[ 6@   {�58      ��  �� Path$ canPlay���5:      �� 5;      $
 Resources/PlayButton.png��6   $ Uniform=�6D   5>      �� 5@   
   -   5        $ PauseButton��5@      $��45,11,109,10q�6e   $
��30px��5A      $
��30px��6   $ 
-0.3,0.467&�6B   #��[ 6e   {�5@   A   �� $ canPause���5A   +   Z� ��5B      �� 5C      $
 Resources/PauseButton.png��6   $ Uniform=�6E   5F      �� 5G   
   -   5        $ 
StopButton��5G      $�� ��6%   $
��Left=�60   $��	75,10,0,0q�6K   $
��30px��6^   $
��30px��6k   $	��Top=�5H      #��[ 5I      $ -0.467,-0.8&�6=   {�5H   B   �� $ canStop���6e   Z� ��5J      �� 5K      $
 Resources/StopButton.png��6   $ Uniform=�6D   5N      �� 5O   
   -   5        $ SettingsButton��5O      $�� ��6)   $
��Left=�64   $��
110,10,0,0q�6P   $
��30px��6d   $
��30px��6q   $	��Top=�5P      #��[ 6t   ��6G   Z� ��6]   Z� ��5Q      �� 5R      $
 Resources/Settings.png��6   $ Uniform=�6B   5U      �� 5V   
   -   5        $��X��5V      $
��Left=�6   $��145,10,-39,-9q�68   $	��Top=�6O   $
��30px��6g   $
��30px��6t   #��[ 5W   -   ��5X      �� 5Y      $
 Resources/CloseButton.png��6   $ Uniform=�6E   5\      5]      5^      