   M S B A M L   `   `   `  ???? K  GBookStore.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:BookStore.Client.View.EmployeeViews#BookStore.Client.View.EmployeeViews  A    ;BookStore.Client.View.EmployeeViews.EmployeeBookStorageView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Clocal1clr-namespace:BookStore.Client.View.EmployeeViews       ? DataContext  ??    Locator ?? Source# [   ?? Path$ EmployeeBookStorage?.??&   System.Windows.Controls.DataGrid  -     Name$ DataGrid??   
IsReadOnly .    AutoGenerateColumns .  $??10q????? *BooksCollection+ ?? UpdateSourceTrigger$ PropertyChanged=?   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Title??	   MinWidth$		 100Q?
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *Title+  $ Author??$		 100Q?$
 *  ?? *
AuthorName+  $ Edition??$	 20Q?$
 *  ?? *	Edition+  $ Summary??$		 100Q?$
 *  ?? *	Summary+  $ Publication Date??$		 100Q?$
 *  ?? *PublicationDate+ ?? StringFormat$ {0:MM/dd/yyyy}??  $ 
Base Price??$		 100Q?$
 *  ?? *	BasePrice+  $ Genres??$		 100Q?$
 *  ?? *GenresAsString+