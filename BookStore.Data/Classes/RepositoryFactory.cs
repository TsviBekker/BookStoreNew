using BookStore.Data.Interfaces;
using BookStore.Models;

namespace BookStore.Data
{
    public class RepositoryFactory
    {
        public static IRepository<ProductBase> GetProductRepository() => FileSystemDataContext.Instance;
    }
}
