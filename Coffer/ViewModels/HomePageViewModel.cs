using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Services;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Brand SelectedBrand { get; set; }
        public ObservableCollection<Brand> ObBrands { get; set; } = new ObservableCollection<Brand>();
        private readonly IBrandService _brandService;

        public ICommand TestCommand { get; set; }
        
        public HomePageViewModel(IBrandService brandService)
        {
            _brandService = brandService;

            TestCommand = new Command(Test);
        }
        
        public override async Task Initialise()
        {
            ObBrands.Clear();
            var currentBrands = await _brandService.GetBrandsAsync();
            if (currentBrands.Count > 0)
            {
                currentBrands.ForEach(brand => ObBrands.Add(brand));
            }
            else
            {
                ObBrands = new ObservableCollection<Brand>();
            }
        }

        private void Test()
        {
            // Brand brand = new Brand();
            // brand.Id = 1;
            // brand.BrandIcon = "https://assets.icoffer.app/image/costa.png";
            // brand.BrandName = "test";
            //
            // ObBrands.Add(brand);
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("https://api.icoffer.app/coffer.db3"), Constants.DbPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}