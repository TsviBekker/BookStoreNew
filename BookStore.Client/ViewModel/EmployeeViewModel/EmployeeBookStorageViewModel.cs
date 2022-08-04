using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.BookRepo;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.EmployeeViewModel
{
    public class EmployeeBookStorageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> BooksCollection { get; set; }
        public IEnumerable<Book> Products { get; set; }
        private readonly IBookRepository bookRepository;

        public EmployeeBookStorageViewModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            BooksCollection = new ObservableCollection<Book>(this.bookRepository.GetAll());
        }
    }
}
