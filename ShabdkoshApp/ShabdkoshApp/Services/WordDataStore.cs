using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShabdkoshApp.Models;

namespace ShabdkoshApp.Services
{
	public class WordDataStore : IDataStore<WordItem>
	{
		readonly List<WordItem> items;

		public WordDataStore()
		{
			items = new List<WordItem>()
			{
				new WordItem
				{
					Id = Guid.NewGuid().ToString(),
					Word = "First word",
					Meaning="This is an example."
				}
			};
		}

		public async Task<bool> AddItemAsync(WordItem item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(WordItem item)
		{
			var oldItem = items.Where((WordItem arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((WordItem arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<WordItem> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<WordItem>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}