using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SalesApp.Models;
using SalesApp.Services.Address;
using SalesApp.ViewModels.Base;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class AddAddressViewModel : ViewModelBase
    {
        private readonly IAddressService _addressService;

        private bool _addressValidated;
        public bool AddressValidated
        {
            get => _addressValidated;
            set
            {
                _addressValidated = value;
                RaisePropertyChanged(() => AddressValidated);
            }
        }


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



        public ICommand ValidateAddressCommand => new Command(async () => await ValidateAddressAsync());
        public ICommand SaveAddressCommand => new Command(async () => await SaveAddressAsync());

        public AddAddressViewModel(IAddressService addressService)
        {
            _addressService = addressService;

            AddressValidated = false;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            this.Address = new Address();
            Address.Address1 = navigationData as string;
            Address.City = Globals.Location.City;
            Address.Province = Globals.Location.State;
            Address.PostalCode = Globals.Location.Zip;
            RaisePropertyChanged(() => Address);
        }


        public async Task ValidateAddressAsync()
        {
            IsBusy = true;

            var addressValidation = await _addressService.ValidateAddressAsync(Address);

            if (addressValidation.Valid)
            {
                AddressValidated = true;

                Address.Address1 = addressValidation.Address.Address1;
                Address.Address2 = addressValidation.Address.Address2;
                Address.City = addressValidation.Address.City;
                Address.Province = addressValidation.Address.Province;
                Address.PostalCode = addressValidation.Address.PostalCode;
                Address.Latitude = addressValidation.Address.Latitude;
                Address.Longitude = addressValidation.Address.Longitude;
                Address.County = addressValidation.Address.County;
                Address.Country = addressValidation.Address.Country;

                RaisePropertyChanged(() => Address);

                DialogService.ShowToast("Address valid!", System.Drawing.Color.Green);
            }
            else
            {
                AddressValidated = false;
                DialogService.ShowToast("Address could not be validated", System.Drawing.Color.Red);
            }

            IsBusy = false;
        }

        public async Task SaveAddressAsync()
        {
            IsBusy = true;

            var address = await _addressService.SaveNewAddressAsync(Address);

            await NavigationService.RemoveBackStackAsync();
            await NavigationService.NavigateToAsync<AddressDetailViewModel>(address);
            await NavigationService.RemoveBackStackAsync();

        }
    }
}
