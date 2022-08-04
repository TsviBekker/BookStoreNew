using BookStore.Client.View.ManagerViews;
using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.BookRepo;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class BookStorageViewModel : ViewModelBase
    {
        private DelegateCommand<Book> deleteCommand;
        public DelegateCommand<Book> DeleteCommand => deleteCommand ??
            (deleteCommand = new DelegateCommand<Book>(ExecuteDeleteCommand));

        private DelegateCommand<Book> updateBookCommand;
        public DelegateCommand<Book> UpdateBookCommand => updateBookCommand ??
            (updateBookCommand = new DelegateCommand<Book>(ExcecuteUpdateBookCommand));

        private UserControl updateBookContent;
        public UserControl UpdateBookContent { get => updateBookContent; set => Set(ref updateBookContent, value); }


        public ObservableCollection<Book> BooksCollection { get; set; }

        private readonly IBookRepository bookRepository;

        //Ctor
        public BookStorageViewModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

            MessengerInstance.Register<bool>(this, "updated", b => UpdateBookContent = null);

            BooksCollection = new ObservableCollection<Book>(bookRepository.GetAll());
        }

        private void ExcecuteUpdateBookCommand(Book bookToUpdate)
        {
            MessengerInstance.Send(bookToUpdate, "updatebook");
            UpdateBookContent = new AddBooksView();
        }
        private async void ExecuteDeleteCommand(Book book)
        {
            BooksCollection.Remove(book);

            await bookRepository.Delete(book.Id);
            //await bookRepository.Complete();
        }
    }
}
