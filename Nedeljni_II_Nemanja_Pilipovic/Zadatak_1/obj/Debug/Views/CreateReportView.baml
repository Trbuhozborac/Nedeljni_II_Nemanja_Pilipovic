   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   &     Zadatak_1.Views.CreateReportView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Report��5   	   $	��300��6   $	��275��6%   .��5	      �  � ColumnDefinitions 5
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
��auto �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6$   $��Total Time: -Minutes-��61   �� 5   
   -   5        $��1��5      $��2��6"    �� 	MaxLength$ 5��5   =   ��5   /   �� *Report.TotalTime+ �� UpdateSourceTrigger$ PropertyChanged=�5   =   �� 5!   
   $��1��6   $��3��6$   $��Decription:��61   $��0,10,0,0q�6D   �� 5"   
   -   5        $��1��5"      $��4��6"   $ 30��5#   F   ��5"   /   �� *Report.Description+$ PropertyChanged=�5#   F   �� 5%   
   -   5        $��btnSave��5%   .   $��1��6   $��5��6!   $��Confirm��6=   $��20��6O   $	��100��6[   $��Center=�6g   $��0,10,0,0q�5&   O   ��6   �� *Save+$ PropertyChanged=�6O   �� 5)   
   -   5        $��btnClose��5)   .   $��1��6   $��6��6!   $��Close��6>   $��20��6N   $	��100��6Z   $��Center=�6f   $��0,10,0,0q�5*   P   ��6   �� *Close+$ PropertyChanged=�6P   5,      5-      