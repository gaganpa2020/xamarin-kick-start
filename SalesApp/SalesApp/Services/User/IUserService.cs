using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string token);
    }
}
