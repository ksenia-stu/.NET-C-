   M S B A M L   `   `   `  ����L  HQuiz3FinalFlights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Quiz3FinalFlightsQuiz3FinalFlights  5   	   %    Quiz3FinalFlights.AddEditDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Quiz3FinalFlights     5   	     � Title$  AddEditDialog��5   	   $	��368��6   $	��302��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterOwner=�6N   .��5	      � .+�5
   
   �� $	��Id:��6   $
��Left=�6   $��	43,21,0,0q�69   $	��Top=�6L   �� 5   
   -   5        $��lblId��5      $��.��6   $
��Left=�6)   $��	79,21,0,0q�6D   $	��Top=�6W   �� 5   
   $��Date:��6   $
��Left=�6    $��	43,51,0,0q�6;   $	��Top=�6N   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDate��5      $
��Left=�6#   $��	85,53,0,0q�6>   $	��Top=�6Q   $	��152��6i   �� 5   
   $��
From code:��6   $
��Left=�6%   $��	43,85,0,0q�6@   $	��Top=�6S   �� 5   
   -   5        $��
tbFromCode��5      $
��Left=�6$   $��23��6?   $��
117,88,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   $��To code:��6   $
��Left=�6#   $��
43,121,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ tbToCode��5      $
��Left=�6$   $��23��6?   $��117,124,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $��	comboType��5      $
��Left=�6$   $��
43,165,0,0q�6?   $	��Top=�6S   $	��194��6k    �� SelectedIndex$ 0��6w   �� 5   
   -   5        $��sliderPassengers��5      $
��Left=�6)   $��
43,210,0,0q�6D   $	��Top=�6X   $	��194��6p    � Value$ 37Q�6|    � Maximum$	 200Q�6�    �� IsSnapToTickEnabled . 6�   �� 5   
   $��passengers:��6   $
��Left=�6&   $��
43,228,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $��lblPassengers��5      	 �� ContentStringFormat$	 {0:0}��6�   $
��Left=�6�   $��121,228,0,0q�6�   $	��Top=�6�   ��6%   �� 
 �� ElementName$
 sliderPassengers�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $��btCancel��5      $��Cancel��6!    �� IsCancel . $
��Left=�6B   $��
52,272,0,0q�6]   $	��Top=�6q   $��75��6�   �� 5   
   -	   5        $��btCreateEdit��5   ,   $��Create��6@    �� 	IsDefault . $
��Left=�6b   $��152,272,0,0q�6}   $	��Top=�6�   $��75��6�   5      5      