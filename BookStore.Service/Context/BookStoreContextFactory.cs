using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Context
{
    public class BookStoreContextFactory
    {
        public BookStoreContextFactory()
        {

        }

        public BookStoreContext CreateDbContext(string connectionString = "BookStoreContext")
        {
            return new BookStoreContext(connectionString);
        }
    }
}
