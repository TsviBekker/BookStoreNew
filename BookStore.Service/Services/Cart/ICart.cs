using BookStore.Service.Context.Models;
using System.Collections.Generic;

namespace BookStore.Service.Services.Cart
{
    public interface ICart
    {
        decimal Total { get; }
        decimal Discount { get; }
        List<ProductBase> ShoppingCart { get; set; }
        void Add(ProductBase item);
        void Remove(ProductBase item);
        void Empty();
    }
}
