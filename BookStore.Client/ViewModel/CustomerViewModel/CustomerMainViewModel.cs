using BookStore.Client.View;
using BookStore.Client.View.CustomerViews;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //This is the tooalbar viewmodel - the navigation tool
    public class CustomerMainViewModel : ViewModelBase
    {
        private UserControl currentContent;
        public UserControl CurrentContent { get => currentContent; set => Set(ref currentContent, value); }
        public RelayCommand ReturnCommand { get; set; }
        public RelayCommand PurchaseBooksCommand { get; set; }
        public RelayCommand PurchaseJournalsCommand { get; set; }
        public RelayCommand ViewShoppingCartCommand { get; set; }
        public CustomerMainViewModel()
        {
            ReturnCommand = new RelayCommand(Return);
            PurchaseBooksCommand = new RelayCommand(PurchaseBooks);
            PurchaseJournalsCommand = new RelayCommand(PurchaseJournals);
            ViewShoppingCartCommand = new RelayCommand(ViewShoppingCart);
        }
        private void ViewShoppingCart()
        {
            MessengerInstance.Send<bool>(true, "cart");
            CurrentContent = new ShoppingCartView();
        }
        private void PurchaseJournals() => CurrentContent = new PurchaseJournalsView();
        private void PurchaseBooks() => CurrentContent = new PurchaseBooksView();
        private void Return() => MessengerInstance.Send<UserControl>(new PrimaryView());
    }
}
