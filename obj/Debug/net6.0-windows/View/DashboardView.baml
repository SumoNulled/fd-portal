   M S B A M L   `   `   `  ����C  ?FDPortal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FDPortal.ViewModelFDPortal.ViewModel  5      G(clr-namespace:FDPortal.View.UserControlsFDPortal.View.UserControls  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      !    FDPortal.View.DashboardView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6	viewModel clr-namespace:FDPortal.ViewModel     5      7uc(clr-namespace:FDPortal.View.UserControls     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      @lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf   5	      -   5        $��	dashboard��5        � DataContext  5      +   %FDPortal.ViewModel.DashboardViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   � $��0��6   $��0 0 15 0q�6   .+�5       �� $	��5 0q�6   .+�5!      %   FDPortal.View.UserControls.Card     Number$ 82��6      Title$ Total In-House Guests��6&      IsTechnical$
 True��6D     5"      $ 11��6   $ Total Rooms Available��6&   $
 True��6D     5#      $ 9��6   $ Total Clocked In��6%   $
 True��6>   5$      5%      � 5'   
   $��1��6   $��0 0 15 0q�6   .+�5(      �� $��5 0 14 0q�6   .+�5)        $ 9��6   $ Total Arrivals��6%   $
 True��6<     5*      $ 32��6   $ Total Departures��6&   $
 True��6?     5+      $ 2��6   $ Total On-Call��6%   $
 True��6;   5,      5-      �� 5/   
   $��2��6   $��3��6!      InfoCardBase#��[  62    �� CornerRadius$ 10��6X   $��Stretch=�6j   ._�50      �  51      �� 52      $��* �6$   �� 53      $
��auto �6$   .+�56      � $��0��6   .+�57      &   System.Windows.Controls.DataGrid  -   5          Name$ employeesDataGrid��57        ClockInDataGrid#��[ 6:      SelectionMode$ Extended=�6c   	   SelectionUnit$	 FullRow=�6|   
   FrozenColumnCount$
 1��58         AutoGenerateColumns$ False��65   $
��auto��6Q      GridLinesVisibility$
 None=�59         
IsReadOnly$
 True��6:    �� SelectedItem 6L   �� *SelectedGridItem+5;      5<      � 5=      $��1��6   .+�5?      ��   primaryButton#��[ 6   $	��150��6D   $
��View��6P   $
��Left=�6_   $��0 20 5 0q�6z   �� 5@        clockInButton#��[ 6   $	��285��6D   $��Right=�6P   $��5 20 0 0q�6l   ��6~   �� *ChangeClockedInCommand+5A      5B      5C      �� 5E   
   $��1��6   $��2��6   #��[  62   $��
5 23 29 20q�6X   ._�5F      � .+�5G      �� $��Hours Worked��6     
HeadingTwo#��[ 60   #  LiveCharts.Wpf.CartesianChart  5H      5J      5K      5L      5M      5N      