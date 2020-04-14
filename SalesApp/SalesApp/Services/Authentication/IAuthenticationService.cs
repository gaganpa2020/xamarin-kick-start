using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
