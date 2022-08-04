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
            ReturnCommand = new RelayCommand(() => MessengerInstance.Send<UserControl>(new PrimaryView()));

            PurchaseBooksCommand = new RelayCommand(() => CurrentContent = new PurchaseBooksView());
            PurchaseJournalsCommand = new RelayCommand(() => CurrentContent = new PurchaseJournalsView());
            ViewShoppingCartCommand = new RelayCommand(() => CurrentContent = new ShoppingCartView());
        }
    }
}
