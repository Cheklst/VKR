   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ComputerShop.PagesComputerShop.Pages  5      -    'ComputerShop.Pages.ProductOperationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ComputerShop.Pages     5      -   5          N� Title$  ProductOperationPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��	lwProduct��5   �   $��5,5,5,5q�6   ��.  $��Disabled=�6J    �� SelectionMode$ Single=�6�   $��1q�6�   $��Hidden=�6�   $��16(�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6C   5      ��5      �� 5      .R�5      � $��30��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5       �� 5!      .+�5$      �� 
���   �$��1q�5%   !   $��4��5&   !   �� 5(      $��5q�69   $��Center=�6E   ��6    �� *Photo+6E   �� 5*      $��1��6$   $��Center=�65   ��5+      `� 5,   "    �� StringFormat$ 	{0} | {1}��6/   .1�5-   &   ��  �� Path$ Title�6.   �� 5.   &   $ ProductType.Title�6.   5/   #   51      �� 53      $��2��6$   $��Center=�6n   ��64   �� *Price+$ {0} руб. за шт.��6n   �� 55      $��3��6$   $��Количество:��64   $
��Left=�6H   $��Center=�6c   �� 57      -   5        $��3��57   "   $��
100,0,50,0q�6�   $��0q�6�   $��Center=�6�   ��62   �� *
Quantity+
	 � Tag	 6j   �� *	IdProduct+6�   59      5:      5<      �� 5>   
   -   5        
 ��Name$
 btnExit��5>      $��1��6"   $
��Left=�6/   $��5q�6J   $	��100��6U   $��50��6a      AdditionalColor#��[  6m   $��Отмена��6�   $��20(�6�   6�   �� 5@   
   -   5        $
 btnOperation��5@      $��1��6'   $��Right=�64   $��5q�6P   $	��100��6[   $��50��6g   #��[  6s   $��Оформить��6�   $��20(�6�   6�   5A      5B      