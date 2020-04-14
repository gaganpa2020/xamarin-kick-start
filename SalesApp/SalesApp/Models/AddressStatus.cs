using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.Models
{
    public class AddressStatus : ModelBase
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<Address> Addresses { get; set; }


        public AddressStatus()
        {

        }
    }
}
