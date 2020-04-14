using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class UserProductAssignment : ModelBase
    {
        public long Id { get; set; }


        public long ProductId { get; set; }
        public Product Product { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }


        public UserProductAssignment()
        {

        }

    }
}
