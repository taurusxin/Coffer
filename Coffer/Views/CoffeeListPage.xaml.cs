using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffer.Models;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class CoffeeListPage : ContentPage
    {
        public CoffeeListPage(Brand brand)
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<CoffeeListPageViewModel>();

            var viewModel = BindingContext as CoffeeListPageViewModel;
            if (viewModel != null)
            {
                viewModel.LoadCoffee(brand);
            }
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewModel = BindingContext as CoffeeListPageViewModel;
            viewModel.GoToContentCommand.Execute(viewModel.SelectedCoffee);
        }
    }
}