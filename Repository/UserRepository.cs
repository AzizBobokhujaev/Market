using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User> ,IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        
        

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> AddToRole(User user, string role)
        {
            var roleId = 0;
            if (role == "Контентщик")
            {
                roleId = 2;
            }

            var userRoles = new IdentityUserRole<int>
                {
                    UserId = user.Id,
                    RoleId = roleId
                }
                ;
            var result = await _context.UserRoles.AddAsync(userRoles); 
            return await _context.SaveChangesAsync();
        }
    }
}