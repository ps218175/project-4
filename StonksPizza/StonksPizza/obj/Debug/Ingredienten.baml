   M S B A M L   `   `   `  ����F  BStonksPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StonksPizzaStonksPizza  5   	       StonksPizza.Ingredienten   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:StonksPizza     5   	     � Title$  Ingredienten��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��10* �6   6-   �� 5      $	��15* �6   6-    � RowDefinitions 5   
   �� 5      $��4* �6   6*   �� 5      $	��30* �6   6+   �� 5      $��4* �6   6*   �� 5      $	��29* �6   6+   .+�5   
   �� -   5         ��Name$ 	lijstIngr��5      $��18(�5   b   $��0��6p   $��1��6�   ��6   �� *
Ingredient+ �� SelectedItem 65   �� *SelectedIngredient+��5      �� 5      .R�5      ]� $	��200��6    .+�5      �� $
��Left=�6?   ��6$   �� *	naam_ingr+6?   5      5      5       �� 5!   
   $��1��6   $��1��6%    � DataContext 62   �� *UpdateIngredient+.+�5#      �� -   5         ��Name$ id��5#      $	��300��6"   $
��Left=�6.   ��6I   �� *id+�� 5$      -   5        $
 naam��5$      $	��300��6$   $
��Left=�60   ��6K   �� *	naam_ingr+�� 5%      -   5        $
 unit��5%      $	��300��6$   $
��Left=�60   ��6K   �� *unit+�� 5&      -   5        $ prijs��5&      $	��300��6%   $
��Left=�61   ��6L   �� *
prijs_ingr+�� 5'       �� Orientation$ 
Horizontal=�6   .+�5(      �� -   5        $
��Save��5(       �� 	IsDefault . $��75��6O   �� 5)      -   5        $��Delete��5)      
���  �� . $��75��6c   5*      5+      �� 5,   
   $��img/logo.png��6   $��0��6&   $��4��66   $	��150��6C   6Q   �� 5-   
   $	��300��6   $
��Left=�6!   $��1��6b   $��3��6r    6<   �� *NewIngredient+.+�5.      �� $	��Id:��6   �� 5/      ��6   �� *id+�� 50      $��Naam:��6   �� 51      ��6   �� *	naam_ingr+�� 52      $��unit:��6   �� 53      ��6   �� *unit+�� 54      $��prijs:��6   �� 55      ��6   �� *
prijs_ingr+�� 59      $ 
Horizontal=�6   .+�5:      �� -   5        $
��Save��5:       . $��75��6N   5<      5?      5@      5A      