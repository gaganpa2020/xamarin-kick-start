using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{

    public abstract class ModelBase
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
