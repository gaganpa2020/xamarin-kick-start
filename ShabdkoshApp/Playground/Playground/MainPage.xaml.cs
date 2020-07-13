using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Playground
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
		public MainPage()
		{
			InitializeComponent();

			if (File.Exists(_fileName))
			{
				editor.Text = File.ReadAllText(_fileName);
			}
		}

		public void OnSaveButtonClicked(object sender, EventArgs e)
		{
			File.WriteAllText(_fileName, editor.Text);
		}

		public void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			if (File.Exists(_fileName))
			{
				File.Delete(_fileName);
			}

			editor.Text = string.Empty;
		}
	}
}
