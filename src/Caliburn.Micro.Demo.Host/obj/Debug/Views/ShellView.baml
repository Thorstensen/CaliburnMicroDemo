   M S B A M L   `   `   `  ����S  OCaliburn.Micro.Demo.Host, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Caliburn.Micro.Demo.Host.ViewsCaliburn.Micro.Demo.Host.Views  5      .    (Caliburn.Micro.Demo.Host.Views.ShellView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Caliburn.Micro.Demo.Host.Views     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1224, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ^ ZCaliburn.Micro.Platform, Version=3.0.1.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5	         MaterialDesignPaper#���   5
      $
��1400��5      $	��800��5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost      
Identifier$  
RootDialog��6       SnackbarMessageQueue 68   ��  �� ElementName$ MainSnackbar�� �� Path$ MessageQueue�.��5   
   )  #MaterialDesignThemes.Wpf.DrawerHost     IsLeftDrawerOpen 6$   �� $ MenuToggleButton��$ 	IsChecked�   LeftDrawerContent 5      ]� 5      $	��212��6   .+�5      d�  ' #MaterialDesignHamburgerToggleButton#��[ 6#   $	��Top=�5   %   $��Right=�5   %   $
��0,16q�6A    d� 	IsChecked 5   %   �� $ MenuToggleButton��$ 	IsChecked� �� Mode$ TwoWay=�5      .��5      ]� .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��auto �6(   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6/   $��16q�6<   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth2=�6I   
   Mode$
 
PrimaryMid=�5#   -   $	��Top=�6?   .��5$      ]� .+�5%      d� -   5         d�Name$ MenuToggleButton��5&   )   #��[ 5%   +   $ FalseY�6h   5&   )   �� 5(      -   5         ��Name$ NotificationBar��5(   -   $��Right=�6F   $��Center=�6]   �� 5)      -   5        $ Basket��5)   -   $��Right=�6=   $��Center=�6T   �� 5*      $��Center=�6(   $��Center=�6E   $��22(�6`   Virtual Shopping Aggregator6�   5+      5,      � 5-      $��1��6    5.      �� 5/      $
��Auto �6,   �� 50      $��* �6,   .+�53      ��  �� Padding$ 10q�6!   ._�54      �  55   "   �� 56   &   $
��Auto �64   �� 57   &   $��* �64   �� 58   &   $
��Auto �64    � ColumnDefinitions 5:   "   �� 5;   &   $��* �67   �� 5<   &   $
��Auto �67   .+�5@   "   �� -   5         ��Name$ Stores��5@   L   $��1��6/   $��0��6<   $
��Left=�6\   $��Stretch=�6w   ��5A   &   �� 5B   *   .R�5C   .   #  MaterialDesignThemes.Wpf.Card  $	��500��6B   $	��220��6N   $��4 2 8 16q�6^   .��5D   2   � $��Stretch=�67   $��Stretch=�6T    5E   6   �� 5F   :   $
��Auto �6H   �� 5G   :   $
��Auto �6H   �� 5H   :   $
��Auto �6H   �� 5I   :   $
��Auto �6H    5K   6   �� 5L   :   $	��200 �6K   �� 5M   :   $��* �6K   .+�5O   6   �� $��5��6Y    �� StretchDirection$
 Both=�6j   $��Stretch=�6�   ��6<   �� *	StoreLogo+6�   �� 5P   6   $��1��6@    # MaterialDesignHeadlineTextBlock#��[ 6P   $��
16 16 16 2q�6�   ��6�   �� *	StoreName+6�   �� 5Q   6   $��1��6@   $��1��6P   $
��Wrap=�6]   $��	16 0 16 8q�6q     MaterialDesignBodyLight#���  6�   $��Center=�6�   ��6�   �� *StoreDescription+6�   � 5S   6   $��8,0,0,0q�6;   $��2��6L   $��1��6Y    5T   :   �� 5U   >   $
��Auto �6L   �� 5V   >   $
��Auto �6L   .+�5Y   :   9� $��Stretch=�6C   $��Show items for sale��6a    9� ExpandDirection$
 Down=�6~   $��0q�6�   .��5Z   >   ��  �� Orientation$ Vertical=�6I     MaterialDesignBody#���  6`   $��	24,8,15,5q�6�   .+�5[   B   �� ��6O   �� *	ForSale+��5\   F   �� 5]   J   .R�5^   N   �  5_   R   �� 5`   V   $
��Auto �6d   �� 5a   V   $
��Auto �6d   �� 5b   V   $
��Auto �6d    5d   R   �� 5e   V   $
��Auto �6g   �� 5f   V   $��* �6g   .+�5i   R   ��  ��Name$ divider��5j   �   $��0��5i   Y   $��2��6i   $��0��6}   $��0 1 0 0q�6�     MaterialDesignDivider#���  5j   Q   $	 0,5q�6�   �� 5l   R   $��50��6X   $��50��6c   $��1��6o   $��2��6|   $��0,0,5,0q�6�   ��6�   �� *	Thumbnail+6�   �� 5m   R   $��1��6\   $��1��6i   ��6y   �� *
ItemName+�� 5o   R   $��2��6]   $��1��6j   $ 
Horizontal=�6z   $	��Top=�6�   .+�5p   V   �� $��22��6]   ��5q   Z   �� 5r   ^   $ 
Horizontal=�6i   .+�5s   b   �� $��10(�6�   ��6l   �� *Price+ �� StringFormat$ c��6�   '  !MaterialDesignThemes.Wpf.PackIcon  5t   b   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1224, Culture=neutral, PublicKeyToken=null]]   Kind$ 
BasketFill=�6z    � ToolTip$ Add to basket��6�   $
��10,0q�6�   5u   _   .  (System.Windows.Interactivity.Interaction   Triggers 5w   Z   /	  )System.Windows.Interactivity.EventTrigger	  5x   ^    	  	EventName$ PreviewMouseDown��6m   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5y   b   "  Caliburn.Micro.ActionMessage     
MethodName$ AddToBasket��6t   5z   _   5|   W   5}   S   5~   O    �� Triggers 5   N   �� 5�   R    �� Binding 6^   ��  �� RelativeSource �� *PreviousData+ �� Value 6�   Z� .a�5�   V   ��  �� 
TargetName$ divider��6s     �� Property  � y�! �� Value$! 	Collapsed=�6�   5�   S   5�   K   ��5�   F   �� 5�   J   .�5�   N   ��   � ��$! 5q�6x   5�   K   5�   C   5�   ?   5�   ;   5�   7   �� 5�   6   $��1��6=   $��3��6M   $��0 1 0 0q�6Z   #���  6t   ._�5�   :   � $��8q�6?   .+�5�   >   �� " ��Name$" 
ChatButton��6�     MaterialDesignFlatButton#���  6E   $
��Left=�6x   .��5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $ Message=�6^   �� 5�   F   $��8 0 0 0q�6P   $��Center=�6a   Chat6�   5�   C   5�   ?   �� 5�   >   $" EmailButton��6�   #���  6E   $��Right=�6x   .��5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $ Email=�6^   �� 5�   F   $��8 0 0 0q�6P   $��Center=�6a   Email6�   5�   C   5�   ?   5�   ;   5�   7   5�   3   5�   /   5�   +   ��5�   &   �� 5�   *   .R�5�   .   � 5�   +   5�   #   5�      5�      5�        5�      $��2��6/   $	 Depth2=�6<   $
 
PrimaryMid=�5�   -   $
��0,10q�6?   .��5�      �� -   5        $ CustomerShell��5�   )   5�      5�      5�      5�      5�      5�      