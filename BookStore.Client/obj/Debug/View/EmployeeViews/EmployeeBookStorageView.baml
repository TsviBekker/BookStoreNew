   M S B A M L   `   `   `  ????K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BookStore.ClientBookStore.Client  5      k:clr-namespace:BookStore.Client.ViewModel.EmployeeViewModel,BookStore.Client.ViewModel.EmployeeViewModel  5	      A    ;BookStore.Client.View.EmployeeViews.EmployeeBookStorageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BookStore.Client     5      Q
viewmodels:clr-namespace:BookStore.Client.ViewModel.EmployeeViewModel     5	        ? DataContext  5
        BookStore.Client.DISource     Type$- 'viewmodels:EmployeeBookStorageViewModelL?.??5      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid??5         
IsReadOnly .    AutoGenerateColumns .  $??10q?5      ??5      ?? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title??5         MinWidth$	 100Q?5      	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 5      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5      ?? *Title+5        5      $ Author??5      $	 100Q?5      $	 * 5      
 5      ?? *
AuthorName+5        5      $ Edition??5      $ 20Q?5      $	 * 5      
 5      ?? *	Edition+5        5       $ Summary??5!      $	 100Q?5"      $	 * 5$      
 5#      ?? *	Summary+5$        5%      $ Publication Date??5&      $	 100Q?5'      $	 * 5)      
 5(      ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??5)        5*      $ 
Base Price??5+      $	 100Q?5,      $	 * 5.      
 5-      ?? *	BasePrice+5.        5/      $ Genres??50      $	 100Q?51      $	 * 53      
 52      ?? *GenresAsString+53      55      56      