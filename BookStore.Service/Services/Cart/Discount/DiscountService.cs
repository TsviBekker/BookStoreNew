using BookStore.Service.Context.Models;
using BookStore.Service.Context.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Services.Cart.Discount
{
    public class DiscountService : IDiscountService
    {
        public decimal Discount { get; set; }
        public DiscountService()
        {

        }
        public decimal CalcDiscount(IEnumerable<ProductBase> products)
        {
            Discount = 0;
            if (products.Count() > 2)
            {
                ThreePlusOneDiscount(products);
            }
            if (DateTime.Now.Day.Equals(14) && DateTime.Now.Month.Equals(2))
            {
                ValentinesDayDiscount(products);
            }
            return Discount;
        }

        private void ValentinesDayDiscount(IEnumerable<ProductBase> products)
        {
            foreach (var item in products.Where(p => p is Book))
            {
                if ((item as Book).Genre == BookGenre.Ramance)
                {
                    Discount += item.BasePrice / 2;
                }
            }
        }

        private void ThreePlusOneDiscount(IEnumerable<ProductBase> products)
        {
            var lowest = products.Min(x => x.BasePrice);
            Discount += lowest;
        }
    }
}
