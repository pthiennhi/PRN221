   M S B A M L   `   `   `  ����J  FPhamThienNhiWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PhamThienNhiWPFPhamThienNhiWPF  5   	   (    "PhamThienNhiWPF.RegistrationWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PhamThienNhiWPF     5   	     � Title$  RegistrationWindow��5   	   $	��525��5	   	   $	��380��6    � WindowStartupLocation$ CenterScreen=�6#   .��5      � $	��380��6   $	��525��6   .+�5   
   � 
�������$	��320��6"   $	��Top=�6/    � RowDefinitions 5      �� 5      $
��252* �6    .+�5      �� -   5        $��LoginHeading��5   R   $��23��6   $
��Left=�6$   $��	10,10,0,0q�6?   $��	Register:��6f   $	��Top=�6w   $��17(�6�   $��ExtraCondensed&�6�   �� 5      -   5         ��Name$ errormessage��5   S   $��20��6   $
��Left=�6$   $��
89,221,0,0q�6?   $	��Top=�6j   $	��338��6�    J� OpacityMask
 �<�����	#FFE5572C6�   �� 5      -   5        $ message��5   d   $��0��6   $
��Left=�6#   $��
89,234,0,0q�6>    �� Padding$ 0,0,0,0q�6R   
�������$	��Top=�6�   $	��338��6�    �� TextAlignment$ Center=�6�   �� 5      -   5        $��textBlockName��5   R   $��23��6   $
��Left=�6$   $��	89,43,0,0q�6?   $��
Your Name:��6g   $	��Top=�6y   $	��110��6�   �� 5      -   5        $��textBlockEmail��5   R   $��23��6   $
��Left=�6$   $��	89,73,0,0q�6?   $��Your Email:��6h   $	��Top=�6{   $	��110��6�   �� 5      -   5        $��textBlockPhone��5   S   $��23��6   $
��Left=�6$   $��
89,103,0,0q�6?   $��
Your Phone��6i   $	��Top=�6{   $	��110��6�   �� 5      -   5        $ textBlockBirthday��5   S   $��23��6   $
��Left=�6$   $��
89,133,0,0q�6?   $��Your Birthday:��6n   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockPassword��5   S   $��23��6   $
��Left=�6$   $��
89,163,0,0q�6?   $��	Password:��6l   $	��Top=�6}   $	��110��6�   �� 5      -	   5        $��textBlockConfirmPassword��5   S   $��23��6   $
��Left=�6$   $��
89,193,0,0q�6?   $��Confirm Password:��6s   $	��Top=�6�   $	��110��6�   �� 5      -
   5         ��Name$ textBoxName��5   Q   $��23��6   $
��Left=�6"   $��
205,43,0,0q�6=   $	��Top=�6f   $	��222��6~   $��Center=�6�   6�   �� 5      -   5        $ textBoxEmail��5   Q   $��23��6   $
��Left=�6"   $��
205,73,0,0q�6=   $	��Top=�6g   $	��222��6   $��Center=�6�   6�   �� 5      -   5        $ textBoxPhone��5   R   $��23��6   $
��Left=�6"   $��205,103,0,0q�6=   $	��Top=�6h   $	��222��6�   $��Center=�6�   6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpBirthday��5      $��23��6-   $
��Left=�69   $��205,133,0,0q�6T   $	��Top=�6i   G� 5       -   5        $��passwordBox��5    V   $��23��6   $
��Left=�6&   $��205,163,0,0q�6A   $	��Top=�6i   $	��222��6�   $��Center=�6�   G� 5!      -   5        $��confirmPasswordBox��5!   V   $��23��6   $
��Left=�6&   $��205,193,0,0q�6A   $	��Top=�6p   $	��222��6�   $��Center=�6�   �� 5#      -   5        $��Submit��5#   b   $��Submit��6   $��23��6&   $
��Left=�62   $��197,260,0,0q�6M   $	��Top=�6p   $��70��6�   $��Center=�6�   6�   �� 5$      -   5        $��Reset��5$   a   $��Reset��6   $��23��6%   $
��Left=�61   $��277,260,0,0q�6L   $	��Top=�6n   $��70��6�   $��Center=�6�   6�   �� 5%      -   5        $��Cancel��5%   b   $��Cancel��6   $��23��6&   $��Right=�62   $��
0,260,98,0q�6N   $	��Top=�6p   $��70��6�   $��Center=�6�   6�   5&      �� 5'   
   -   5        $��textBlockHeading��5'   P   $��50��6   $��Center=�6    $��	0,305,0,0q�6=   $	��Top=�6h   $��12(�6�   $��Italic$�6�   $ 5q�6�   75Note: If you already have an account please click on �� 5)   
   �� 5*   
   -   5        	 ��Name$	 	linkLogin��5*      $��14(�6'   $��Normal$�65   .�6b   Login6i   5+      	 button5-   
   5.      5/      