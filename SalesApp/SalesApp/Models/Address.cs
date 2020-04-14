using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class Address : ModelBase
    {
        public long Id { get; set; }
        public string AddressHash { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Note { get; set; }

        public long? AddressStatusId { get; set; }
        public AddressStatus AddressStatus { get; set; }

        public string StatusDisplay
        {
            get
            {
                if (AddressStatus == null)
                {
                    return "Status: None set";
                }

                return "Status: " + AddressStatus.Name;
            }
        }

        public bool ShowAlert => !String.IsNullOrEmpty(Note) || AddressStatus != null || (UserAddressInteractions != null && UserAddressInteractions.Any(x => x.InteractionType != null && (x.InteractionType.Name.Contains("Sale") || x.InteractionType.Name.Contains("Moderate") || x.InteractionType.Name.Contains("High"))));

        public string AlertIcon
        {
            get
            {
                if (ShowAlert)
                {
                    if (AddressStatus != null && AddressStatus.Name == "Do Not Knock")
                    {
                        return "ic_warning_red.png";
                    }
                    else if ((UserAddressInteractions != null && UserAddressInteractions.Any(x => x.InteractionType != null && x.InteractionType.Name.Contains("Sale")))
                             || (AddressStatus != null && AddressStatus.Name == "Sale"))
                    {
                        return "ic_money_green.png";
                    }
                    else
                    {
                        return "ic_info_outline_blue.png";
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        public List<UserAddressInteraction> UserAddressInteractions { get; set; }

        public string LastInteraction
        {
            get
            {
                if (this.UserAddressInteractions == null)
                    this.UserAddressInteractions = new List<UserAddressInteraction>();

                if (this.UserAddressInteractions.Count > 0)
                {
                    return "Last activity: " + this.UserAddressInteractions.OrderByDescending(x => x.DateTime.ToLocalTime())
                               .FirstOrDefault().InteractionTimeDisplay.ToString();
                }
                else
                {
                    return "Last activity: N/A";
                }
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                if (this.UserAddressInteractions == null)
                    this.UserAddressInteractions = new List<UserAddressInteraction>();

                if (this.UserAddressInteractions.Count > 0)
                {
                    return this.UserAddressInteractions.OrderByDescending(x => x.DateTime.ToLocalTime())
                        .FirstOrDefault().updated_at;
                }
                else
                {
                    return this.updated_at;
                }
            }
        }


        public string AddressDisplay => this.Address1 + ", " + this.City + ", " + this.Province + " " + this.PostalCode;

        public string CityStateZip => this.City + ", " + this.Province + " " + this.PostalCode;

        public Address()
        {
            this.UserAddressInteractions = new List<UserAddressInteraction>();

        }
    }
}
