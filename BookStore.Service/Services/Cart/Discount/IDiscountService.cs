using BookStore.Service.Context.Models;
using System.Collections.Generic;

namespace BookStore.Service.Services.Cart.Discount
{
    public interface IDiscountService
    {
        decimal CalcDiscount(IEnumerable<ProductBase> products);
    }
}
