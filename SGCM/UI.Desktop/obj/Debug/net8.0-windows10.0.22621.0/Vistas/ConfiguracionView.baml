   M S B A M L   `   `   `  ����  Sgcm.UI.Desktop.    (Sgcm.UI.Desktop.Vistas.ConfiguracionView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  ConfiguracionView��5       � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property	 P� Value
 �� 
TargetName J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions �Name � RowDefinitions �� CornerRadius K� IsItemsHost K� ZIndex   TabIndex   DirectionalNavigation �� SelectedContent �� SelectedContentTemplate" �� SelectedContentStringFormat �� ContentStringFormat��%j  '��       '�� �    �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ PART_Border��6!   #��z��66   $��1q�6`   
�������$��2q�6�   ._�5      �� $��Header��6/   $��2q�6F   5       5      P� 5       �@��
IsSelected$
	 True��6<   . �5   "   �� $
 PART_Border��6)    � ��
 �   �6Y   5      5      5      5      �� 5   
   " ��6   .�5       ��  �@��TabStripPlacement$
 Left=�62   �� 5!       � ��$ 2q�6'   �� 5"       � ��$ 2q�6(   �� 5#       � ��
 �����6+   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      � $
}�True��6   $
 True��63   $ Local=�6N    5)      �� 5*   "   $ ColumnDefinition0��63   �� 5+   "   $ ColumnDefinition1��6=   $��0 �63   6=    5-      �� 5.   "   $ RowDefinition0��6>   $
��Auto �60   6>   �� 5/   "   $ RowDefinition1��6;   $��* �60   6;   .+�51      �� $ HeaderBorder��6%   
���   �$��1q�53   %   $ 5��54   %   ���#FAFAFA$��0,0,0,5q�56   %   ._�57   "   �� $��HeaderPanel��58   +   $
 True��57   +   $ 1��59   +   $ 1��5:   +   $��0��5;   +   $��0��5<   +   5=      � 5?      $��ContentPanel��6#   $ 2��5@   #   $ Local=�5A   #   $ 	Contained=�5B   #   $��0��5C   #   $��1��5D   #   .+�5E   "   �� #��z��6)   #��z��5F   )   #��z��5G   )   $ 5��5H   )   ._�5I   &   �� $��PART_SelectedContentHost��5M   7   #��z 5I   7   #��z 5J   7   # z 5K   7   $��SelectedContent��5L   7   $��2q�5N   7   # z 5O   7   5P   #   5Q      5R       5T      P� 5U       �@��TabStripPlacement$	 Bottom=�6N   . �5V   "   �� $
 HeaderPanel��6)    � ��$ 1��6V   �� 5W   "   $
 ContentPanel��6)    � ��$ 0��6W   �� 5X   "   $
 RowDefinition0��6)    � ��$ * �6e   �� 5Y   "   $
 RowDefinition1��6)    � ��$
 Auto �6e   �� 5Z   "   $
 HeaderBorder��6)    � ��$ 0,5,0,0q�6f   5[      P� 5\       �@��TabStripPlacement$
	 Left=�6N   . �5]   "   �� $
 HeaderPanel��6)    � ��$ 0��6V   �� 5^   "   $
 ContentPanel��6)    � ��$ 0��6W   �� 5_   "   $
 HeaderPanel��6)    � ��$ 0��6Y   �� 5`   "   $
 ContentPanel��6)    � ��$ 1��6Z   �� 5a   "   $
 ColumnDefinition0��6)    � ��$
 Auto �6j   �� 5b   "   $
 ColumnDefinition1��6)    � ��$ * �6j   �� 5c   "   $
 RowDefinition0��6)    � ��$ * �6e   �� 5d   "   $
 RowDefinition1��6)    � ��$ 0 �6e   �� 5e   "   $
 HeaderBorder��6)    � ��$ 0,0,5,0q�6f   5f      P� 5g       �@��TabStripPlacement$	 Right=�6N   . �5h   "   �� $
 HeaderPanel��6)    � ��$ 0��6V   �� 5i   "   $
 ContentPanel��6)    � ��$ 0��6W   �� 5j   "   $
 HeaderPanel��6)    � ��$ 1��6Y   �� 5k   "   $
 ContentPanel��6)    � ��$ 0��6Z   �� 5l   "   $
 ColumnDefinition0��6)    � ��$ * �6j   �� 5m   "   $
 ColumnDefinition1��6)    � ��$
 Auto �6j   �� 5n   "   $
 RowDefinition0��6)    � ��$ * �6e   �� 5o   "   $
 RowDefinition1��6)    � ��$ 0 �6e   �� 5p   "   $
 HeaderBorder��6)    � ��$ 5,0,0,0q�6f   5q      P� 5r       � {�$	 False��6E   . �5s   "   �� # � ��6K    � ��5t      5v      5x      5y      5z      .��5|      � .+�5~   
   �� .@�5      �� $
��hola��6   .��6$   15�      �� 5�      .��6   25�      5�      5�      5�      