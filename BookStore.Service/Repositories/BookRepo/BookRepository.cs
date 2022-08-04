using BookStore.Service.Context;
using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.Generic;

namespace BookStore.Service.Repositories.BookRepo
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContextFactory context) : base(context)
        {
        }
    }
}
