   M S B A M L   `   `   `  ����D  @Day07Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Day07Cars	Day07Cars  5   	       Day07Cars.AddEditDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Day07Cars     5   	     � Title$  AddEditDialog��5   	   $��374.171��6   $��448.204��60    � 
ResizeMode$ NoResize=�6@   .��5	      � .+�5
   
   � .+�5      �� $��Make model:��6   $
��Left=�6*   $��
110,83,0,0q�6E   $	��Top=�6Y   �� 5      -   5        $��tbMakeModel��5      $
��Left=�6)   $��23��6D   $��
204,82,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5      $��Engine size:��6   $
��Left=�6+   $��110,124,0,0q�6F   $	��Top=�6[   �� 5       �� ContentStringFormat$ {0:0.0}��6v   $
��Left=�6�   $��187,124,0,0q�6�   $	��Top=�6�   ��6   ��  �� ElementName$ sliderEngineSize�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $��sliderEngineSize��5      $
��Left=�6-   $��118,155,0,0q�6H   $	��Top=�6]   $	��206��6u    �� TickFrequency$	 0.1Q�6�    � Value$	 1.9Q�6�   	 � Maximum$	 20Q�6�   �� 5      
 �� IsCancel
 . $��Cancel��6%   $
��Left=�66   $��121,262,0,0q�6Q   $	��Top=�6f   $��75��6~   �� 5      -   5        $��	btAddEdit��5   H    �� 	IsDefault . $��Create��6Y   $
��Left=�6j   $��242,261,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5      $��
Fuel type:��6   $
��Left=�6)   $��110,188,0,0q�6D   $	��Top=�6Y   �� 5      -   5        $��comboFuelType��5      $
��Left=�6,   $��187,192,0,0q�6G   $	��Top=�6\   $	��137��6t    �� SelectedIndex$ 0��6�   5      5      5      5      