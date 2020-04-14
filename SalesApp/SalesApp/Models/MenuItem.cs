using System;
using System.Collections.Generic;
using System.Text;
using SalesApp.Services.Enums;

namespace SalesApp.Models
{
    public class MenuItem
    {
        public string Title { get; set;}
        public MenuItemType MenuItemType { get; set; }
        public Type ViewModelType { get; set; }
        public bool IsEnabled { get; set; }
    }
}
