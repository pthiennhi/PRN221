   M S B A M L   `   `   `  ����J  FPhamThienNhiWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PhamThienNhiWPFPhamThienNhiWPF  5   	   -    'PhamThienNhiWPF.TransactionDetailWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PhamThienNhiWPF     5   	     � Title$  TransactionDetailWindow��5   	   $	��400��6)   $	��525��66   .��5	      � $	��400��6   $	��525��6   .+�5
   
   � 
�������$	��400��6"   $	��Top=�6/    � RowDefinitions 5      �� 5      $
��252* �6    .+�5      �� -   5         ��Name$ errormessage��5   S   $��20��6   $
��Left=�6$   $��
89,221,0,0q�6?   $	��Top=�6j   $	��338��6�    J� OpacityMask
 �<�����	#FFE5572C6�   �� 5      -   5        $ message��5   d   $��0��6   $
��Left=�6#   $��
89,234,0,0q�6>    �� Padding$ 0,0,0,0q�6R   
�������$	��Top=�6�   $	��338��6�    �� TextAlignment$ Center=�6�   �� 5      -   5        $��textBlockName��5   R   $��23��6   $
��Left=�6$   $��	89,43,0,0q�6?   $��	Car Name:��6g   $	��Top=�6x   $	��110��6�   �� 5      -   5        $��textBlockDescription��5   R   $��23��6   $
��Left=�6$   $��	89,73,0,0q�6?   $��Description:��6n   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockNumberOfDoors��5   S   $��23��6   $
��Left=�6$   $��
89,103,0,0q�6?   $��Number Of Doors:��6q   $	��Top=�6�   $	��110��6�   �� 5      -   5        $ textBlockSeatingCapacity��5   S   $��23��6   $
��Left=�6$   $��
89,133,0,0q�6?   $��Seating Capacity:��6u   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockFuelType��5   S   $��23��6   $
��Left=�6$   $��
89,163,0,0q�6?   $��
Fuel Type:��6l   $	��Top=�6~   $	��110��6�   �� 5      -   5        $��textBlockYear��5   S   $��23��6   $
��Left=�6$   $��
89,193,0,0q�6?   $��Year:��6h   $	��Top=�6u   $	��110��6�   �� 5      -	   5        $��textBlockManufacturer��5   S   $��23��6   $
��Left=�6$   $��
89,223,0,0q�6?   $��Manufacturer:��6p   $	��Top=�6�   $	��110��6�   �� 5      -
   5        $��textBlockSupplier��5   S   $��23��6   $
��Left=�6$   $��
89,253,0,0q�6?   $��	Supplier:��6l   $	��Top=�6}   $	��110��6�   �� 5      -   5        $$��textBlockCarRentingPricePerDay��5   S   $��23��6   $
��Left=�6$   $��
89,283,0,0q�6?   $��Price per day:��6y   $	��Top=�6�   $	��110��6�   �� 5      -   5         ��Name$ textBoxName��5   Q   $��23��6   $
��Left=�6"   $��
205,43,0,0q�6=   $	��Top=�6f   $	��222��6~   $��Center=�6�   �� 5      -   5        $ textBoxDescription��5   Q   $��23��6   $
��Left=�6"   $��
205,73,0,0q�6=   $	��Top=�6m   $	��222��6�   $��Center=�6�   �� 5      -   5        $ textBoxNumberOfDoors��5   R   $��23��6   $
��Left=�6"   $��205,103,0,0q�6=   $	��Top=�6p   $	��222��6�   $��Center=�6�   �� 5       -   5        $��textBoxSeatingCapacity��5    R   $��23��6   $
��Left=�6"   $��205,133,0,0q�6=   $	��Top=�6p   $	��222��6�   $��Center=�6�   �� 5!      -   5        $��textBoxFuelType��5!   R   $��23��6   $
��Left=�6"   $��205,163,0,0q�6=   $	��Top=�6i   $	��222��6�   $��Center=�6�   (  "System.Windows.Controls.DatePicker  5"      -   5        $��dpYear��5"   U   $��23��6   $
��Left=�6%   $��205,193,0,0q�6@   $	��Top=�6c   $��Center=�6|   �� 5#      -   5         ��Name$ cbManufacturer��5#      $��23��6/   $
��Left=�6;   $��205,223,0,0q�6V   $	��Top=�6k   $��Center=�6�   $	��222��6�   �� 5$      -   5        $ 
cbSupplier��5$      $��23��6+   $
��Left=�67   $��205,253,0,0q�6R   $	��Top=�6g   $��Center=�6�   $	��222��6�   �� 5%      -   5        $ textBoxPrice��5%   R   $��23��6   $
��Left=�6"   $��205,283,0,0q�6=   $	��Top=�6h   $	��222��6�   $��Center=�6�   �� 5'      -   5         ��Name$ 	btnUpdate��5'   b   $��Update��6   $��23��6&   $
��Left=�62   $��197,337,0,0q�6M   $	��Top=�6u   $��70��6�   $��Center=�6�   $y�Visible=�6�   	 J� RenderTransformOrigin$	 -0.611,2.706&�6�   �� 5(      -   5        $ 	btnCreate��5(   b   $��Create��6   $��23��6&   $
��Left=�62   $��197,337,0,0q�6M   $	��Top=�6u   $��70��6�   $��Center=�6�   $y�Visible=�6�   5)      5+      5,      