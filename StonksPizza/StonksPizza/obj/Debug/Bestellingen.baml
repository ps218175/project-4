   M S B A M L   `   `   `  ����F  BStonksPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StonksPizzaStonksPizza  5   	       StonksPizza.Bestellingen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:StonksPizza     5   	     � Title$  Bestellingen��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ lijstbestelling��5
      $��18(�5   `   $��10,10,515.6,10q�6n   ��6   �� *
Bestelling+ �� SelectedItem 64   �� *SelectedBestelling+��5      �� 5      .R�5      ]� $	��200��6    .+�5      �� $��5q�6?   $
��Left=�6J   ��6$   �� *	last_name+6J   �� 5      $��5q�6?   $
��Left=�6J   ��6$   �� *	Bestel_Id+6J   �� 5      $��5q�6<   $
��Left=�6G   ��6$   �� *status+6G   5      5      5      �� 5   
   $��283,0,-0.4,0q�6>    � DataContext 6   �� *UpdateBestelling+.+�5      �� -   5         ��Name$ 	Status_Id��5      $	��300��6*   $
��Left=�66    �� DisplayMemberPath 6Q   �� *	Status_Id+.@�5      �� -   5         ��Name$ a��5      .��6*   Wordt bereid68   �� 5      -   5        $ b��5      .��6*   
In de Oven66   �� 5      -   5        $ c��5      .��6*   
Onderweg64   �� 5      -   5        $ d��5      .��6*   	Bezorgd63   5       �� 5"       �� Orientation$ 
Horizontal=�6   .+�5#      �� -   5        $
��Save��5#       �� 	IsDefault . $��75��6O   5%      5&      5'      5(      