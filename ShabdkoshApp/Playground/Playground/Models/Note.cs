namespace Playground.Models
{
    using SQLite;
    using System;

	public class Note
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }
	}
}
