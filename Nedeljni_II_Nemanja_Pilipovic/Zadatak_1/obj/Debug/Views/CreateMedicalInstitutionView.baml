   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	   2    ,Zadatak_1.Views.CreateMedicalInstitutionView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$   Create Medical Institution��5   	   $	��600��6,   $	��260��69   .��5	      �  � ColumnDefinitions 5
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
   �� $��1��6   $��0��6$   $'��!*First you Must create instution.��61   $��10(�6Z   �� 5.   
   $��1��6   $��1��6$   $��Name:��61   $��0,10,0,0q�6>   �� 5/   
   -   5        $��1��5/      $��2��6"    �� 	MaxLength$ 20��50   =   ��5/   /   �� *Institution.Name+ �� UpdateSourceTrigger$ PropertyChanged=�50   =   �� 52   
   $��1��6   $��3��6$   $��Construction Date:��61   $��0,10,0,0q�6K   (  "System.Windows.Controls.DatePicker  53   
   $��1��6   $��4��6%      SelectedDate 54   
   �� *Institution.ConstructionDate+$ PropertyChanged=��� 56   
   $��1��6   $��5��6$   $��Owner:��61   $��0,10,0,0q�6?   �� 57   
   -   5        $��1��57      $��6��6"   $ 20��58   =   ��57   /   �� *Institution.Owner+$ PropertyChanged=�58   =   �� 5:   
   $��1��6   $��7��6$   $��Address:��61   $��0,10,0,0q�6A   �� 5;   
   -   5        $��1��5;      $��8��6"   $ 30��5<   F   ��5;   /   �� *Institution.Address+$ PropertyChanged=�5<   F   �� 5>   
   $��1��6   $��9��6$   $��Floors Number:��61   $��0,10,0,0q�6G   �� 5?   
   -   5        $��1��5?      $��10��6"   $ 3��5@   =   ��5?   0   �� *Institution.FloorsNumber+$ PropertyChanged=�5@   =   �� 5B   
   $��1��6   $��11��6$   $��Persons Per Floor:��62   $��0,10,0,0q�6L   �� 5C   
   -   5        $��1��5C      $��12��6"   $ 3��5D   =   ��5C   0   �� *Institution.PersonsPerFloor+$ PropertyChanged=�5D   =   �� 5F   
   $��1��6   $��13��6$   $��Terrace��62   $��Center=�6A   $��0,10,0,0q�6^   �� 5G   
   $��1��6   $��14��6#   $��Center=�5H       d� 	IsChecked 5G   2   �� *Institution.Terrace+$ PropertyChanged=�5H      �� 5J   
   $��1��6   $��15��6$   $
��Yard��62   $��Center=�6>   $��0,10,0,0q�6[   �� 5K   
   $��1��6   $��16��6#   $��Center=�5L       5K   1   �� *Institution.Yard+$ PropertyChanged=�5L      �� 5N   
   $��1��6   $��17��6$   $��Ambulance Access Points:��62   $��0,10,0,0q�6R   �� 5O   
   -   5        $��1��5O      $��18��6"   $ 3��5Q   =   ��5P      �� *(&Institution.AmbulanceAccessPointNumber+$ PropertyChanged=�5Q   =   �� 5S   
   $��1��6   $��19��6$   $%��Disabled Patient Access Points:��62   $��0,10,0,0q�6Y   �� 5T   
   -   5        $��1��5T      $��20��6"   $ 3��5V   =   ��5U      �� */-Institution.DisabledPatitentAccessPointNumber+$ PropertyChanged=�5V   =   �� 5X   
   -   5        $��btnSave��5X   /   $��1��6   $��21��6!   $��Confirm��6>   $��20��6P   $	��100��6\   $��Center=�6h   $��0,10,0,0q�5Y   O   ��6   �� *Save+$ PropertyChanged=�6O   �� 5\   
   -	   5        $��btnClose��5\   /   $��1��6   $��22��6!   $��Close��6?   $��20��6O   $	��100��6[   $��Center=�6g   $��0,10,0,0q�5]   P   ��6   �� *Close+$ PropertyChanged=�6P   5_      5`      