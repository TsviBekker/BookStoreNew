using BookStore.Service.Context;
using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.Generic;

namespace BookStore.Service.Repositories.JournalRepo
{
    public class JournalRepository : GenericRepository<Journal>, IJournalRepository
    {
        public JournalRepository(BookStoreContextFactory context) : base(context)
        {
        }
    }
}
