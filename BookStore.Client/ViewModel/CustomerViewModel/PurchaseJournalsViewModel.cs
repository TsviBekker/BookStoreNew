using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //This is the viewmodel for adding journals to cart
    public class PurchaseJournalsViewModel:ViewModelBase
    {
        public ObservableCollection<Journal> JournalCollection { get; set; }
        private ProductsService productsService;

        private DelegateCommand<Journal> addToCartCommand;
        public DelegateCommand<Journal> AddToCartCommand =>
            addToCartCommand ?? (addToCartCommand = new DelegateCommand<Journal>(ExcecuteAddToCart));

        public PurchaseJournalsViewModel()
        {
            productsService = new ProductsService();
            InitStorage();
        }
        private void ExcecuteAddToCart(Journal obj) => ShoppingCart.Instance.Add(obj);
        private void InitStorage() => JournalCollection = new ObservableCollection<Journal>(productsService.GetJournals());
    }
}
