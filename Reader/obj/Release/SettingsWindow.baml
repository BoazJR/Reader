   M S B A M L   `   `   `  ���� 
  Reader    Reader.SettingsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  Settings�� � Title$ Settings��$	��403��$	��638�� � Icon$ Resources/Lips.png�� � WindowStartupLocation$ CenterScreen=����	#FF474747$y�Visible=� � AllowsTransparency .  � WindowStyle$
 None=�.��� $��0,0,2,10q�.+��� -    ��Name$ SpeedSlider��$
��Left=�$��	83,10,0,0q�$	��Top=�$	��199��$��27�� J� RenderTransformOrigin$ 0.5,0.5&� � Minimum$	 -10Q�	 � SmallChange$	 1Q�
 � Value
 ��  �� Path$ speed� �� Mode$ TwoWay=�z�V� .~��� �� ��  �� Angle$ -0.124Q�T� �� -    ��Name$ Speed_Lable��$��Speed:
��$
��Left=�$��	10,10,0,0q�$	��Top=�$ -0.237,0.462&�$	��102��$��27��
��������� -    ��Name$ NameList��$
��Left=�$��	79,39,0,0q�$	��Top=�$	��203�� �� SelectedItem �� $ 	voiceName�$ TwoWay=��� -   $ 
VoiceLable��$��Voice
��$
��Left=�$��	10,37,0,0q�$	��Top=�$��64��$��24��
��������� -   $��	regExList��$	��184��$
��Left=�$��	10,66,0,0q�$	��Top=�$	��616����. ���� *RegExs+ �� View �� .P��� $��On�� �� Width$ 30�� �� CellTemplate �� .R���  d� 	IsChecked �� *
IsActive+�� $
��Name��$	 115�� �� .R��� $	��100������ *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� $ ��Regular Expression Pattern��$	 315�� �� .R��� $	��300������ *	Pattern+$ PropertyChanged=��� $��Replace with��$ 85�� �� .R��� $��70������ *Replacement+$ PropertyChanged=��� $��Delete��$ 50�� �� .R��� -   $��Delete������ �� -    ��Name$ AddRegExButton��$��Add Regular Expression��$
��Left=�$��
484,41,0,0q�$	��Top=�$	��142��$ 
-0.32,0.35&��� -	   $��Load Default��$
��Left=�$��
404,41,0,0q�$	��Top=�$��75���� -
   $��X��$
��Left=�$��
570,13,0,0q�$	��Top=�$��56��$
��Bold"�
���  ���� -   $
��Left=�$��609,368,0,0q�$	��Top=�$��17��$ 0.118,0.467&� �� *UseVisibleWindow+�� $ ��Start With Visible Window:��$
��Left=�$��453,362,0,0q�$	��Top=�$ 0.737,-0.308&�$	��151��
��������� $
��Left=�$��
10,255,0,0q�$	��Top=�$	��616��
�������$��39��
������ . �/� .T�J� .*���You can use regular expressions to replace patterns of text so that the program will pronaunce them differently. For more info http://en.wikipedia.org/wiki/Regular_expression�� $
��Left=�$��
11,299,0,0q�$	��Top=�$	��172��
�������$��84��
������ ��Z� . �/� .T�J� .*�1/In invisible window mode open settings like so:J� .*�75Double click lips icon in task bar to read and pause.�� $
��Left=�$��94��$��188,299,0,0q�$	��Top=�$	��116��$��Resources/Taskbar.png��