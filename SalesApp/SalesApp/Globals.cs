using System;
using System.Collections.Generic;
using System.Text;
using SalesApp.Models;

namespace SalesApp
{
    public static class Globals
    {
        public static bool UseMocks = true;

        public static User LoggedInUser = null;
        public static CurrentLocation Location = null;
    }
}
