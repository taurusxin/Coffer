using System;
using Coffer.Models;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<HistoryPageViewModel>();
            var viewModel = BindingContext as HistoryPageViewModel;
            if (viewModel != null)
            {
                viewModel.LoadHistories();
            }
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            var viewModel = BindingContext as HistoryPageViewModel;
            // subscribe refresh histories event
            MessagingCenter.Subscribe<AddHistoryPageViewModel>(this, "RefreshHistories", (sender) =>
            {
                viewModel.LoadHistories();
            });
            
            MessagingCenter.Subscribe<HistoryPageViewModel, History>(this, "ConfirmDelete", async (sender, args) =>
            {
                string confirm = await DisplayActionSheet("Are you sure?", "Cancel", "Confirm");
                if (confirm == "Confirm")
                {
                    viewModel.ConfirmDelete(args);
                }
            });
        }

        private async void Delete_OnInvoked(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            var history = item.BindingContext as History;
            var viewModel = BindingContext as HistoryPageViewModel;
            string confirm = await DisplayActionSheet("Are you sure?", "Cancel", "Confirm");
            if (confirm == "Confirm")
            {
                viewModel.ConfirmDelete(history);
            }
        }

        private async void Duplicate_OnInvoked(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            var history = item.BindingContext as History;
            var viewModel = BindingContext as HistoryPageViewModel;
            string confirm = await DisplayActionSheet("Add same one again?", "Cancel", null, "Yes!");
            if (confirm == "Yes!")
            {
                viewModel.ConfirmDuplicate(history);
            }
        }
    }
}