   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ComputerShop.PagesComputerShop.Pages  5      $    ComputerShop.Pages.HistoryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ComputerShop.Pages     5      -   5          N� Title$  HistoryPage��5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgHistory��5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .     
IsReadOnly .    AlternatingRowBackground
 �����$��12(�6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$#
 Название товара��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	Product+  5      $
 Тип товара��6%    69   �� *ProductType+  5      $
 Статус товара��6%    6<   �� *InSale+  5      $
 Кол-во��6%    65   �� *
Quantity+ �� StringFormat$ 	{0} шт.��  5      $
 Работник��6%    5      `� 5      $ {0} {1} {2}��6'   .1�5      ��  �� Path$ LastName�6&   �� 5      $ 	FirstName�6&   �� 5      $ 
MiddleName�6&   5      5        5      $%
 Статус работника��6%    6?   �� *EmployeeStatus+  5      $
 Тип работника��6%    6<   �� *EmployeeType+  5       $
 Дата��6%    63   �� *Date+5"      5#      5$      