using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffer.Navigation;
using Coffer.Tools;
using Coffer.ViewModels;
using Xamarin.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace Coffer.Views
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            BindingContext = IocProvider.ServiceProvider.GetService<SettingPageViewModel>();
        }
        
        
        private void UpdateDatabase_Clicked(object sender, EventArgs e)
        {
            IocProvider.ServiceProvider.GetService<Util>().DownloadDB();
        }

        private void SubmitNewCoffee_Clicked(object sender, EventArgs e)
        {
            var newPage = new NewCoffeePage();
            NavigationDispatcher.Instance.Navigation.PushAsync(newPage);
        }
    }
}