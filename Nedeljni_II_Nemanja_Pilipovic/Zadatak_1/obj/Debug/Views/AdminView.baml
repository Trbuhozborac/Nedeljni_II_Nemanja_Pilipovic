   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	       Zadatak_1.Views.AdminView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Admin��5   	   $	��450��6   $
��1100��6$   .��5	      �  � ColumnDefinitions 5
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
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��btnUpdateHospital��5   .   $��1��6   $��1��6!   $ ��Update Medical Institution��6G   $��20��5       $	��200��6   $
��Left=�6)   $��0,10,0,0q�5!   Y   ��6   �� *UpdateHospital+ �� UpdateSourceTrigger$ PropertyChanged=�6Y   �� 5#   
   -   5        $��	btnLogout��5#   .   $��3��6   $��1��6!   $��Logout��6?   $��20��5$      $	��200��6   $��Right=�6)   $��	10,10,0,0q�5%   Q   ��6   �� *Logout+$ PropertyChanged=�6Q   �� 5(   
   $��1��6   $��2��6$   $��Clilnic Maintances��61   $��18(�6K   $
��Left=�6Y   $��0,10,0,0q�6t   �� 5)   
   -   5        $��btnCreateMaintance��5)   .   $��1��6   $��3��6!   $��Create Maintance��6H   $��20��5*      $	��200��6   $
��Left=�6)   $��0,10,0,0q�5+   Z   ��6   �� *CreateMaintance+$ PropertyChanged=�6Z   � 5-   
   $��1��6   $��4��6   $
��auto��6,   $
��auto��6:   $��3��6G   .+�5.      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAllMaintances��5.         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5/   )   $��0,10,0,0q�6D   ��5.   0   �� *AllMaintances+$ PropertyChanged=� �� SelectedItem 50      �� *	Maintance+$ PropertyChanged=�	   Columns	 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  53      $
 Surname��6)    6:   �� *	Surname+  54      $
 	ID Number��6)    6<   �� *
IDNumber+  55      $
 Gender��6)    69   �� *Gender+  56      $
 Date of Birth��6)    6@   �� *DateOfBirth+  57      $
 Citizenship ��6)    6?   �� *Citizenship+  58      $
 Username��6)    6;   �� *
Username+  59      $
 Password��6)    6;   �� *
Password+  5:      $'
 !Charge Of Disabled Patient Access��6)    6T   �� *!InChargeOfDisabledPatientAccess+  5;      $!
 Charge Of Ambulance Access ��6)    6N   �� *InChargeOfAmbulanceAccess+4  .System.Windows.Controls.DataGridTemplateColumn  5=         CellTemplate 5>      �� 5?      .R�5@   "   �� $��	btnUpdate��6)   $��Update��6:   $��4q�5C   %   $
��Bold"�60   ��5A   %   �� *DataContext.UpdateMaintance+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �5C   0   5D      5F        5I       5J      �� 5K      .R�5L   "   �� $��	btnDelete��6)   $��Delete��6:   $��4q�5O   %   $
��Bold"�60   ��5M   %   �� *DataContext.DeleteMaintance+$ PropertyChanged=� �� *FindAncestor+" �5O   0   5P      5R      5U      5V      �� 5X   
   $��1��6   $��5��6$   $��Clinic Managers��61   $
��Left=�6H   $��18(�6c   $��0,10,0,0q�6q   �� 5Y   
   -   5        $��btnCreateManager��5Y   .   $��1��6   $��6��6!   $��Create Manager��6F   $��20��5Z      $	��200��6   $
��Left=�6)   $��0,10,0,0q�5[   X   ��6   �� *CreateManager+$ PropertyChanged=�6X   � 5]   
   $��1��6   $��7��6   $
��auto��6,   $
��auto��6:   $��3��6G   .+�5^        -   5        $ dgAllManagers��5^       .   . $ Column=�5_   )   $��0,10,0,0q�6D   ��5^   .   �� *AllManagers+$ PropertyChanged=� 5`      �� *	Manager+$ PropertyChanged=�	 5a        5b      $

 Name��6)    67   �� *Name+  5c      $
 Surname��6)    6:   �� *	Surname+  5d      $
 	ID Number��6)    6<   �� *
IDNumber+  5e      $
 Gender��6)    69   �� *Gender+  5f      $
 Date of Birth��6)    6@   �� *DateOfBirth+  5g      $
 Citizenship ��6)    6?   �� *Citizenship+  5h      $
 Username��6)    6;   �� *
Username+  5i      $
 Password��6)    6;   �� *
Password+  5j      $
 Max Doctor Number��6)    6D   �� *MaxDoctorNumber+  5k      $
 Max Patient Number��6)    6E   �� *MaxPatientNumber+  5l      $
 Floor��6)    68   �� *Floor+  5n       5o      �� 5p      .R�5q   "   �� $��btnUpdateManager��6)   $��Update��6A   $��4q�5t   %   $
��Bold"�60   ��5r   %   �� *DataContext.UpdateManager+$ PropertyChanged=� �� *FindAncestor+" �5t   0   5u      5w        5y       5z      �� 5{      .R�5|   "   �� $��btnDeleteManager��6)   $��Delete��6A   $��4q�5   %   $
��Bold"�60   ��5}   %   �� *DataContext.DeleteManager+$ PropertyChanged=� �� *FindAncestor+" �5   0   5�      5�      5�      5�      5�      5�      