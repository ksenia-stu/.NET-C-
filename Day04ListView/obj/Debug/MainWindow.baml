   M S B A M L   `   `   `  ����H  DDay04ListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Day04ListViewDay04ListView  5   	       Day04ListView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Day04ListView     5   	     � Title$  People��5   	   $	��302��6   $	��499��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G   .��5	      � .+�5
   
   �� $��Name:��6   $
��Left=�6    $��
257,28,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $��tbName��5      $
��Left=�6    $��23��6;   $��
306,31,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��148��6�   �� 5   
   $
��Age:��6   $
��Left=�6   $��
257,68,0,0q�6:   $	��Top=�6N   �� 5   
   -   5        $��	sliderAge��5      $
��Left=�6"   $��
325,73,0,0q�6=   $	��Top=�6Q   $	��129��6i    � Value$ 20Q�6u    � Maximum$	 150Q�6�   �� 5   
   -   5        $��lblAge��5       �� ContentStringFormat$ {0:N0}��6y   $
��Left=�6�   $��
290,68,0,0q�6�   $	��Top=�6�   ��6   ��  �� ElementName$ 	sliderAge�� �� Path$ Value�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5   
   -   5        $	��Add��5   *   $
��Left=�68   $��315,119,0,0q�6S   $	��Top=�6h   $��75��6�   �� 5   
   -   5        $��Update��5   -   $
��Left=�6>   $��315,153,0,0q�6Y   $	��Top=�6n   $��75��6�   �� 5   
   -   5        $��Delete��5   -   $
��Left=�6>   $��315,186,0,0q�6Y   $	��Top=�6n   $��75��6�   �� 5   
   -   5        $��	lstPeople��5   A   $
��Left=�6R   $	��195��6m   $��	32,31,0,0q�6z   $	��Top=�6�   $	��182��6�   
 �� SelectionMode$
 Single=�6�   .@�5      �� ���	#FFD6AFAF$��Pristina)�6.   5      5      5      5      