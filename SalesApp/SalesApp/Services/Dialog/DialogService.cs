using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace SalesApp.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowToast(string message, Color color)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(5000);
            toastConfig.SetBackgroundColor(color);
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
