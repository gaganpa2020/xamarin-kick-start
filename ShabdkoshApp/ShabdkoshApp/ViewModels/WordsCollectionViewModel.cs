using ShabdkoshApp.Models;
using ShabdkoshApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShabdkoshApp.ViewModels
{
	public class WordsCollectionViewModel : BaseViewModel
	{
		public IDataStore<WordItem> LocalDataStore => DependencyService.Get<IDataStore<WordItem>>();
		public ObservableCollection<WordItem> Items { get; set; }

		public Command LoadWordItemsCommand { get; set; }

		public WordsCollectionViewModel()
		{
			Title = "Browse";
			Items = new ObservableCollection<WordItem>();
			LoadWordItemsCommand = new Command(async () => { await LoadData(); });
		}

		private async Task LoadData()
		{
			Items.Clear();
			var items = await LocalDataStore.GetItemsAsync(true);
			foreach (var item in items)
			{
				Items.Add(item);
			}
		}
	}
}
