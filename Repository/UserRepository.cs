using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
        public async Task<User> GetUsers()
        {
           return await Context.Users.FindAsync();
        }

        
    }
}