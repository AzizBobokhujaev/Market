using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.DataTransferObjects.Users;
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

        public async Task<List<UserDto>> GetAllUsers()
        {
           return  await (from u in _context.Users
                join ur in _context.UserRoles on u.Id equals ur.UserId
                join r in _context.Roles on ur.RoleId equals r.Id
                select new UserDto()
                {
                    Email = u.Email,
                    Id = u.Id,
                    UserName = u.UserName,
                    RoleId = r.Id
                }).ToListAsync();
        }

        public async Task<IdentityRole<int>> GetRoleByUserId(int userId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
        }


        public async Task<int> AddToRole(User user, int roleId)
        {
            var userRoles = new IdentityUserRole<int>
                {
                    UserId = user.Id,
                    RoleId = roleId
                };
            var result = await _context.UserRoles.AddAsync(userRoles); 
            return   await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRole(int userId, int roleId)
        {
            var role = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId);
            role.RoleId = roleId; 
            
            var result = _context.UserRoles.Update(role);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteRole(User user)
        {
            var role = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id);
            var result =_context.UserRoles.Remove(role);
            return await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}