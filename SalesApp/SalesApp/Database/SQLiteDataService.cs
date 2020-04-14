using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SalesApp.Models;
using SQLite;

namespace SalesApp.Database
{
    public class SQLiteDataService : ILocalDataService
    {
        private SQLiteConnection _database;

        public void Initialize()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SalesAppDb.db3");
                _database = new SQLiteConnection(dbPath);
            }

            _database.CreateTable<User>();
        }

        public void CreateUser(User user)
        {
            _database.Insert(user);
        }

        public User GetUser()
        {
            return _database.Table<User>().FirstOrDefault();
        }

        public void DeleteUser(User user)
        {
            _database.Execute("DELETE FROM User");
        }
    }
}
