   M S B A M L   `   `   `  ???? K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:BookStore.Client.View.CustomerViews#BookStore.Client.View.CustomerViews  ;    5BookStore.Client.View.CustomerViews.PurchaseBooksView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Clocal1clr-namespace:BookStore.Client.View.CustomerViews     -     >?Name$  _window?? ? DataContext ??    Locator ?? Source# [   ?? Path$ PurchaseBooks?.??&   System.Windows.Controls.DataGrid  -     Name$ DataGrid??   
IsReadOnly .    AutoGenerateColumns .  $??10q????? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Title??
   MinWidth$	
 100Q?   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *Title+  $	 Author??$	
 100Q?$ *  ?? *
AuthorName+  $	 Publication Date??$	
 100Q?$ *  ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??  $	 Price??$	
 100Q?$ *  ?? *	BasePrice+  $	 Genres??$	
 100Q?$ *  ?? *GenresAsString+   RowDetailsTemplate ?? .R?]? $	??300??.+??? $
??Left=????? *ProductImageSource+??  ?? Orientation$ Vertical=?$??10q?.+??? $ 
Horizontal=?.+??? $??	Summary: ??$
??Bold"??? $
??Wrap=?$	??750?????? *	Summary+?? $ 
Horizontal=?.+??? $??	Edition: ??$
??Bold"??? ???? *	Edition+??   BTNShop#??[ $
??Left=?$
??0 10q?$	??150??$??Add To?????? *DataContext.AddToCartCommand+ ?? ElementName$ _window?????? 