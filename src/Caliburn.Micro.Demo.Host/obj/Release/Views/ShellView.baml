   M S B A M L   `   `   `  ���� S  OCaliburn.Micro.Demo.Host, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Caliburn.Micro.Demo.Host.ViewsCaliburn.Micro.Demo.Host.Views  .    (Caliburn.Micro.Demo.Host.Views.ShellView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:Caliburn.Micro.Demo.Host.Views     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1224, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ^ ZCaliburn.Micro.Platform, Version=3.0.1.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org     MaterialDesignPaper#���   $
��1400��$	��800��.��)  #MaterialDesignThemes.Wpf.DialogHost      
Identifier$  
RootDialog��   SnackbarMessageQueue ��  �� ElementName$ MainSnackbar�� �� Path$ MessageQueue�.��)  #MaterialDesignThemes.Wpf.DrawerHost     IsLeftDrawerOpen �� $ MenuToggleButton��$ 	IsChecked�   LeftDrawerContent ]� $	��212��.+�d�  ' #MaterialDesignHamburgerToggleButton#��[ $	��Top=�$��Right=�$
��0,16q� d� 	IsChecked �� $ MenuToggleButton��$ 	IsChecked� �� Mode$ TwoWay=�.��]� .+��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��auto �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��$��16q�+  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth2=�
   Mode$
 
PrimaryMid=�$	��Top=�.��]� .+�d� -    d�Name$ MenuToggleButton��#��[ $ FalseY��� -    ��Name$ NotificationBar��$��Right=�$��Center=��� -   $ Basket��$��Right=�$��Center=��� $��Center=�$��Center=�$��22(�Virtual Shopping Aggregator� $��1�� �� $
��Auto ��� $��* �.+���  �� Padding$ 10q�._��  �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -    ��Name$ Stores��$��1��$��0��$
��Left=�$��Stretch=����� .R�#  MaterialDesignThemes.Wpf.Card  $	��500��$	��220��$��4 2 8 16q�.��� $��Stretch=�$��Stretch=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $	��200 ��� $��* �.+��� $��5�� �� StretchDirection$
 Both=�$��Stretch=����� *	StoreLogo+�� $��1�� # MaterialDesignHeadlineTextBlock#��[ $��
16 16 16 2q����� *	StoreName+�� $��1��$��1��$
��Wrap=�$��	16 0 16 8q�  MaterialDesignBodyLight#���  $��Center=����� *StoreDescription+� $��8,0,0,0q�$��2��$��1�� �� $
��Auto ��� $
��Auto �.+�9� $��Stretch=�$��Show items for sale�� 9� ExpandDirection$
 Down=�$��0q�.����  �� Orientation$ Vertical=�  MaterialDesignBody#���  $��	24,8,15,5q�.+��� ���� *	ForSale+���� .R��  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+���  ��Name$ divider��$��0��$��2��$��0��$��0 1 0 0q�  MaterialDesignDivider#���  $	 0,5q��� $��50��$��50��$��1��$��2��$��0,0,5,0q����� *	Thumbnail+�� $��1��$��1������ *
ItemName+�� $��2��$��1��$ 
Horizontal=�$	��Top=�.+��� $��22������ $ 
Horizontal=�.+��� $��10(����� *Price+ �� StringFormat$ c��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1224, Culture=neutral, PublicKeyToken=null]]   Kind$ 
BasketFill=� � ToolTip$ Add to basket��$
��10,0q�.  (System.Windows.Interactivity.Interaction   Triggers /	  )System.Windows.Interactivity.EventTrigger	   	  	EventName$ PreviewMouseDown��.
  (System.Windows.Interactivity.TriggerBase 
  Actions. "  Caliburn.Micro.ActionMessage     
MethodName$ AddToBasket�� �� Triggers ��  �� Binding ��  �� RelativeSource �� *PreviousData+ �� Value Z� .a���  �� 
TargetName$ divider��  �� Property  � y�! �� Value$! 	Collapsed=����� .���   � ��$! 5q��� $��1��$��3��$��0 1 0 0q�#���  ._�� $��8q�.+��� " ��Name$" 
ChatButton��  MaterialDesignFlatButton#���  $
��Left=�.���� $ 
Horizontal=�.+�  $ Message=��� $��8 0 0 0q�$��Center=�Chat�� $" EmailButton��#���  $��Right=�.���� $ 
Horizontal=�.+�  $ Email=��� $��8 0 0 0q�$��Center=�Email���� .R��   $��2��$	 Depth2=�$
 
PrimaryMid=�$
��0,10q�.���� -   $ CustomerShell��