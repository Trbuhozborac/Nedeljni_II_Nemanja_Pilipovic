   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   #    Zadatak_1.Views.MaintanceView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  	Maintance��5   	   $	��200��6   $	��270��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��btnCreateReport��5   .   $��1��6   $��1��6!   $��Create Maintance Report��6E   $��20��5      $	��150��6   $��Center=�6)   $��0,10,0,0q�5   W   ��6   �� *CreateReport+ �� UpdateSourceTrigger$ PropertyChanged=�6W   �� 5   
   $��1��6   $��2��6$   $��10(�61   $.��(*You can create just one report per day.��6?   $��0,10,0,0q�5      �� 5   
   -   5        $��	btnLogout��5   .   $��1��6   $��3��6!   $��Logout��6?   $��20��5       $	��100��6   $��Center=�6)   $��0,10,0,0q�5!   Q   ��6   �� *Logout+$ PropertyChanged=�6Q   5#      5$      