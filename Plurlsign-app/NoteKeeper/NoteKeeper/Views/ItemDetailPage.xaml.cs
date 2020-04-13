using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using System.Collections.Generic;
using NoteKeeper.Services;

namespace NoteKeeper.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            Navigation.PopModalAsync();

        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            // Determine appropriate message
            var message = viewModel.IsNewNote ? "SaveNote" : "UpdateNote";

            // Send appropriate message, include the affected note
            MessagingCenter.Send(this, message, viewModel.Note);

            Navigation.PopModalAsync();
        }

    }
}