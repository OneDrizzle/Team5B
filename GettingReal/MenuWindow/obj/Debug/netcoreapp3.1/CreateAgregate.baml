   M S B A M L   `   `   `  ����E  AMenuWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MenuWindow
MenuWindow  5   	   $    MenuWindow.CreateAgregatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MenuWindow     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	      Icon � Icon# [  5
   	    � Title$ Bauer Ventilation��5   	   $	��450��6#   $	��500��60   .��5      � .+�5   
   �� $
��Left=�6   $��32(�6/   $��	90,70,0,0q�6=   $
��Wrap=�6P   $	��Top=�6d   $	��240��6|   $��44��6�   �� 6�    � Language$ da-dk�6�   $�Opret Aggregat��6�   6�   �� 5   
   $
��Left=�6   $
��Bold"�6/   $��
90,130,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $��86��6�   �� 6�   $ da-dk�6�   $�Kunde��6�   6�   �� 5   
   $
��Left=�6   $
��Bold"�6/   $��
90,185,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $��86��6�   �� 6�   $ da-dk�6�   $�Bygning��6�   6�   �� 5   
   $
��Left=�6   $
��Bold"�6/   $��
90,240,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $��86��6�   �� 6�   $ da-dk�6�   $�
Odrenummer��6�   6�   �� 5   
   $
��Left=�6   $
��Bold"�6/   $��
90,290,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $	��136��6�   $��23��6�   �� 6�   $ da-dk�6�   $�Datablad��6�   �� 6�   �� 6�   $ da-dk�6�   6�   �� 5   
   -   5         ��Name$ GetCustomer��5   t   $��0q�6    �� SelectedIndex$ 0��6�   $
��Left=�6�   $��
90,150,0,0q�6�   $	��Top=�6�   $	��272��6�   $��28��6�   ��6   ��  �� Path$ CustomersVM� �� SelectedItem 6H   �� *SelectedVMCustomer+��5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5      �� ��6    �� $ Company��� 5      ��6    �� $
 Name�5      5      5      �� 5    
   -   5        $ GetBuilding��5       $
��Left=�6(   $��
90,206,0,0q�6C   $	��Top=�6W   $	��272��6o   
 �� Text$
  ��6{   $��28��6�   �� 5!   
   -   5         ��Name$ GetOrderNumber��5!      $
��Left=�6*   $��
90,260,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��272��6�   $��20��6  ��6�   �� $ OrdreNumber� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5"   
   -   5        $ GetInfoSheet��5"      $
��Left=�6(   $��
90,310,0,0q�6C   $ WrapWithOverflow=�6W   $	��Top=�6w   $	��272��6�   $��20��6�   �� 5#   
   -   5         ��Name$ btn_AddCustomer��5#      $��Opret ny��6o   $
��Left=�6�   $��380,153,0,0q�6�   $	��Top=�6�   $��22��6�   $��55��6�   ��6*   �� $ NewCustomerCmd���6R   �� 6�   �� 5$   
   -   5        $ btn_AddBuilding��5$      $��Opret ny��6*   $
��Left=�6=   $��380,209,0,0q�6X   $	��Top=�6m   $��22��6�   $��55��6�   �� 5%   
   -   5        $ btn_FindAgregateInfoFile��5%      $
��Hent��63   $
��Left=�6B   $��380,309,0,0q�6]   $	��Top=�6r   $��22��6�   $��55��6�   �� 5(   
   -   5        $��btn_back��5(      $
��Left=�6!   $��	30,30,0,0q�6<   $	��Top=�6O   $��30��6g   $��30��6s   .��5)      ��   Back#��[ 6   $��26��63   $��26��6>   5*      �� 5+   
   -	   5        $ btn_saveNewAgregat��5+   #   ${�false��6   $	��Gem��6?   $
��Left=�6M   $��400,385,0,0q�6h   $	��Top=�6}   $��55��6�   $��22��6�   �� 5-   
     Logo#��[ 6   $
��Left=�6/   $��
350,30,0,0q�6K   $	��Top=�6_   $��40��6w   $	��120��6�   �� 5.   
   -
   5         ��Name$ 	lbl_Error��5.      $
��Left=�6[   $��
90,345,0,0q�6v   $	��Top=�6�   $��33��6�   $	��272��6�   ��6#   �� $ PropertyChanged=�6�   50      51      