using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Navigation;
using Coffer.Views;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class CoffeeListPageViewModel : BaseViewModel
    {
        private readonly ICoffeeService _coffeeService;
        
        public Command GoToContentCommand { get; set; }
        public Command SearchCoffeeCommand { get; set; }
        
        public Coffee SelectedCoffee { get; set; }

        private Brand _brand;

        public ObservableCollection<Coffee> ObCoffee { get; set; } = new ObservableCollection<Coffee>();

        public CoffeeListPageViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GoToContentCommand = new Command<Coffee>(NavigateToDetailView);
            SearchCoffeeCommand = new Command<string>(SearchCoffee);
        }
        public async Task LoadCoffee(Brand brand)
        {
            _brand = brand;
            ObCoffee.Clear();
            var currentCoffee = await _coffeeService.GetCoffeeAsync(brand.Id);
            if (currentCoffee.Count > 0)
            {
                currentCoffee.ForEach(coffee => ObCoffee.Add(coffee));
            }
        }
        
        private void NavigateToDetailView(Coffee coffee)
        {
            var newPage = new CoffeeDetailPage(coffee);
            NavigationDispatcher.Instance.Navigation.PushAsync(newPage);
        }

        private async void SearchCoffee(string text)
        {
            if (text == null || text.Trim() == string.Empty)
            {
                LoadCoffee(_brand);
                return;
            }
            ObCoffee.Clear();
            var currentCoffee = await _coffeeService.GetCoffeeByNameAsync(_brand.Id, text);
            if (currentCoffee.Count > 0)
            {
                currentCoffee.ForEach(coffee => ObCoffee.Add(coffee));
            }
        }
    }
}