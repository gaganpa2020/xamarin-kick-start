using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Services.Authentication;
using SalesApp.Services.Navigation;
using SalesApp.ViewModels.Base;
using Xamarin.Forms;

namespace SalesApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    InitApp();
		    InitNavigation();
        }


	    private void InitApp()
	    {
	        if (Globals.UseMocks)
	            ViewModelLocator.UpdateDependencies(Globals.UseMocks);
	    }

	    private Task InitNavigation()
	    {
	        var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
	    }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
