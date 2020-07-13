using Playground.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesPage : ContentPage
	{
		public NotesPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = await App.Database.GetNoteAsync();
		}

		async void OnNoteAddedClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NoteEntryPage()
			{
				BindingContext = new Note()
			});
		}

		async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				await Navigation.PushAsync(new NoteEntryPage()
				{
					BindingContext = e.SelectedItem as Note
				});
			}
		}

	}
}