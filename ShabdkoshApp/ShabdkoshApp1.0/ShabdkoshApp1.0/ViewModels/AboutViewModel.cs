using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShabdkoshApp1._0.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://my-sharpenotes.blogspot.com/2020/07/shabdkosh-app.html"));
		}

		public ICommand OpenWebCommand { get; }
	}
}