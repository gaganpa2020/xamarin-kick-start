using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;
using SalesApp.ViewModels.Base;

namespace SalesApp.ViewModels
{
    public class AddressInteractionDetailViewModel : ViewModelBase
    {
        private UserAddressInteraction _interaction;
        public UserAddressInteraction Interaction
        {
            get => _interaction;
            set
            {
                _interaction = value;
                RaisePropertyChanged(() => Interaction);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Interaction = navigationData as UserAddressInteraction;
        }
    }
}
