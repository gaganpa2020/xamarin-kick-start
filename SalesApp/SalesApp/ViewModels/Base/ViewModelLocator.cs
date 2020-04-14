using SalesApp.Services.Address;
using SalesApp.Services.Authentication;
using SalesApp.Services.Dialog;
using SalesApp.Services.Navigation;
using SalesApp.Services.Product;
using SalesApp.Services.RequestProvider;
using System;
using System.Globalization;
using System.Reflection;
using SalesApp.Database;
using SalesApp.Services;
using SalesApp.Services.Zones;
using TinyIoC;
using Xamarin.Forms;

namespace SalesApp.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            _container.Register<LoginViewModel>();
            _container.Register<MainViewModel>();
            _container.Register<MenuViewModel>();
            _container.Register<AddressDetailViewModel>();
            _container.Register<AddAddressInteractionViewModel>();
            _container.Register<AddAddressViewModel>();
            _container.Register<AddAddressInteractionViewModel>();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IDialogService, DialogService>();
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<ILocalDataService, SQLiteDataService>();
        }

        // this method could be used to setup mocks if needed
        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                _container.Register<IAuthenticationService, MockAuthenticationService>();
                _container.Register<IAddressService, MockAddressService>();
                _container.Register<IProductService, MockProductService>();
                _container.Register<IZoneService, MockZoneService>();
                _container.Register<IUserService, MockUserService>();
                UseMockService = true;
            }
            else
            {
                // register any real services here
                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Element view = bindable as Element;
            if (view == null)
            {
                return;
            }

            Type viewType = view.GetType();
            string viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            string viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            Type viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            object viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
