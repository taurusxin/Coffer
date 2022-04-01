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
    public partial class AddHistoryPage : ContentPage
    {
        public AddHistoryPage(Content content)
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<AddHistoryPageViewModel>();
            
            Initialize(content);
        }

        private async void Initialize(Content content)
        {
            try
            {
                await (BindingContext as AddHistoryPageViewModel).LoadData(content);
            }
            catch (Exception error)
            {
                Debug.Fail(error.Message); //handle gracefully here
            }
        }
    }
}