using ShabdkoshApp.Models;
using ShabdkoshApp.ViewModels;
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

		void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			WordItem word = args.SelectedItem as WordItem;
			if (word == null)
				return;

			Navigation.PushAsync(new WordDetailPage(new WordDetailsViewModel(word)), true);
			lstWords.SelectedItem = null;
		}
	}
}