   M S B A M L   `   `   `  ����L  HDay04WpfAllInputs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Day04WpfAllInputsDay04WpfAllInputs  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    Day04WpfAllInputs.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Day04WpfAllInputs     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
All Inputs��5	   	   $	��339��6   $	��395��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5
      � .+�5   
   �� $��Name:��6   $
��Left=�6    $��	43,22,0,0q�6;   $	��Top=�6N   �� 5   
   $
��Age:��6   $
��Left=�6   $��	43,67,0,0q�6:   $	��Top=�6M   �� 5   
   $��Pets:��6   $
��Left=�6    $��
43,117,0,0q�6;   $	��Top=�6O   �� 5   
   $��Continent of residence:��6   $
��Left=�62   $��
43,158,0,0q�6M   $	��Top=�6a   �� 5   
   $��Preferred temp C:��6   $
��Left=�6,   $��
43,200,0,0q�6G   $	��Top=�6[   �� 5   
   -   5         ��Name$ tbName��5      $
��Left=�6"   $��23��6=   $��	97,25,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��260��6�   	� 5   
   -   5         	�Name$ rbAgeBelow18��5      $��Below 18��6,   $
��Left=�6?   $��
106,73,0,0q�6Z   $	��Top=�6n    d� 	IsChecked$
 TrueY�6�   	� 5   
   -   5        $ 	rbAge1835��5      $��18-35��6)   $
��Left=�69   $��
193,73,0,0q�6T   $	��Top=�6h   	� 5   
   -   5        $ 	rbAge36Up��5      $��	36 and up��6)   $
��Left=�6=   $��
268,73,0,0q�6X   $	��Top=�6l   �� 5   
   $�� ��6   $
��Left=�6   $��49��68   $��	97,53,0,0q�6D   $	��Top=�6W   $	��260��6o   �� 5   
   -   5         ��Name$ 	cbPetsCat��5      $	��cat��6&   $
��Left=�64   $��106,123,0,0q�6O   $	��Top=�6d   �� 5   
   -   5        $ 	cbPetsDog��5      $	��dog��6&   $
��Left=�64   $��193,123,0,0q�6O   $	��Top=�6d   �� 5   
   -   5        $ cbPetsOther��5      $��other��6(   $
��Left=�68   $��306,123,0,0q�6S   $	��Top=�6h   �� 5   
   -   5         ��Name$ comboContinent��5      $
��Left=�6+   $��185,162,0,0q�6F   $	��Top=�6[   $	��172��6s   	 �� SelectedIndex$	 0��6   .@�5      �� $��America��6   �� 5      $��Africa��6   �� 5      $��Europe��6   �� 5      $
��Asia��6   �� 5      $��	Australia��6   5      �� 5   
   -	   5        
 ��Name$
 
sliderTemp��5      $
��Left=�6%   $��185,206,0,0q�6@   $	��Top=�6U   $	��169��6m    � Minimum$ 15Q�6y    � Maximum$ 35Q�6�    �� TickFrequency$ 5Q�6�    �� TickPlacement$ BottomRight=�6�    � Value$ 20Q�6�   �� 5    
   -
   5         ��Name$ 
btRegister��5    *   $��Register me��6>   $
��Left=�6T   $��150,259,0,0q�6o   $	��Top=�6�   $��75��6�   �� 5!   
   -   5        $��lblTemp��5!       �� ContentStringFormat$ {0:N0}��6}   $
��Left=�6�   $��151,200,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.026,-0.462&�6�   ��6    ��  �� ElementName$ 
sliderTemp�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   5#      5$      