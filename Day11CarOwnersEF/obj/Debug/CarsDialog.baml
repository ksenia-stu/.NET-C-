   M S B A M L   `   `   `  ����K  GDay11CarOwnersEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Day11CarOwnersEFDay11CarOwnersEF  5   	   !    Day11CarOwnersEF.CarsDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Day11CarOwnersEF     5   	     � Title$  
CarsDialog��5   	   $	��273��6   $	��656��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterOwner=�6K   .��5	      � .+�5
   
   �� -   5        $��lstCars��5
   ?   $
��Left=�6N   $	��160��6i   $��	37,37,0,0q�6v   $	��Top=�6�   $	��225��6�    �� View 5      �� 5      .P�5      �� $��#��6%    �� Width$ 60��60    �� DisplayMemberBinding 6;   �� *Id+�� 5      $��Make & Model��6%   $	 160��6?    6K   �� *	MakeModel+5      5      �� 5   
   $��Owner name:��6   $
��Left=�6&   $��
313,37,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $��lblOwnerName��5      $	��...��6$   $
��Left=�62   $��
390,37,0,0q�6M   $	��Top=�6a   �� 5   
   $	��Id:��6   $
��Left=�6   $��
313,74,0,0q�69   $	��Top=�6M   �� 5   
   -   5        $��lblCarId��5      $	��...��6    $
��Left=�6.   $��
344,74,0,0q�6I   $	��Top=�6]   �� 5   
   $��Make & Model:��6   $
��Left=�6,   $��313,118,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $��tbMakeModel��5      $
��Left=�6%   $��23��6@   $��410,122,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��168��6�   �� 5   
   -   5        $��btAddCar��5   (   $	��Add��68   $
��Left=�6F   $��318,173,0,0q�6a   $	��Top=�6v   $��75��6�   �� 5   
   -   5         ��Name$ btUpdateCar��5   +   $��Update��6@   $
��Left=�6Q   $��412,173,0,0q�6l   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $ btDeleteCar��5   +   $��Delete��6@   $
��Left=�6Q   $��503,173,0,0q�6l   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $ btDone��5   &   $
��Done��66    �� 	IsDefault . $
��Left=�6V   $��
542,22,0,0q�6q   $	��Top=�6�   $��75��6�   5      5      