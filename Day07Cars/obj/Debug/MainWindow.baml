   M S B A M L   `   `   `  ����D  @Day07Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Day07Cars	Day07Cars  5   	       Day07Cars.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Day07Cars     5   	   -   5          � Title$  
MainWindow��5   	   $	��414��6   $	��415��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� -   5        $��Export to CSV...��5      65   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      -   5        $	��Add��5      5      5      �� 5   
   $��Bottom=�6   .@�5      �� .��5      �� -   5        $��	statusBar��5      ��6.   ��  �� ElementName$ lstCars�� �� Path$ Items.Count� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$# You have {0} car(s) currently��5      5      �� 5   
   -   5        $��lstCars��5   D   $
��Left=�6S   $	��220��6n   $��	38,30,0,0q�6{   $	��Top=�6�   $	��330��6�    �� SelectionMode$ Single=�6�    � ContextMenu 5      �� 5      -   5        $��contMenu��5       �� 	StaysOpen . .@�5      m� -   5        $��	DeleteCar��5   /   $��Delete��6   6@   m� 5      -	   5        $��EditCar��5   -   $
��Edit��6   6<   5       �� View 5      �� 5       .P�5!      �� $��
Make model��6%   	 �� Width$		 110��69   
 �� DisplayMemberBinding
 6E   �� *	MakeModel+�� 5"      $��Engine size��6%   $		 110��6:   
 6F   �� *
EngineSize+$ {0:0.0}���� 5#      $��	Fuel Type��6%   $		 110��68   
 6D   �� *
FuelType+5$      5&      5'      5(      