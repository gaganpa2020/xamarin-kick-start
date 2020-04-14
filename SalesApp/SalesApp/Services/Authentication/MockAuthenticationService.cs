using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services.Authentication
{
    public class MockAuthenticationService : IAuthenticationService
    {
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            await Task.Delay(1000);
            if (password == "bad")
            {
                return null;
            }
            else
            {
                return new User()
                {
                    Id = "10234",
                    Email = "john@test.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Token = "38259836-F79C-4913-BC20-B5B9457E35FE",
                    AgentID = "2452524"
                };
            }
        }
    }
}
