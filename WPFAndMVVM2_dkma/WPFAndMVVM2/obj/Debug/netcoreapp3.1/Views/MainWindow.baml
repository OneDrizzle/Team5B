   M S B A M L   `   `   `  ����F  BWPFAndMVVM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFAndMVVM2WPFAndMVVM2  5          WPFAndMVVM2.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      +localclr-namespace:WPFAndMVVM2     5        � Title$  
MainWindow��5	      $	��450��5
      $	��800��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �5      $	��200��5      �� 5      $��5 �5      �� 5      $��* �5      .+�5   
   � $��0��5       � RowDefinitions 5      �� 5      $	��10* �5      �� 5      $��* �5      .+�5      �� -   5        $��listBox��5      $��0��5       ��5!      �� *	PersonsVM+ �� SelectedItem 5"      �� *SelectedPersonViewModel+ �� UpdateSourceTrigger$ PropertyChanged=���5#      �� 5$      .R�5%      ��  �� Orientation$ 
Horizontal=�5&      .+�5'      �� ��5(   !   �� *	FirstName+�� 5)      ��5*   !   �� *
LastName+5+      5,      5.      �� 5/      $ 
Horizontal=�6   $��1��62   .+�50      �� -   5        $��btnNewPerson��51      $
��Left=�52      $	��New��53      54   2   �� 55      -   5        $��btnDeletePerson��56      $��Right=�57      $��Delete��58      59   5   5:      5;      �� 5=   
   $��5��5>      $��1��5?      $��Stretch=�5@      � 5A   
   $��2��5B      .+�5C      �� $��20��5E      $	��Top=�5F      $��170,62,171,0q�5G      ��5D      �� *#!SelectedPersonViewModel.FirstName+$ PropertyChanged=�5G      �� 5H      $��20��5J      $��170,109,171,0q�5K      $	��Top=�5L      ��5I      �� *" SelectedPersonViewModel.LastName+$ PropertyChanged=�5L      �� 5M      $��20��5O      $��170,158,171,0q�5P      $	��Top=�5Q      ��5N      �� *SelectedPersonViewModel.Age+$ PropertyChanged=�5Q      �� 5R      $��20��5T      $��170,204,171,0q�5U      $	��Top=�5V      ��5S      �� *SelectedPersonViewModel.Phone+$ PropertyChanged=�5V      �� 5W      $��
FirstName:��5X      $
��Left=�5Y      $��	67,59,0,0q�5Z      $	��Top=�5[      �� 5\      $��	LastName:��5]      $
��Left=�5^      $��
67,103,0,0q�5_      $	��Top=�5`      $��66��5a      �� 5b      $
��Age:��5c      $
��Left=�5d      $��
67,152,0,0q�5e      $	��Top=�5f      �� 5g      $��Phone:��5h      $
��Left=�5i      $��
67,204,0,0q�5j      $	��Top=�5k      5l      5m      5n      