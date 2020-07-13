using Playground.Models;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
		public NoteEntryPage()
		{
			InitializeComponent();
		}

		async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var note = (Note)BindingContext;
			
			if (string.IsNullOrWhiteSpace(note.Filename))
			{
				var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
				File.WriteAllText(fileName, note.Text);
			}
			else
			{
				File.WriteAllText(note.Filename, note.Text);
			}

			await Navigation.PopAsync();
		}

		async void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			var note = (Note)BindingContext;

			if(File.Exists(note.Filename))
			{
				File.Delete(note.Filename);
			}
			
			await Navigation.PopAsync();
		}
	}
}