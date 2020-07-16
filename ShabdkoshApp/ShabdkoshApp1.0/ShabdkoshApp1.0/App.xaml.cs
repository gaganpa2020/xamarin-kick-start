using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShabdkoshApp1._0.Services;
using ShabdkoshApp1._0.Views;
using System.IO;
using ShabdkoshApp1._0.Contracts;

namespace ShabdkoshApp1._0
{
	public partial class App : Application
	{
		//TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
		//To debug on Android emulators run the web backend against .NET Core not IIS
		//If using other emulators besides stock Google images you may need to adjust the IP address
		public static string AzureBackendUrl =
			DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
		public static bool UseMockDataStore = true;

		static SqliteDataStore database;

		public static SqliteDataStore Database
		{
			get
			{
				if (database == null)
				{
					database = new SqliteDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
				}
				return database;
			}
		}

		public App()
		{
			InitializeComponent();

			//if (UseMockDataStore)
			//	DependencyService.Register<MockDataStore>();
			//else
			//	DependencyService.Register<AzureDataStore>();

			// use the dependency service to get a platform-specific implementation and initialize it
			
			DependencyService.Get<INotificationManager>().Initialize();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
