   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   !    Zadatak_1.Views.ManagerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Manager��5   	   $	��400��6   $
��1000��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��btnCreateDoctor��5   .   $��1��6   $��1��6!   $��Create Doctor��6E   $��20��5      $	��150��6   $
��Left=�6)   $��0,10,0,0q�5   W   ��6   �� *CreateDoctor+ �� UpdateSourceTrigger$ PropertyChanged=�6W   �� 5!   
   -   5        $��	btnLogout��5!   .   $��3��6   $��1��6!   $��Logout��6?   $��20��5"      $	��150��6   $��Right=�6)   $��0,10,0,0q�5#   Q   ��6   �� *Logout+$ PropertyChanged=�6Q   �� 5%   
   $��2��6   $��3��6$   $��Your Doctors��61   $��18(�6E   $��Center=�6S   � 5'   
   $��1��6   $��4��6   $
��auto��6,   $
��auto��6:   $��3��6G   $��0,5,0,0q�6\   .+�5(      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAllDeoctors��5(         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5)   )   $��0,10,0,0q�6D   ��5(   .   �� *
AllDoctors+$ PropertyChanged=� �� SelectedItem 5*      �� *Doctor+$ PropertyChanged=�	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  5-      $
 Surname��6)    6:   �� *	Surname+  5.      $
 	ID Number��6)    6<   �� *
IDNumber+  5/      $
 Gender��6)    69   �� *Gender+  50      $
 Date of Birth��6)    6@   �� *DateOfBirth+  51      $
 Citizenship ��6)    6?   �� *Citizenship+  52      $
 Username��6)    6;   �� *
Username+  53      $
 Password��6)    6;   �� *
Password+  54      $
 Unique Number��6)    6@   �� *UniqueNumber+  55      $
 Account Number��6)    6A   �� *AccountNumber+  56      $
 
Department��6)    6=   �� *
Department+  57      $
 Shift��6)    68   �� *Shift+4  .System.Windows.Controls.DataGridTemplateColumn  59         CellTemplate 5:      �� 5;      .R�5<   "   �� $��	btnUpdate��6)   $��Update��6:   $��4q�5?   %   $
��Bold"�60   ��5=   %   �� *DataContext.UpdateDoctor+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �5?   0   5@      5B      5D      5E      5G      5H      