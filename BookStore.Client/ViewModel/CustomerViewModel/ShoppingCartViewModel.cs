using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //shopping cart view model of the customer
    public class ShoppingCartViewModel : ViewModelBase
    {
        #region PROPERTIES
        private ObservableCollection<ProductBase> cartContent;
        public ObservableCollection<ProductBase> CartContent { get => cartContent; set => Set(ref cartContent, value); }
        public RelayCommand CheckoutCommand { get; set; }
        public RelayCommand EmptyCartCommand { get; set; }
        private decimal totalPrice;
        public decimal TotalPrice { get => ShoppingCart.Instance.TotalPrice; set => Set(ref totalPrice, value); }
        private decimal discount;
        public decimal Discount { get => ShoppingCart.Instance.Discount; set => Set(ref discount, value); }
        private DelegateCommand<ProductBase> removeCommand;

        public DelegateCommand<ProductBase> RemoveCommand => removeCommand ?? (removeCommand = new DelegateCommand<ProductBase>(RemoveFromCart));
        public string CrediCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CardCC { get; set; }
        #endregion
        public ShoppingCartViewModel()
        {
            CheckoutCommand = new RelayCommand(Checkout);
            EmptyCartCommand = new RelayCommand(EmptyCart);
            MessengerInstance.Register<bool>(this, "cart", InitCart);
            InitCart(true);
        }
        private void EmptyCart()
        {
            ShoppingCart.Instance.Empty();
            CartContent.Clear();
            TotalPrice = 0;
        }
        private void Checkout()
        {
            if (!CreditCardCheck()) return;
            MessageBox.Show($"Total: {TotalPrice}", "Thanks For Shopping!");
            EmptyCart();
            CartContent.Clear();
        }
        //this method checks the credit card details
        private bool CreditCardCheck()
        {
            if (TotalPrice == 0) //check if cart has items
            {
                MessageBox.Show("Cart is empty!");
                return false;
            }
            else if (CrediCardNumber.Length < 10 || CrediCardNumber == null)
            {
                MessageBox.Show("Invalid Credit Card Number");
                return false;
            }
            else if ((ExpirationYear == DateTime.Now.Year && ExpirationMonth <= DateTime.Now.Month) || ExpirationYear < DateTime.Now.Year)
            {
                MessageBox.Show("Card Is Expired");
                return false;
            }
            else if (ExpirationMonth < 1 || ExpirationMonth > 12)
            {
                MessageBox.Show("Invalid Month");
                return false;
            }
            else if (CardCC.ToString().Length < 3)
            {
                MessageBox.Show("Invalid CC");
                return false;
            }
            return true;
        }
        private void RemoveFromCart(ProductBase item)
        {
            ShoppingCart.Instance.Remove(item);
            CartContent.Remove(item);
            TotalPrice = ShoppingCart.Instance.TotalPrice;
            Discount = ShoppingCart.Instance.Discount;
        }
        private void InitCart(bool obj)
        {
            if (!obj) return;
            CartContent = new ObservableCollection<ProductBase>(ShoppingCart.Instance.GetCart());
            TotalPrice = ShoppingCart.Instance.TotalPrice;
            Discount = ShoppingCart.Instance.Discount;
        }
    }
}
