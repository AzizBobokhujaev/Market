using System;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public  UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUsers()
        {
            var users = await _repository.GetUsers();
            if (users == null)
                throw new Exception(String.Empty);
            return users;
        }
    }
}