using BookStore.Service.Context.Models;
using BookStore.Service.Services.Cart;
using BookStore.Service.Services.Cart.Checkout;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //shopping cart view model of the customer
    public class ShoppingCartViewModel : ViewModelBase
    {
        private ObservableCollection<ProductBase> cartContent;
        public ObservableCollection<ProductBase> CartContent { get => cartContent; set => Set(ref cartContent, value); }

        private decimal totalPrice;
        public decimal TotalPrice { get => cart.Total; set => Set(ref totalPrice, value); }

        private decimal discount;
        public decimal Discount { get => cart.Discount; set => Set(ref discount, value); }

        public RelayCommand CheckoutCommand { get; set; }
        public RelayCommand EmptyCartCommand { get; set; }


        private DelegateCommand<ProductBase> removeCommand;
        public DelegateCommand<ProductBase> RemoveCommand =>
            removeCommand ?? (removeCommand = new DelegateCommand<ProductBase>(RemoveFromCart));

        public string CrediCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CardCC { get; set; }


        private readonly ICart cart;
        private readonly ICheckoutService checkoutService;

        public ShoppingCartViewModel(ICart cart, ICheckoutService checkoutService)
        {
            this.cart = cart;
            this.checkoutService = checkoutService;

            CheckoutCommand = new RelayCommand(Checkout);
            EmptyCartCommand = new RelayCommand(EmptyCart);

            InitCart();
        }

        private void EmptyCart()
        {
            cart.Empty();
            CartContent.Clear();
            TotalPrice = 0;
        }

        private void Checkout()
        {
            try
            {
                if (!cart.ShoppingCart.Any())
                {
                    throw new InvalidOperationException("Can't checkout an empty cart.");
                }

                bool isValid = checkoutService.ValidateCard(CrediCardNumber, ExpirationMonth, ExpirationYear, CardCC);

                if (isValid)
                {
                    MessageBox.Show($"Total: {TotalPrice}", "Thanks For Shopping!");
                    EmptyCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString(), MessageBoxButton.OK);
            }
        }

        private void RemoveFromCart(ProductBase item)
        {
            cart.Remove(item);
            CartContent.Remove(item);
            TotalPrice = cart.Total;
            Discount = cart.Discount;
        }
        private void InitCart()
        {
            CartContent = new ObservableCollection<ProductBase>(cart.ShoppingCart);
            TotalPrice = cart.Total;
            Discount = cart.Discount;
        }
    }
}
