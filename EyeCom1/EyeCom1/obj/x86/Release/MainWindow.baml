   M S B A M L   `   `   `  ���� ^  ZTobii.Interaction.Net, Version=0.7.3.333, Culture=neutral, PublicKeyToken=70326046dcdce6cb\Bclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.NetTobii.Interaction.Wpf   WpfApplication1    WpfApplication1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     TtobiiBclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.Net       � Title$  
MainWindow�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=� � 	Resources    NormalStyle%   Tobii.Interaction.Wpf.Behaviors �� Property �� Value �� Triggers P� Property P� Value��%{  &	        �� .���  �@ IsGazeAware . ��  � ��$ Center=���  � ��
 �   ���  � {� .  P�  �@J�IsMouseOver . . ���  � ��$ Italic$���  � ��
 �  ����  � ��
 � ���P�  � �� . . ���  � ��
 � � ���  � ��
 ��  �P�  �@ HasGaze . . ���  � ��
 �� ����  � {� .  .��� -   $��
LayoutRoot��	   IsGazeAware	 . ���� 
 �� 
TargetType"
 �.���  � ��
 ����� P�  �@ HasGaze . . ���  � ��
 �� �� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* � � RowDefinitions �� $��1* ��� $��1* �.+��� -   $��b_r0c0��$��0��$��0��#��[  .���� $��.\res\r0c0.jpg���� -   $
��r0c0��$��0��$��0���� -   $��b_r0c1��$��1��$��0��#��[  .���� $��.\res\r0c1.jpg���� -    ��Name$
 r0c1��$��1��$��0���� -   $��b_r0c2��$��2��$��0��#��[  .���� $��.\res\r0c2.jpg���� -   $
 r0c2��$��2��$��0���� -   $��b_r0c3��$��3��$��0��#��[  .���� $��.\res\r0c3.jpg���� -	   $
 r0c3��$��3��$��0���� -
   $��b_r1c0��$��0��$��1��#��[  .���� $��.\res\r1c0.jpg���� -   $
 r1c0��$��0��$��1���� -   $��b_r1c1��$��1��$��1��#��[  .���� $��.\res\r1c1.jpg���� -   $
 r1c1��$��1��$��1���� -   $��b_r1c2��$��2��$��1��#��[  .���� $��.\res\r1c2.jpg���� -   $
 r1c2��$��2��$��1���� -   $��b_r1c3��$��3��$��1��#��[  .���� $��.\res\r1c3.jpg���� -   $
 r1c3��$��3��$��1��