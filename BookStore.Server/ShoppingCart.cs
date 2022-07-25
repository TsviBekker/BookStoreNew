using BookStore.Models;
using BookStore.Server.Interfaces;
using BookStore.Server.Managers;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Server
{
    //this is a class for managing the shopping cart of the customer
    public class ShoppingCart : ICart
    {
        //Singleton
        private static ShoppingCart instance;
        public static ShoppingCart Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShoppingCart();
                return instance;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in cart)
                {
                    total += item.BasePrice;
                }
                return total - Discount;
            }
            private set { }
        }
        public decimal Discount
        {
            get => discountManager.CalculateDiscount();
            private set { }
        }
        private readonly ICollection<ProductBase> cart;
        private DiscountManager discountManager;
        //Ctor
        public ShoppingCart()
        {
            cart = new List<ProductBase>();
            discountManager = new DiscountManager(cart);
        }
        public List<ProductBase> GetCart() => cart.ToList();
        //Add to cart
        public void Add(ProductBase item) => cart.Add(item);
        //Remove from cart
        public void Remove(ProductBase item)
        {
            cart.Remove(item);
            TotalPrice -= item.BasePrice;
        }
        //Empty cart
        public void Empty()
        {
            cart.Clear();
            TotalPrice = 0;
        }
    }
}
