using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using SalesApp.Models;
using SalesApp.Services.Address;
using SalesApp.ViewModels.Base;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class AddressDetailViewModel : ViewModelBase
    {
        IAddressService _addressService;

        private Address _address;
        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged(() => Address);
            }
        }

        private ObservableCollection<UserAddressInteraction> _interactions;
        public ObservableCollection<UserAddressInteraction> Interactions
        {
            get => _interactions;
            set
            {
                _interactions = value;
                RaisePropertyChanged(() => Interactions);
            }
        }

        public string CurrentDisposition
        {
            get
            {
                if (Address.AddressStatus != null)
                {
                    return Address.AddressStatus.Name;
                }
                else
                {
                    return "";
                }
            }
        }

        private string _addressNote;
        public string AddressNote
        {
            get => _addressNote;
            set
            {
                _addressNote = value;
                RaisePropertyChanged(() => AddressNote);
            }
        }
        private List<AddressStatus> _addressStatuses;

    
        public ICommand GotoAddInteractionCommand => new Command(GoToAddInteractionAsync);
        public ICommand InteractionSelectedCommand => new Command<UserAddressInteraction>(GoToExistingInteractionAsync);
        public ICommand ShowAddressContextActionsCommand => new Command(ShowAddressContextActionAsync);

        public AddressDetailViewModel(IAddressService addressService)
        {
            _addressService = addressService;
            AddressNote = "";
        }

        public override async Task InitializeAsync(object navigationData)
        {
            this.IsBusy = true;
            UserDialogs.Instance.ShowLoading("Loading Data");

            var addressTemp = navigationData as Address;
            this.Address = await _addressService.GetAddressInfoAsync(addressTemp.Id);
            this.Interactions = new ObservableCollection<UserAddressInteraction>(this.Address.UserAddressInteractions);

            AddressNote = Address.Note;

            _addressStatuses = await _addressService.GetAddressStatusesAsync();

            UserDialogs.Instance.HideLoading();
            this.IsBusy = false;
        }


        public async void ShowAddressContextActionAsync()
        {
            var cfg = new ActionSheetConfig()
                .SetTitle("Set Status")
                .SetMessage("Update Address Status")
                .SetCancel("Cancel")
                .SetUseBottomSheet(false);

            foreach (var status in _addressStatuses)
            {
                cfg.Add(status.Name, async () => { await UpdateAddressStatusAsync(status.Id); }, null);
            }
            cfg.Add("Not Set", async () => { await UpdateAddressStatusAsync(null); }, null);

            UserDialogs.Instance.ActionSheet(cfg);
        }


        public async Task UpdateAddressStatusAsync(long? statusId)
        {
            UserDialogs.Instance.ShowLoading("Saving");

            AddressStatus status = null;
            if (statusId != null)
            {
                status = _addressStatuses.FirstOrDefault(rec => rec.Id == statusId);
            }

            await _addressService.SetAddressStatusAsync(Address, status);

            Address.AddressStatus = status;
            RaisePropertyChanged(() => Address);

            UserDialogs.Instance.HideLoading();
        }

        public async void GoToAddInteractionAsync()
        {
            await NavigationService.NavigateToAsync<AddAddressInteractionViewModel>(Address);
        }

        public async void GoToExistingInteractionAsync(UserAddressInteraction interaction)
        {
            interaction.Address = Address;
            await NavigationService.NavigateToAsync<AddressInteractionDetailViewModel>(interaction);
        }
    }
}
