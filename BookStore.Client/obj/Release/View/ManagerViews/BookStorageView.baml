   M S B A M L   `   `   `  ???? K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:BookStore.Client.View.ManagerViews"BookStore.Client.View.ManagerViews  ;    5BookStore.Client.View.ManagerViews.ManagerStorageView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:BookStore.Client.View.ManagerViews     -     >?Name$  _window?? ? DataContext ??    Locator ?? Source# [   ?? Path$ BookStorage?.???? .??? ???#303040 ? RowDefinitions ?? $
??Auto ??? $??* ?.+?&   System.Windows.Controls.DataGrid  -     Name$ DataGrid??   
IsReadOnly .    AutoGenerateColumns .  $??10q????? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Title??   MinWidth$	 100Q?   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *Title+  $
 Author??$	 100Q?$ *  ?? *
AuthorName+  $
 Publication Date??$	 100Q?$ *  ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??  $
 
Base Price??$	 100Q?$ *  ?? *	BasePrice+  $
 Genres??$	 100Q?$ *  ?? *GenresAsString+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate ?? .R???  ?? Orientation$ 
Horizontal=?.+???   BTNTheme#??[ $??Delete?????? *DataContext.DeleteCommand+ ?? ElementName$ _window??????    RowDetailsTemplate ?? .R?]? $	??200??.+??? $
??Left=????? *ProductImageSource+?? $ Vertical=?$??10q?.+??? $ 
Horizontal=?.+??? $??	Summary: ??$
??Bold"??? $
??Wrap=?$	??750?????? *	Summary+?? $ 
Horizontal=?.+??? $??	Edition: ??$
??Bold"??? ???? *	Edition+?? #??[ $??Update??$??10q?$??40??$	??100??$
??Left=????? *DataContext.UpdateBookCommand+$ _window?????? ? $??1??.+??? ???? *UpdateBookContent+