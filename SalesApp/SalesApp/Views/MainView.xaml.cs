using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : MasterDetailPage
	{
		public MainView ()
		{
			InitializeComponent ();
		}

	    private void MainView_OnIsPresentedChanged(object sender, EventArgs e)
	    {
	        if (Device.RuntimePlatform == Device.iOS)
	        {
	            if (IsPresented)
	            {
	                var currentPage = Detail;
	                currentPage.FadeTo(0.5);
	            }
	            else
	            {
	                var currentPage = Detail;
	                currentPage.FadeTo(1.0);
	            }
	        }
	    }
    }
}