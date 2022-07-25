using BookStore.Client.View.ManagerViews;
using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class BookStorageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> BooksCollection { get; set; }
        public IEnumerable<Book> Products { get; set; }
        private ProductsService productsService;
        private DelegateCommand<Book> deleteCommand;
        public DelegateCommand<Book> DeleteCommand => deleteCommand ?? (deleteCommand = new DelegateCommand<Book>(ExecuteDeleteCommand));

        private DelegateCommand<Book> updateBookCommand;
        public DelegateCommand<Book> UpdateBookCommand => updateBookCommand ?? (updateBookCommand = new DelegateCommand<Book>(ExcecuteUpdateBookCommand));

        private UserControl updateBookContent;
        public UserControl UpdateBookContent { get => updateBookContent; set => Set(ref updateBookContent, value); }

        public BookStorageViewModel()
        {
            productsService = new ProductsService();
            MessengerInstance.Register<bool>(this, "book", InitStorage);
            MessengerInstance.Register<bool>(this, "updated", Updated);
            InitStorage(true);
        }
        private void Updated(bool obj) => UpdateBookContent = null; //close UC
        private void ExcecuteUpdateBookCommand(Book bookToUpdate)
        {
            //send the chosen book via MI, this will be registered in AddBook viewmodel. im re-using the addbook view/viewmodel
            MessengerInstance.Send<Book>(bookToUpdate, "updatebook");
            UpdateBookContent = new AddBooksView();
        }
        private void ExecuteDeleteCommand(Book book)
        {
            BooksCollection.Remove(book);
            productsService.RemoveBook(book);
        }
        private void InitStorage(bool b)
        {
            if (!b) return;
            Products = productsService.GetBooks();
            BooksCollection = new ObservableCollection<Book>(Products);
        }
    }
}
