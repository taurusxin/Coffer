using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffer.Models;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class CoffeeDetailPage : ContentPage
    {
        public CoffeeDetailPage(Coffee coffee)
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<CoffeeDetailPageViewModel>();

            var viewModel = (BindingContext as CoffeeDetailPageViewModel);
            if (viewModel != null)
            {
                viewModel.LoadContent(coffee);
            }
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewModel = BindingContext as CoffeeDetailPageViewModel;
            viewModel.GoToAddHistoryCommand.Execute(viewModel.SelectedContent);
        }
    }
}