   M S B A M L   `   `   `  ����L  HQuiz3FinalFlights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Quiz3FinalFlightsQuiz3FinalFlights  5   	   "    Quiz3FinalFlights.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Quiz3FinalFlights     5   	     � Title$  
MainWindow��5   	   $	��330��6   $	��668��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� -   5        $��Save selected��5      62   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      -   5        $	��Add��5      5      5      �� 5   
   $��Bottom=�6   .@�5      �� .��5      �� -   5        $��	statusBar��5      ��6.   ��  �� ElementName$ 
lstFlights�� �� Path$ Items.Count� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ Total flights: {0}��5      5      �� 5   
   -   5        $��
lstFlights��5   v   $
��Left=�6�   $	��220��6�   $��	38,30,0,0q�6�   $	��Top=�6�   $	��583��6�    �� SelectionMode$ Multiple=�6�    � ContextMenu 5      �� 5      -   5        $��contMenu��5       �� 	StaysOpen . .@�5      m� -   5        $��DeleteFlight��5   /   $��Delete��6   6C   5       �� View 5      �� 5      .P�5       �� $��Id��6%   	 �� Width$	 60��61   
 �� DisplayMemberBinding
 6<   �� *Id+�� 5!      $
��Date��6%   $		 120��63   
 6?   �� *Date+$ d���� 5"      $��	From code��6%   $	 90��68   
 6C   �� *
FromCode+�� 5#      $��To code��6%   $	 90��66   
 6A   �� *ToCode+�� 5$      $
��Type��6%   $		 130��63   
 6?   �� *Type+�� 5%      $��
Passengers��6%   $	 90��69   
 6D   �� *
Passengers+5&      5(      5)      5*      