   M S B A M L   `   `   `  ????K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BookStore.ClientBookStore.Client  5	      i9clr-namespace:BookStore.Client.ViewModel.ManagerViewModel+BookStore.Client.ViewModel.ManagerViewModel  5
      ;    5BookStore.Client.View.ManagerViews.ManagerStorageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BookStore.Client     5	      P
viewmodels9clr-namespace:BookStore.Client.ViewModel.ManagerViewModel     5
      -   5          >?Name$  _window??5       ? DataContext 5        BookStore.Client.DISource     Type$% viewmodels:BookStorageViewModelL?.??5      ?? .??5   
   ? ???#303040 ? RowDefinitions 5      ?? 5      $
??Auto ?6    ?? 5      $??* ?6    .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid??5         
IsReadOnly .    AutoGenerateColumns .  $??10q?5      ??5      ?? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Title??5      
   MinWidth$	
 100Q?5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      ?? *Title+5        5      $	 Author??5      $	
 100Q?5       $ * 5"       5!      ?? *
AuthorName+5"        5#      $	 Publication Date??5$      $	
 100Q?5%      $ * 5'       5&      ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??5'        5(      $	 
Base Price??5)      $	
 100Q?5*      $ * 5,       5+      ?? *	BasePrice+5,        5-      $	 Genre??5.      $	
 100Q?5/      $ * 51       50      ?? *Genre+51      4  .System.Windows.Controls.DataGridTemplateColumn  52         CellTemplate 53      ?? 54      .R?55   "   ??  ?? Orientation$ 
Horizontal=?6-   .+?56   &   ??    BTNTheme#??[  6-   $??Delete??59   !   ??57   !   ?? *DataContext.DeleteCommand+ ?? ElementName$ _window????58   !   ?? 59   !   5:   #   5;      5=         RowDetailsTemplate 5?      ?? 5@      .R?5A      ]? $	??200??6$   .+?5B      ?? $
??Left=?6$   ??5C      ?? *ProductImageSource+?? 5D      $ Vertical=?6)   $??10q?6@   .+?5E   "   ?? $ 
Horizontal=?6-   .+?5F   &   ?? $??	Summary: ??60   $
??Bold"?6A   ?? 5G   &   $
??Wrap=?6I   $	??750??6]   ??60   ?? *	Summary+6]   5H   #   ?? 5I   "   $ 
Horizontal=?6-   .+?5J   &   ?? $??	Edition: ??60   $
??Bold"?6A   ?? 5K   &   ??60   ?? *	Edition+5L   #   ?? 5M   "   #??[  6)   $??Update??5P   !   $??10q?62   $??40??6>   $	??100??6J   $
??Left=?6V   ??5N   !   ?? *DataContext.UpdateBookCommand+$ _window????5O   !   ?? 5P   V   5Q      5R      5S      5U      ? 5V      $??1??6   .+?5W      ?? ??6!   ?? *UpdateBookContent+5X      5Z      5[      5\      