   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	        Zadatak_1.Views.DoctorView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  
DoctorView��5   	   $	��300��6   $	��500��6)    � 	Resources 5
          booleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6$   $(��"Your Patients Examination Requests��61   $��18(�6[   $
��Left=�6i   $��0,10,0,0q�6�   � 5!   
   $��1��6   $��2��6   $
��auto��6,   $
��auto��6:   $��3��6G   .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAllMaintances��5"         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5#   )   $��0,10,0,0q�6D   ��5"   0   �� *
Patients+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedItem	 5$      �� *	Patient+$ PropertyChanged=�
   Columns
 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+  5'      $ Surname��6)    6:   �� *	Surname+  5(      $ Gender��6)    69   �� *Gender+  5)      $ Date of Birth��6)    6@   �� *DateOfBirth+4  .System.Windows.Controls.DataGridTemplateColumn  5+         CellTemplate 5,      �� 5-      .R�5.   "   �� $��
btnExamine��6)   $��Examine��6;   $��4q�51   %   $
��Bold"�60   ��5/   %   �� *DataContext.Examine+$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType" �51   0   52      54      57      58      �� 5:   
   $��1��6   $��3��6$   $��15(�6x   $��Center=�6�   $��0,10,0,0q�6�   ��61   �� *ProggressBarText+$ PropertyChanged=�6�   � 5;   
   $��1��6   $��4��6&   $��50��63   $	��217��6?    � Value 6K   �� *ProgressBar+ �� Mode$ OneWay=�y�5<      �� *
Visibility+ �� 	Converter# [  �� 5>   
   -   5        $��	btnLogout��5>   .   $��1��6   $��5��6!   $��Logout��6?   $��20��5?      $	��150��6   $��Center=�6)   $��0,10,0,0q�5@   Q   ��6   �� *Logout+$ PropertyChanged=�6Q   5B      5C      