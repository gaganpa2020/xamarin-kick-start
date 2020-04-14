using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.Models
{
    public class InteractionType : ModelBase
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<UserAddressInteraction> UserAddressInteractions { get; set; }


        public InteractionType()
        {

        }
    }
}
