   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   )    #Zadatak_1.Views.CreateMaintanceView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$  Create Maintance��5   	   $	��600��6"   $	��275��6/   .��5	      �  � ColumnDefinitions 5
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
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $
��auto �6   �� 5(      $
��auto �6   �� 5)      $��20 �6   .+�5,   
   �� $��1��6   $��1��6$   $��Name:��61   �� 5-   
   -   5        $��1��5-      $��2��6"    �� 	MaxLength$ 20��5.   =   ��5-   /   �� *Maintance.Name+ �� UpdateSourceTrigger$ PropertyChanged=�5.   =   �� 50   
   $��1��6   $��3��6$   $��Surname:��61   $��0,10,0,0q�6A   �� 51   
   -   5        $��1��51      $��4��6"   $ 20��52   =   ��51   /   �� *Maintance.Surname+$ PropertyChanged=�52   =   �� 54   
   $��1��6   $��5��6$   $��Gender:��61   $��0,10,0,0q�6@   �� 55   
   -   5        $��	cbGenders��57      $��1��55      $��6��6#   $	��150��57   $   $��25��60    �� Text$ Choose Gender��6<    �� 
IsEditable . $��0,10,0,0q�6c   ��55   0   �� *	Genders+$ PropertyChanged=� �� SelectedValue 56      �� *Gender+$ PropertyChanged=�58      �� 5:   
   $��1��6   $��7��6$   $��ID Card Number:��61   $��0,10,0,0q�6H   �� 5;   
   -   5        $��1��5;      $��8��6"   $ 20��5<   =   ��5;   /   �� *Maintance.IDNumber+$ PropertyChanged=�5<   =   �� 5>   
   $��1��6   $��9��6$   $��Date Of Birth:��61   $��0,10,0,0q�6G   (  "System.Windows.Controls.DatePicker  5?   
   $��1��6   $��10��6%      SelectedDate 5@   
   �� *Maintance.DateOfBirth+$ PropertyChanged=��� 5B   
   $��1��6   $��11��6$   $��Citizenship:��62   $��0,10,0,0q�6F   �� 5C   
   -   5        $��1��5C      $��12��6"   $ 20��5D   =   ��5C   0   �� *Maintance.Citizenship+$ PropertyChanged=�5D   =   �� 5F   
   $��1��6   $��13��6$   $��	Username:��62   $��0,10,0,0q�6C   �� 5G   
   -   5        $��1��5G      $��14��6"   $ 20��5H   =   ��5G   0   �� *Maintance.Username+$ PropertyChanged=�5H   =   �� 5J   
   $��1��6   $��15��6$   $��	Password:��62   $��0,10,0,0q�6C   �� 5K   
   -   5        $��1��5K      $��16��6"   $ 20��5L   F   ��5K   0   �� *Maintance.Password+$ PropertyChanged=�5L   F   �� 5N   
   $��1��6   $��17��6$   $��Expand Clinic Permission��62   $��Center=�6R   $��0,10,0,0q�6o   �� 5O   
   $��1��6   $��18��6#   $��Center=�5Q      	 d� 	IsChecked	 5P      �� *" Maintance.ExpendClinicPermission+$ PropertyChanged=�5Q      �� 5S   
   $��1��6   $��19��6$   $#��In Charge of Disable Patients��62   $��Center=�6W   $��0,10,0,0q�6t   �� 5T   
   $��1��6   $��20��6#   $��Center=�5V      	 5U      �� *+)Maintance.InChargeOfDisabledPatientAccess+$ PropertyChanged=�5V      �� 5X   
   -   5        $��btnSave��5X   /   $��1��6   $��21��6!   $��Confirm��6>   $��20��6P   $	��100��6\   $��Center=�6h   $��0,10,0,0q�5Y   O   ��6   �� *Save+$ PropertyChanged=�6O   �� 5\   
   -	   5        $��btnClose��5\   /   $��1��6   $��22��6!   $��Close��6?   $��20��6O   $	��100��6[   $��Center=�6g   $��0,10,0,0q�5]   P   ��6   �� *Close+$ PropertyChanged=�6P   5_      5`      