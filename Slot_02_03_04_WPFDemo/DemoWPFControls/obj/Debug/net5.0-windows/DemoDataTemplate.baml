   M S B A M L   `   `   `  ����J  FDemoWPFControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DemoWPFControlsDemoWPFControls  5   	   &     DemoWPFControls.DemoDataTemplate   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DemoWPFControls     5   	     � Title$  DemoDataTemplate��5   	   $	��350��6"   $	��450��6/    � WindowStartupLocation$ CenterScreen=�6;    � 	Resources 5	         DemoWPFControls.Cars   CarList �� 
TargetType �� Property �� Value  CarDetailTemplate��%�  &	        '��      &	 �       5
   
   6   �� 5   
   " ��6   .�5      ��  � ��$ Verdana)�6+   �� 5       � ��$ 13(�6)   �� 5       � ��$ 10q�6(   5      �� 5   
   .R�5      �� .+�5      �� $��Italic$�6   ��6/   �� *	CarName+�� 5      ��6   �� *Color+�� 5      ��6   �� *Brand+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5    
   �� -   5         ��Name$ 	MyListBox��5    /   $��0��6   $��0��6   #��[ 5!      ��5    B   �� 	 �� Source#	 [  5!      �� 5"   
   -   5        
 ��Name$
 
MyComboBox��5"   <   $��0��6   $��70��6    $��1��6,   $	��Top=�5#      #��[ 5%      ��5$      �� #	 [  5%      5&      5'      