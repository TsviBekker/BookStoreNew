using BookStore.Service.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Service.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreContextFactory contextFactory;
        public GenericRepository(BookStoreContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task Add(T entity)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
        }

        //public async Task Complete()
        //{
        //    using (var context = contextFactory.CreateDbContext())
        //    {
        //        await context.SaveChangesAsync();
        //    }
        //}

        public async Task Delete(int id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(string id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public async Task Update(T item, int id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FindAsync(id);
                context.Entry<T>(entity).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
