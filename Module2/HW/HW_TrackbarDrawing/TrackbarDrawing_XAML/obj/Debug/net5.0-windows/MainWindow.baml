   M S B A M L   `   `   `  ����O  KTrackbarDrawing_XAML, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TrackbarDrawing_XAMLTrackbarDrawing_XAML  5   	   %    TrackbarDrawing_XAML.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TrackbarDrawing_XAML     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      N� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6;   :x,http://schemas.microsoft.com/winfx/2006/xaml     5
      $	��300��5	      $	��300��6    N� 
Background
 �����.��5   
   � $��Center=�6   
����ح�$��Center=�5       � ShowGridLines$
 True��6,   $	��250��6A   $	��250��6N    � RowDefinitions 5      �� 5      $��* �6    6-   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      $��* �6#   6/   .+�5      �� -   5        $��sliderX��5   2   $��1��6   $��1��6"    � Minimum$ 0Q�6A    � Maximum$	 200Q�6M    �� Orientation$ 
Horizontal=�6[   $��10q�6t   6�   �� 5      -   5        $��canvas��5   2   $��0��6   $��1��6"   
�������.+�5      � -   5        $��polyline��5      
���   �$��20��6:   6Q   5      �� 5      -   5        $��sliderY��5   2   $��0��6   $��0��6"   $ 0Q�6A   $	 200Q�6M   $ Vertical=�6[   $��10q�6r   6�   �� 5      -   5        $��button��5   2   $��0��6   $��1��6%   $��Очистить��6@   6j   5      5      5      