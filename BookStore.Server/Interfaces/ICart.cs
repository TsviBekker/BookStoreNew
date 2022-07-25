using BookStore.Models;

namespace BookStore.Server.Interfaces
{
    //Cart interface
    internal interface ICart
    {
        void Add(ProductBase item);
        void Remove(ProductBase item);
        void Empty();
    }
}
