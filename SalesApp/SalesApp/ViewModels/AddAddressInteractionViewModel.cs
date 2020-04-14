using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using SalesApp.Models;
using SalesApp.Services.Address;
using SalesApp.Services.Product;
using SalesApp.ViewModels.Base;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class AddAddressInteractionViewModel : ViewModelBase
    {
        private IAddressService _addressService;
        private IProductService _productService;

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


        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RaisePropertyChanged(() => Date);
            }
        }


        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                RaisePropertyChanged(() => Time);
            }
        }




        private int _selectedInteractionIndex;
        public int SelectedInteractionIndex
        {
            get => _selectedInteractionIndex;
            set
            {
                _selectedInteractionIndex = value;
                RaisePropertyChanged(() => SelectedInteractionIndex);
            }
        }


        private ObservableCollection<InteractionType> _interactionTypes;
        public ObservableCollection<InteractionType> InteractionTypes
        {
            get => _interactionTypes;
            set
            {
                _interactionTypes = value;
                RaisePropertyChanged(() => InteractionTypes);
            }
        }

        private int _interactionTypeSelectedIndex;
        public int InteractionTypeSelectedIndex
        {
            get => _interactionTypeSelectedIndex;
            set
            {
                _interactionTypeSelectedIndex = value;
                RaisePropertyChanged(() => InteractionTypeSelectedIndex);
            }
        }


        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }

        private int _productSelectedIndex;
        public int ProductSelectedIndex
        {
            get => _productSelectedIndex;
            set
            {
                _productSelectedIndex = value;
                RaisePropertyChanged(() => ProductSelectedIndex);
            }
        }


        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                RaisePropertyChanged(() => Note);
            }
        }

        public ICommand SaveInteractionCommand => new Command(async () => await SaveInteractionAsync());

        public AddAddressInteractionViewModel(IAddressService addressService, IProductService productService)
        {
            _addressService = addressService;
            _productService = productService;

            ProductSelectedIndex = -1;
            InteractionTypeSelectedIndex = -1;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Address = navigationData as Address;
            Date = DateTime.Now.Date;
            Time = DateTime.Now.TimeOfDay;

            var interactionTypes = await _addressService.GetInteractionTypesAsync();
            InteractionTypes = new ObservableCollection<InteractionType>(interactionTypes);
            RaisePropertyChanged(() => InteractionTypes);

            var products = await _productService.GetProductsForUser(Globals.LoggedInUser);
            Products = new ObservableCollection<Product>(products);
            RaisePropertyChanged(() => Products);
        }


        public async Task SaveInteractionAsync()
        {
            UserDialogs.Instance.ShowLoading("Saving");

            DateTime localTime = Convert.ToDateTime(Date.ToShortDateString() + " " + Time.ToString());
            localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Local);
            DateTimeOffset offset = localTime;

            UserAddressInteraction interaction = new UserAddressInteraction
            {
                UserId = Globals.LoggedInUser.Id,
                AddressId = Address.Id,
                InteractionTypeId = InteractionTypes[InteractionTypeSelectedIndex].Id,
                Note = Note,
                DateTime = offset.UtcDateTime
            };
            if (ProductSelectedIndex > -1)
            {
                interaction.ProductId = Products[ProductSelectedIndex].Id;
            }
            await _addressService.AddInteractionAsync(interaction);

            UserDialogs.Instance.HideLoading();
            
            await NavigationService.NavigateToAsync<AddressDetailViewModel>(Address);
            await NavigationService.RemoveBackStackAsync();
        }
    }
}
