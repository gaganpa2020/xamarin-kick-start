using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.Models
{
    public class UserAddressInteraction : ModelBase
    {
        public long Id { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }


        public long AddressId { get; set; }
        public Address Address { get; set; }


        public long InteractionTypeId { get; set; }
        public InteractionType InteractionType { get; set; }


        public long? ProductId { get; set; }
        public Product Product { get; set; }


        public string Note { get; set;}

        public DateTimeOffset DateTime { get; set; }



        [JsonIgnore]
        public string InteractionTimeDisplay => this.DateTime.ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");

        [JsonIgnore]
        public string InteractionTypeDisplay => this.InteractionType.Name;

        [JsonIgnore]
        public string ProductDisplay => this.Product != null ? Product.Name : "N/A";

        [JsonIgnore]
        public string UserIconUrl 
        {
            get
            {
                try
                {
                    return "https://ui-avatars.com/api/?rounded=true&name=" + this.User.FirstName[0] + " "+ this.User.LastName[0];
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }


        public UserAddressInteraction()
        {

        }
    }
}
