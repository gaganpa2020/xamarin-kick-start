using ShabdkoshApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShabdkoshApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WordDetailPage : ContentPage
	{
		private WordDetailsViewModel wordDetailsViewModel;

		public WordDetailPage(WordDetailsViewModel wordDetailsViewModel)
		{
			InitializeComponent();
			BindingContext = this.wordDetailsViewModel = wordDetailsViewModel;
		}
	}
}