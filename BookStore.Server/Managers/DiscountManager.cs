using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Server.Managers
{
    //this is a class for managing all discounts
    internal class DiscountManager
    {
        public decimal Discount { get; private set; }
        private readonly ICollection<ProductBase> cart;
        public DiscountManager(ICollection<ProductBase> cart) //Dependency Injection
        {
            this.cart = cart;
        }
        public decimal CalculateDiscount()
        {
            Discount = 0;
            if (cart.Count >= 3) //if there are 3 items or more
                ThreePlusOneDiscount(); //activate discount
            else if (DateTime.Now.Day.Equals(14) && DateTime.Now.Month.Equals(2)) //if its valentines day 
                ValentinesDayDiscount(); //activate discount
            return Discount;
        }
        //cheapest item is free
        private void ThreePlusOneDiscount()
        {
            decimal lowestPrice = decimal.MaxValue;
            foreach (var item in cart)
            {
                if (item.BasePrice < lowestPrice)
                    lowestPrice = item.BasePrice;
            }
            Discount += lowestPrice;
        }
        //all romance books are 50% off
        private void ValentinesDayDiscount()
        {
            foreach (Book book in cart.Where(p => p.GetType().Equals(typeof(Book))))
            {
                if (book.Genres.Contains(BookGenre.Ramance))
                {
                    Discount += book.BasePrice / 2;
                }
            }
        }
    }
}
