using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.ViewModels
{
    public class CoffeeListPageViewModel : BaseViewModel
    {
        private readonly ICoffeeService _coffeeService;

        public ObservableCollection<Coffee> ObCoffee { get; set; } = new ObservableCollection<Coffee>();

        private int _count = 1111;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public CoffeeListPageViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        public async Task LoadCoffee(Brand brand)
        {
            //ObCoffee.Clear();
            var currentCoffee = await _coffeeService.GetCoffeeAsync(brand.Id);
            if (currentCoffee.Count > 0)
            {
                currentCoffee.ForEach(coffee => ObCoffee.Add(coffee));
            }
            else
            {
                ObCoffee = new ObservableCollection<Coffee>();
            }
        }
    }
}