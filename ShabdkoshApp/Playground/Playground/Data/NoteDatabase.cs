namespace Playground.Data
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Threading.Tasks;
	using Playground.Models;
	using SQLite;


	public class NoteDatabase
	{
		readonly SQLiteAsyncConnection _database;

		public NoteDatabase(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Note>().Wait();
		}

		public Task<List<Note>> GetNoteAsync()
		{
			return _database.Table<Note>().ToListAsync();
		}

		public Task<Note> GetNoteAsync(int id)
		{
			return _database.Table<Note>()
				.Where(i => i.ID == id)
				.FirstOrDefaultAsync();
		}

		public Task<int> SaveNoteAsync(Note note)
		{
			if(note.ID!=0)
			{
				return _database.UpdateAsync(note);
			}
			else
			{
				return _database.InsertAsync(note);
			}
		}

		public Task<int> DeleteNoteAsync(Note note)
		{
			return _database.DeleteAsync(note);
		}
	}
}
