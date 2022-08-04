using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.Generic;

namespace BookStore.Service.Repositories.BookRepo
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
