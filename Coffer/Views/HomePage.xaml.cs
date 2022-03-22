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
            BindingContext =  IocProvider.ServiceProvider.GetService<HomePageViewModel>();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            Appearing += HomePage_Appearing;
        }
        private async void HomePage_Appearing(object sender, EventArgs e)
        {
            try
            {
                await (BindingContext as HomePageViewModel).Initialise();
            }
            catch (Exception error)
            {
                Debug.Fail(error.Message); //handle gracefully here
            }
        }
    }
}