   M S B A M L   `   `   `  ����C  ?FDPortal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FDPortal.View.UserControlsFDPortal.View.UserControls  5   	   7 clr-namespace:FDPortal.ViewModelFDPortal.ViewModel  5   	       FDPortal.View.LoginView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7uc(clr-namespace:FDPortal.View.UserControls     5   	   6	viewModel clr-namespace:FDPortal.ViewModel     5   	   -   5           LoginWindow#��[  5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � DataContext 5      '   !FDPortal.ViewModel.LoginViewModel  5   
    � 	Resources 5        BooleanToVisibility��%   &	       �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [ 65   .��5      ��   LoginWindowBorder#��[ 6   ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5!      �� $��0��6     SecondaryColor#��[ 6"    �� CornerRadius$ 	30 30 0 0��6O   ._�5"      �  � ColumnDefinitions 5#      �� 5$      $
��auto �6+   �� 5%      $��* �6+   .+�5(      � $��0��6   .+�5)      �� 	 �� Orientation$	 
Horizontal=�6%   $
��Left=�6>   $	��Top=�6Y   $��30 15q�6q   .+�5*      A� -   5        
 A�Name$
 CloseButton��5*   &     menuBase#��[ 6;     CloseColorEllipse#���  6]   6�   A� 5+      -   5        $
 MinimizeButton��5+   &   #��[ 6>     MinimizeColorELlipse#���  6`   $	��7 0q�6�   6�   A� 5,      -   5        $
 MaximizeButton��5,   &   #��[ 6>     MaximizeColorEllipse#���  6`   6�   5-      5.      � 50      $��1��6   $
��30 0q�6+   .+�51      �� $��LOGIN��6$     HeadingThree#��[ 61   $��Right=�6W   $��Center=�6s   52      53      54      � 56      $��1��6   .+�57      �� $	 Vertical=�6   $��Center=�64   $��0 15 0 0q�6Q   .+�58      �� $��/View/Images/BW_Large.png��6   $	��100��6?   �� 59      $��Front Desk Portal��6     	 
HeadingOne#��[	 69   $��Center=�6]   �� 5:      $
��0 15q�6    #���  6.   -   'FDPortal.View.UserControls.InputTextBox  5;         Title$ Username��6&      Text 67   �� *
Username+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�1   +FDPortal.View.UserControls.InputPasswordBox  5<         Title$ Password��6*      Password 6;   �� *
Password+$ TwoWay=�$ PropertyChanged=��� 5>      #��[ 6K    
 PrimaryError#��� 
 6q   $��Center=�6�   $
��Wrap=�6�   ��6    �� *ErrorMessage+$ TwoWay=�6�   ,   &FDPortal.View.UserControls.InputButton  5@         Command 6%   �� *LoginCommand+5A      5B      5C      5D      5E      