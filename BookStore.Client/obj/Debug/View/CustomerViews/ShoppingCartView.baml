   M S B A M L   `   `   `  ????K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BookStore.ClientBookStore.Client  5	      k:clr-namespace:BookStore.Client.ViewModel.CustomerViewModel,BookStore.Client.ViewModel.CustomerViewModel  5
      :    4BookStore.Client.View.CustomerViews.ShoppingCartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BookStore.Client     5	      Q
viewmodels:clr-namespace:BookStore.Client.ViewModel.CustomerViewModel     5
      -   5          >?Name$  _window??5       ? DataContext 5        BookStore.Client.DISource     Type$&  viewmodels:ShoppingCartViewModelL?.??5      ?? .+?5   
   ?? $??Shopping Cart??6      LabelTheme1#??[  6(   &   System.Windows.Controls.DataGrid  5   
   $??10q?5         
IsReadOnly .    AutoGenerateColumns .  ??5      ?? *CartContent+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title??5         MinWidth$	 100Q?5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      ?? *Description+5        5      $ Publication Date??5      $	 100Q?5      $ * 5      	 5      ?? *PublicationDate+5        5      $ Price??5      $	 100Q?5      $ * 5!      	 5       ?? *	BasePrice+5!        5"      $ Genres??5#      $	 100Q?5$      $ * 5&      	 5%      ?? *GenresAsString+5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      
   CellTemplate
 5(      ?? 5)      .R?5*      ??   BTNTheme#??[ 6%   $??Remove??5-   !   ??5+   !   ?? *DataContext.RemoveCommand+ ?? ElementName$ _window????5,   !   ?? 5-   !   5.      50      52      ? 53   
   
?????? .+?54      ??  ?? CornerRadius$ 10??6   
???????$??20q?56      ._?57      ?? $??Center=?6    ? 	Resources 58       ?? 
TargetType ?? Property ?? Value??%?   '??       '?? p     ?? 59      " ??6    .?5:      ??  ? ??$ Center=?6B   ?? 5;       ? ??$ 14(?69   5<      ?? 5=      " ??6    .?5>      ??  ? ??$ Center=?6I   5?      5@      .+?5A      ?? $??Enter Credit Card Details??6   $??Center=?5B      #??[  5C      ?? 5D       ?? Orientation$ 
Horizontal=?6!   .+?5E      ?? $	??150??6    $??Credit Card Number??5F       $??Right=?5G       ?? 5H      $	??250??6"   ??5I   "   ?? *CrediCardNumber+5J      ?? 5K      $ 
Horizontal=?6!   .+?5L      ?? $	??150??6    $??Right=?5M       $??Expiration Date??5N       ?? 5O      $ 
Horizontal=?6%   $
??20 0q?6>   .+?5P      ?? $
??Year??6(   $
??15 0q?64   ?? 5Q      $??50??6&   ??5R   &   ?? *ExpirationYear+?? 5S      $??Month??6)   $
??15 0q?66   ?? 5T      $??50??6&   ??5U   &   ?? *ExpirationMonth+5W      5X      ?? 5Y      $ 
Horizontal=?6!   .+?5Z      ?? $	??150??6    $??Right=?5[       $??CC??5\       ?? 5]      $	??250??6"   ??5^   "   ?? *CardCC+5_      5`      5a      5b      ?? 5c   
   .+?5d      ?? $ 
Horizontal=?6   $??Center=?62   .+?5e      ?? 
?????w?$	??100??65   $ 5??6A   $??10q?6R   ._?5f      ?? $ 
Horizontal=?6!   $??Center=?5g      .+?5h      ?? $??Total: ??6    ?? 5i      ??6    ?? *
TotalPrice+ ?? UpdateSourceTrigger$ PropertyChanged=??? 5j      $??$??6    5k      5l      ?? 5m      
?????w?$	??100??65   $ 5??6A   $??10q?6R   ._?5n      ?? $ 
Horizontal=?6!   $??Center=?5o      .+?5p      ?? $??
Discount: ??6    ?? 5q      ??6    ?? *
Discount+$ PropertyChanged=??? 5r      $??$??6    5s      5t      5u      ?? 5v      $ 
Horizontal=?6   $??Center=?5w      .+?5x      ?? $??CheckOut??6   $??20q?6,     BTNShop#??[ 5y      ??5z      ?? *CheckoutCommand+?? 5{      $??Empty??6   $??20q?6)   #??[ 5|      ??5}      ?? *EmptyCartCommand+5~      5      5?      5?      