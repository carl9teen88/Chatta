using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatta.Models;

namespace Chatta.Services.Interface
{
    public interface IUserService : IService
    {
        User GetUser(int userId);
        IQueryable<User> GetUsers();
    }

}
