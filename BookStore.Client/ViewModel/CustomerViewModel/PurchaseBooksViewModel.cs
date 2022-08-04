using BookStore.Service.Context;
using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.BookRepo;
using BookStore.Service.Services.Cart;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //This is the viewmodel for adding books to cart
    public class PurchaseBooksViewModel : ViewModelBase
    {
        private DelegateCommand<Book> addToCartCommand;
        public DelegateCommand<Book> AddToCartCommand =>
            addToCartCommand ?? (addToCartCommand = new DelegateCommand<Book>(ExcecuteAddToCart));

        public ObservableCollection<Book> BooksCollection { get; set; }

        private readonly IBookRepository bookRepository;
        private readonly ICart cart;
        //Ctor
        public PurchaseBooksViewModel(IBookRepository bookRepository, ICart cart)
        {
            this.bookRepository = bookRepository;
            this.cart = cart;
            BooksCollection = new ObservableCollection<Book>(this.bookRepository.GetAll());
        }

        private void ExcecuteAddToCart(Book book) => cart.Add(book);
    }
}
