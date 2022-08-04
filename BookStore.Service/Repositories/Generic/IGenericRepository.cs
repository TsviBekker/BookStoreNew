using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(string id);
        Task Update(T entity, int id);
        Task Add(T entity);
        Task Delete(int id);
        //Task Complete();
    }
}
