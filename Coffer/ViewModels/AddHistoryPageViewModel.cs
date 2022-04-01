using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class AddHistoryPageViewModel : BaseViewModel
    {
        private readonly ICoffeeService _coffeeService;
        private readonly IBrandService _brandService;

        private string _brand;
        private string _coffee;
        private string _content;

        public string Brand
        {
            get => _brand;
            set
            {
                _brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public string Coffee
        {
            get => _coffee;
            set
            {
                _coffee = value;
                OnPropertyChanged(nameof(Coffee));
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private string _coffeeAndContent; 
        public string CoffeeAndContent
        {
            get => _coffeeAndContent;
            set
            {
                _coffeeAndContent = value;
                OnPropertyChanged(nameof(CoffeeAndContent));
            }
        }
        
        public AddHistoryPageViewModel(IBrandService brandService, ICoffeeService coffeeService)
        {
            _brandService = brandService;
            _coffeeService = coffeeService;
        }

        public async Task LoadData(Content content)
        {
            Content = content.SizeName;
            var coffee = await _coffeeService.GetCoffeeByIdAsync(content.CoffeeId);
            var brand = await _brandService.GetBrandByIdAsync(coffee.BrandId);
            Brand = brand.BrandName;
            Coffee = coffee.CoffeeName;
            CoffeeAndContent = Coffee + ", " + Content;
        }
    }
}