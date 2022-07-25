using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.EmployeeViewModel
{
    public class EmployeeBookStorageViewModel:ViewModelBase
    {
        public ObservableCollection<Book> BooksCollection { get; set; }
        public IEnumerable<Book> Products { get; set; }
        private ProductsService productsService;
        public EmployeeBookStorageViewModel()
        {
            productsService = new ProductsService();
            MessengerInstance.Register<bool>(this, "book", InitStorage);
            InitStorage(true);
        }
        private void InitStorage(bool b)
        {
            if (!b) return;
            Products = productsService.GetBooks();
            BooksCollection = new ObservableCollection<Book>(Products);
        }
    }
}
