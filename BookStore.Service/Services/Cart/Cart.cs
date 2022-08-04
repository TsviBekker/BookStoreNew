using BookStore.Service.Context.Models;
using BookStore.Service.Services.Cart.Discount;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Services.Cart
{
    public class Cart : ICart
    {
        public decimal Total
        {
            get
            {
                var total = ShoppingCart
                            .Aggregate(decimal.Zero, (acc, item) => acc + item.BasePrice);
                return total - Discount;
            }
        }

        public decimal Discount
        {
            get
            {
                return discountService.CalcDiscount(ShoppingCart);
            }
        }

        public List<ProductBase> ShoppingCart { get; set; }
        private readonly IDiscountService discountService;

        public Cart(IDiscountService discountService)
        {
            this.discountService = discountService;
            ShoppingCart = new List<ProductBase>();
        }

        public void Add(ProductBase item)
        {
            ShoppingCart.Add(item);
        }

        public void Empty()
        {
            ShoppingCart.Clear();
        }

        public void Remove(ProductBase item)
        {
            ShoppingCart.Remove(item);
        }
    }
}
