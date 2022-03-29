using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeListPage : ContentPage
    {
        public CoffeeListPage(Brand brand)
        {
            InitializeComponent();
        }
    }
}