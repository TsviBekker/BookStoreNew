using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //This is the viewmodel for adding books to cart
    public class PurchaseBooksViewModel : ViewModelBase
    {
        public ObservableCollection<Book> BooksCollection { get; set; }
        ProductsService productsService;

        private DelegateCommand<Book> addToCartCommand;
        public DelegateCommand<Book> AddToCartCommand =>
            addToCartCommand ?? (addToCartCommand = new DelegateCommand<Book>(ExcecuteAddToCart));
        //Ctor
        public PurchaseBooksViewModel()
        {
            productsService = new ProductsService();
            InitStorage();
        }
        private void ExcecuteAddToCart(Book book) => ShoppingCart.Instance.Add(book);
        private void InitStorage() => BooksCollection = new ObservableCollection<Book>(productsService.GetBooks());
    }
}
