using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext Context;

        protected RepositoryBase(DataContext context)
        {
            Context = context;
        }
        public async Task CreateAsync(T entity) => await Context.Set<T>().AddAsync(entity);
       
        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

      
    }
}