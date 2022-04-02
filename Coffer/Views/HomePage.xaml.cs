using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<HomePageViewModel>();
            Initialise();
            SubscribeEvents();
        }

        private async Task Initialise()
        {
            try
            {
                var viewModel = BindingContext as HomePageViewModel;
                await viewModel.Initialise();
                await viewModel.LoadProgress();
            }
            catch (Exception error)
            {
                Debug.Fail(error.Message); //handle gracefully here
            }
        }

        private void SubscribeEvents()
        {
            MessagingCenter.Subscribe<AddHistoryPageViewModel>(this, "LoadProgress", (sender) =>
            {
                var viewModel = BindingContext as HomePageViewModel;
                viewModel.LoadProgress();
            });
            MessagingCenter.Subscribe<HistoryPageViewModel>(this, "LoadProgress", (sender) =>
            {
                var viewModel = BindingContext as HomePageViewModel;
                viewModel.LoadProgress();
            });
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewModel = BindingContext as HomePageViewModel;
            viewModel.GoToCoffeeCommand.Execute(viewModel.SelectedBrand);
        }
    }
}