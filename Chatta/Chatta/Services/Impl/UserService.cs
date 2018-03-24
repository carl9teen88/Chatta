using System;
using System.Linq;
using Chatta.Models;
using Chatta.Services.Interface;

namespace Chatta.Services.Impl
{
    public class UserService : IUserService
    {
        ChattaDbContext context = new ChattaDbContext();

        public User GetUser(int userId)
        {
            return context.Users.FirstOrDefault(u => u.UserId == userId);            
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users;
        }
    }
}