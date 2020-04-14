using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public string Token { get; set; }
        public string AgentID { get; set; }

        public string UserIconUrl
        {
            get
            {
                try
                {
                    return "https://ui-avatars.com/api/?rounded=true&size=128&name=" + this.FirstName[0] + " " + this.LastName[0];
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

    }
}
