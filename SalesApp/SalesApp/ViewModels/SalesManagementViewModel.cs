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
    public class SalesManagementViewModel : ViewModelBase
    {
        private IAddressService _addressService;

        private ObservableCollection<Address> _addresses;
        public ObservableCollection<Address> Addresses
        {
            get => _addresses;
            set
            {
                _addresses = value;
                RaisePropertyChanged(() => Addresses);
            }
        }

        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                RaisePropertyChanged(() => Header);
            }
        }

        private bool _noData;
        public bool NoData
        {
            get => _noData;
            set
            {
                _noData = value;
                RaisePropertyChanged(() => NoData);
            }
        }



        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                RaisePropertyChanged(() => SearchText);
            }
        }

        private bool _showSearchResults;
        public bool ShowSearchResults
        {
            get => _showSearchResults;
            set
            {
                _showSearchResults = value;
                RaisePropertyChanged(() => ShowSearchResults);
            }
        }


        private ObservableCollection<Address> _addressSearchResults;
        public ObservableCollection<Address> AddressSearchResults
        {
            get => _addressSearchResults;
            set
            {
                _addressSearchResults = value;
                RaisePropertyChanged(() => AddressSearchResults);
            }
        }


        public ICommand SearchCommand => new Command(async () => await SearchAddressesAsync());
        public ICommand CancelSearchCommand => new Command(async () => await CancelAddressSearchAsync());
        public ICommand AddAddressCommand => new Command(async () => await AddAddressAsync());
        public ICommand AddressSelectedCommand => new Command<Address>(SelectAddressAsync);

        public SalesManagementViewModel(IAddressService addressService)
        {
            _addressService = addressService;

            ShowSearchResults = false;
            NoData = false;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            this.IsBusy = true;

            if (navigationData == null)
            {
                var addrs = await _addressService.GetNearbyAddressesAsync(Globals.Location.Latitude,
                    Globals.Location.Longitude);
                this.Addresses = new ObservableCollection<Address>(addrs.OrderByDescending(x=>x.LastUpdated));
                this.Header = "Nearby Addresses";
            }
            else
            {
                var data = navigationData as DashboardData;
                this.Addresses = new ObservableCollection<Address>(data.Addresses);
                this.Header = data.Header;
            }

            RaisePropertyChanged(() => Addresses);

            if (Addresses.Count == 0)
            {
                NoData = true;
            }

            this.IsBusy = false;
        }


        public async Task SearchAddressesAsync()
        {
            ShowSearchResults = true;

            var searchResults =
                await _addressService.SearchAddressesAsync(this.SearchText, Globals.Location.Zip);

            this.AddressSearchResults = new ObservableCollection<Address>(searchResults);
            RaisePropertyChanged(() => AddressSearchResults);

        }

        public async Task CancelAddressSearchAsync()
        {
            ShowSearchResults = false;

            this.AddressSearchResults = new ObservableCollection<Address>();
            RaisePropertyChanged(() => AddressSearchResults);
        }

        public async Task AddAddressAsync()
        {
            await NavigationService.NavigateToAsync<AddAddressViewModel>(this.SearchText);
        }

        public async void SelectAddressAsync(Address address)
        {
            await NavigationService.NavigateToAsync<AddressDetailViewModel>(address);
        }
    }
}
