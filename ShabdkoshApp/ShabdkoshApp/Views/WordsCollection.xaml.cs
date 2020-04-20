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
	public partial class WordsCollection : ContentPage
	{
		WordsCollectionViewModel wordsCollectionViewModel;
		public WordsCollection()
		{
			InitializeComponent();
			BindingContext = wordsCollectionViewModel = new WordsCollectionViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (wordsCollectionViewModel.Items.Count == 0)
			{
				wordsCollectionViewModel.LoadWordItemsCommand.Execute(null);
			}
		}
	}
}