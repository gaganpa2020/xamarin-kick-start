namespace ShabdkoshApp1._0.Views
{
	using ShabdkoshApp1._0.Contracts;
	using ShabdkoshApp1._0.Models;
    using ShabdkoshApp1._0.Notifications;
    using ShabdkoshApp1._0.ViewModels;
	using System;
	using System.ComponentModel;
	using Xamarin.Forms;

	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

		INotificationManager notificationManager;
		int notificationNumber = 0;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();

			notificationManager = DependencyService.Get<INotificationManager>();
			notificationManager.NotificationReceived += (sender, eventArgs) =>
			{
				var evtData = (NotificationEventArgs)eventArgs;
				ShowNotification(evtData.Title, evtData.Message);
			};
		}

		void OnScheduleClick(object sender, EventArgs e)
		{
			notificationNumber++;
			string title = $"Local Notification #{notificationNumber}";
			string message = $"You have now received {notificationNumber} notifications!";
			notificationManager.ScheduleNotification(title, message);
		}

		void ShowNotification(string title, string message)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				var msg = new Label()
				{
					Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
				};
				stackLayout.Children.Add(msg);
			});
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item.
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}