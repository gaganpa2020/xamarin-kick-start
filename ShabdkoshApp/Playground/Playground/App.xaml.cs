using Playground.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	public partial class App : Application
	{
		static NoteDatabase database;

		public static NoteDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
				}
				return database;
			}
		}

		public App()
		{
			InitializeComponent();			
			MainPage = new NavigationPage(new NotesPage());
		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		protected override void OnSleep()
		{
			base.OnSleep();
		}

		protected override void OnResume()
		{
			base.OnResume();
		}
	}
}
