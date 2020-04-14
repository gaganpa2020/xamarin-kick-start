using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Models
{
    public class AddressBuckets
    {
        public List<Address> Addresses { get; set; }
        public int RecentAddressesCount => Addresses?.Count ?? 0;

        public List<Address> Interactions { get; set; }
        public int RecentInteractionsCount => Interactions?.Count ?? 0;

        public List<Address> Sales { get; set; }
        public int SalesAddressesCount => Sales?.Count ?? 0;

        public List<Address> Promising { get; set; }
        public int PromisingAddressesCount => Promising?.Count ?? 0;
    }
}
