using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);  
    }
}