   M S B A M L   `   `   `  ????K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BookStore.ClientBookStore.Client  5	      k:clr-namespace:BookStore.Client.ViewModel.CustomerViewModel,BookStore.Client.ViewModel.CustomerViewModel  5
      ;    5BookStore.Client.View.CustomerViews.PurchaseBooksView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BookStore.Client     5	      Q
viewmodels:clr-namespace:BookStore.Client.ViewModel.CustomerViewModel     5
      -   5          >?Name$  _window??5       ? DataContext 5        BookStore.Client.DISource     Type$' !viewmodels:PurchaseBooksViewModelL?.??5      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid??5         
IsReadOnly .    AutoGenerateColumns .  $??10q?5      ??5      ?? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title??5      	   MinWidth$		 100Q?5      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      ?? *Title+5        5      $ Author??5      $		 100Q?5      $
 * 5       5      ?? *
AuthorName+5        5      $ Publication Date??5      $		 100Q?5      $
 * 5!       5       ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??5!        5"      $ Price??5#      $		 100Q?5$      $
 * 5&       5%      ?? *	BasePrice+5&        5'      $ Genres??5(      $		 100Q?5)      $
 * 5+       5*      ?? *GenresAsString+5+         RowDetailsTemplate 5-   
   ?? 5.      .R?5/      ]? $	??300??6   .+?50      ?? $
??Left=?6   ??51      ?? *ProductImageSource+?? 52       ?? Orientation$ Vertical=?6!   $??10q?53   !   .+?54      ?? $ 
Horizontal=?6%   .+?55      ?? $??	Summary: ??6(   $
??Bold"?56   (   ?? 57      $
??Wrap=?58   (   $	??750??59   (   ??57   (   ?? *	Summary+59   (   5:      ?? 5;      $ 
Horizontal=?6%   .+?5<      ?? $??	Edition: ??6(   $
??Bold"?5=   (   ?? 5>      ??6(   ?? *	Edition+5?      ?? 5@         BTNShop#??[  6!   $
??Left=?5A   !   $
??0 10q?5B   !   $	??150??5C   !   $??Add To??5F   !   ??5D   !   ?? *DataContext.AddToCartCommand+ ?? ElementName$ _window????5E   !   ?? 5G      5H      5I      5J      5L      5M      