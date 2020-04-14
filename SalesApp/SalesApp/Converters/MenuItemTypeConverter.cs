using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SalesApp.Services.Enums;
using Xamarin.Forms;

namespace SalesApp.Converters
{
    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;


            switch (menuItemType)
            {
                case MenuItemType.Dashboard:
                    return "ic_dashboard_blue.png";
                case MenuItemType.SalesManagement:
                    return "ic_map_blue.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
