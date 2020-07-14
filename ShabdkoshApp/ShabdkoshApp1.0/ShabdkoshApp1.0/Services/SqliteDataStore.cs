namespace ShabdkoshApp1._0.Services
{
	using ShabdkoshApp1._0.Models;
	using SQLite;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class SqliteDataStore : IDataStore<Item>
	{
		readonly SQLiteAsyncConnection _database;
		public SqliteDataStore(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Item>().Wait();
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			int addResult = await _database.InsertAsync(item);
			return addResult > 0 ? true : false;
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			bool deleteResult = await DeleteItemAsync(item.Id);
			if(deleteResult)
			{
				return await AddItemAsync(item);
			}

			return deleteResult;
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = await GetItemAsync(id);
			return await _database.DeleteAsync(oldItem) > 0 ? true : false;
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await _database.Table<Item>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await _database.Table<Item>().ToListAsync();
		}
	}
}