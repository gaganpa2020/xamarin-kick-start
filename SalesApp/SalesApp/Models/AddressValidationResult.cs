using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Models
{
    public class AddressValidationResult
    {
        public bool Valid { get; set; }
        public Address Address { get; set; }
    }
}
