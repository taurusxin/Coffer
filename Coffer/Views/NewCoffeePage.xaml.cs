using System;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class NewCoffeePage : ContentPage
    {
        public NewCoffeePage()
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<NewCoffeeViewModel>();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as NewCoffeeViewModel;
            viewModel.SubmitCommand.Execute(null);
        }
    }
}