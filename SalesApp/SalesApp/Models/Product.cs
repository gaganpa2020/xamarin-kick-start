using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class Product : ModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IPSIdentifier { get; set; }


        public List<UserProductAssignment> UserProductAssignments { get; set; }
        public List<UserAddressInteraction> UserAddressInteractions { get; set; }

        public Product()
        {

        }
    }
}
