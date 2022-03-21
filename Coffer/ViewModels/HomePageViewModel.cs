using System.Collections.ObjectModel;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Services;

namespace Coffer.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Brand SelectedBrand { get; set; }
        public ObservableCollection<Brand> ObBrands { get; set; }
        private IBrandService _brandService;

        public HomePageViewModel(IBrandService brandService)
        {
            _brandService = brandService;
            
            GetBrandsData();
        }

        public void GetBrandsData()
        {
            ObBrands = new ObservableCollection<Brand>();
            var items = _brandService.GetBrandsData();
            foreach (var item in items)
            {
                ObBrands.Add(item);
            }
        }
    }
}