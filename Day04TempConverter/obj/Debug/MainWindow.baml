   M S B A M L   `   `   `  ����M  IDay04TempConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Day04TempConverterDay04TempConverter  5   	   #    Day04TempConverter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Day04TempConverter     5   	     � Title$  Temperature converter��5   	   $	��263��6'   $	��398��64   .��5	      � .+�5   
   �� $��Output��6   $
��Left=�6!   $��146,181,0,0q�6<   $	��Top=�6Q   �� 5   
   $��Input��6   $
��Left=�6    $��
146,10,0,0q�6;   $	��Top=�6O    J� RenderTransformOrigin$ 1.132,0.769&�6g   �� 5   
   $��Input scale��6   $
��Left=�6&   $��	48,50,0,0q�6A   $	��Top=�6T   $
��Bold"�6l   �� 5   
   $��Output scale��6   $
��Left=�6'   $��
236,50,0,0q�6B   $	��Top=�6V   $
��Bold"�6n   �� 5   
   -   5         ��Name$ tbOutputTemp��5      $
��Left=�6(   $��23��6C   $��199,184,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $��
212.00° F��6x   $	��Top=�6�   $��72��6�   �� 5   
   -   5        $��tbInputTemp��5   8   $
��Left=�6K   $��23��6f   $��
190,13,0,0q�6r   $
 Wrap=�6�   $��0��6�   $	��Top=�6�   $��72��6�   	� 5   
   -   5        $��rbInputFarenh��5       	� 	GroupName$ Input��6+   $��	Farenheit��6=   $
��Left=�6Q   $��
40,114,0,0q�6l   $	��Top=�6�   6�   	� 5   
   -   5        $��rbInputKelvin��5      $ Input��6+   $��Kelvin��6=   $
��Left=�6N   $��
40,141,0,0q�6i   $	��Top=�6}   6�   	� 5   
   -   5        $��rbOutputCelcius��5      $ Output��6-   $��Celcius��6@   $
��Left=�6R   $��
233,86,0,0q�6m   $	��Top=�6�   6�   	� 5   
   -   5        $��rbOutputFarenh��5      $ Output��6,   $��	Farenheit��6?   $
��Left=�6S   $��233,112,0,0q�6n   $	��Top=�6�    d� 	IsChecked$
 TrueY�6�   6�   	� 5   
   -   5        $��rbOutputKelvin��5      $ Output��6,   $��Kelvin��6?   $
��Left=�6P   $��233,139,0,0q�6k   $	��Top=�6�   6�   	� 5   
   -   5        $��rbInputCelcius��5      $ Input��6,   $��Celcius��6>   $
��Left=�6P   $��	40,88,0,0q�6k   $	��Top=�6~   $
 TrueY�6�   6�   5      5      