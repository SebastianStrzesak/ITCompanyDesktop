   M S B A M L   `   `   `  ����D  @MVVMFirma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVMFirma.ViewsMVVMFirma.Views  5   	        MVVMFirma.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,vmclr-namespace:MVVMFirma.Views     5   	     � Title$  	MVVMFirma��5   	   $	��300��6   $	��300��6(    � WindowState$ 	Maximized=�64    � 	Resources 5       �� Source�� 5   
   $ MainWindowResources.xaml?�6   %    .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   o� $��0��6   $��0��6   $��2��6,   $��2q�6@   .@�5      m� $��_Plik��6   m� 5      $��_Magazyn��6   .@�5      m� $��Wszystkie towary��6   m� 5      $��
Nowy towar��6   m� 5      $��Wydanie Zewnętrzne (WZ)��6   m� 5      $!��Przyjęcie Zewnętrzne (PZ)��6   5      m� 5      $��Program��6   5      c� 5   
   $��0��6   $��1��6"   $��2��6/   $��2q�6C   .@�5       d� $��32��6   $��32��6&   
����  �$��2q�6D   d� 5!      $��32��6   $��32��6&   
��� ���$��2q�6F   5"      �� 5#   
   $��2��6   $��0��6   ._�5$      �� $��Operacje��5%      
����� �   CommandsTemplate#��[  5(        MainHCCStyle#��[ 5)      ��5'      ��  �� Path$ Commands�5)      5+      �� 5,   
   $��2��6   $��1��6   ._�5-      �� $��Przestrzeń robocza��5.        WorkspacesTemplate#��[ 50      #��[ 51      ��5/      �� $ 
Workspaces�51      53      �� 54   
   $��0��6   $��3��6$   $��2��61   .@�55      �� .��56      �� Sebastian Strzesak60   57      �� 58      �� 59      .��5:      �� 	WSB-NLU6%   5;      5<      5=      5>      