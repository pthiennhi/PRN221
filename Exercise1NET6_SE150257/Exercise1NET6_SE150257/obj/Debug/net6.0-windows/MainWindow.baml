   M S B A M L   `   `   `  ����Q  MExercise1NET6_SE150257, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Exercise1NET6_SE150257Exercise1NET6_SE150257  5   	   '    !Exercise1NET6_SE150257.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Exercise1NET6_SE150257     5   	   -   5          �Name$  
frmProduct��5   	    � Title$ 
MainWindow��5   	   $	��800��6   $	��750��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��400 �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��500 �6   .+�5   
   �� $��0��6   $��1��6   $��Product Management��6-   $��20(�6J   $��DemiBold"�6X   �� 5   
   -   5         ��Name$ LabelProductID��5   .   $��1��6   $��0��6   $��
Product ID��6F   $��16(�6[   �� 5   
   -   5        $ LabelProductName��5   -   $��2��6   $��0��6   $��Product Name��6G   $��16(�6^   �� 5    
   -   5        $ 
LabelPrice��5    -   $��3��6   $��0��6   $��Price��6A   $��16(�6Q   �� 5"   
   -   5        $ LabelUnitsInStock��5"   -   $��4��6   $��0��6   $��Units In Stock��6H   $��16(�6b   �� 5$   
   -   5        $ LabelCategory��5$   -   $��5��6   $��0��6   $��Category��6D   $��16(�6X   �� 5&   
   -   5         ��Name$ txtProductID��5&   /   $��1��6   $��1��6   $��30��6F   $��Center=�6~   $��Center=�6�   �� 5(   
   -   5        $ txtProductName��5(   /   $��2��6   $��1��6   $��30��6G   $��Center=�6T   $��Center=�6v   �� 5*   
   -	   5        $ txtPrice��5*   0   $��3��6   $��1��6    $��30��6B   $��Center=�6z   $��Center=�6�   �� 5,   
   -
   5        $ txtUnitsInStock��5,   0   $��4��6   $��1��6    $��30��6I   $��Center=�6�   $��Center=�6�   �� 5.   
   -   5         ��Name$ 
cbCategory��5.      $��5��6@   $��1��6M   $��30��6]   $��Center=�6i   $��Center=�6�   ��6'   �� 6�   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ dgvProducts��50      $��1��6(   $��5��68      AutoGenerateColumns$
 True��6E   $��0,36,0,0q�6�   $��2��6�   ��6`   �� 	 � DataContext	 6x   �� 6�   � 52   
   $��1��6   $��7��6    $��Center=�6-   $��0,10,0,0q�6H    53      �� 54      $
��Auto �6#   �� 55      $
��Auto �6#   �� 56      $
��Auto �6#   �� 57      $
��Auto �6#    59      �� 5:      $
��Auto �6    .+�5<      �� -   5        $��0��5<      $��Create��6%   $��	30,5,30,5q�66   $��	20,0,10,0q�6J   6]   �� 5=      $��1��6   $
��Save��6%   $��	30,5,30,5q�65   $��0,0,10,0q�6I   �� 5>      $��2��6   $��Update��6%   $��	30,5,30,5q�67   $��0,0,10,0q�6K   �� 5?      $��3��6   $��Delete��6%   $��	30,5,30,5q�67   $��0,0,10,0q�6K   5@      5A      5B      