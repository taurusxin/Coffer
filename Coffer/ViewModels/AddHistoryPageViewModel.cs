using System;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Navigation;
using Coffer.Views;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class AddHistoryPageViewModel : BaseViewModel
    {
        private readonly ICoffeeService _coffeeService;
        private readonly IBrandService _brandService;
        private readonly IHistoryService _historyService;

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

        private double _count;

        public double Count
        {
            get => _count;
            set
            {
                _count = value;
                ConfirmAddCommand.ChangeCanExecute();
                Caffeine = value * _caffeinePerCup;
                OnPropertyChanged(nameof(Count));
            }
        }

        private double _caffeinePerCup;
        private double _caffeine = 0;

        public double Caffeine
        {
            get => _caffeine;
            set
            {
                if (value > 0)
                {
                    _caffeine = value;
                }
                else
                {
                    _caffeine = 0;
                }
                OnPropertyChanged(nameof(Caffeine));
            }
        }

        public Command ConfirmAddCommand { get; set; }
        public AddHistoryPageViewModel(
            IBrandService brandService,
            ICoffeeService coffeeService,
            IHistoryService historyService)
        {
            _brandService = brandService;
            _coffeeService = coffeeService;
            _historyService = historyService;
            
            InitializeCommands();
            Count = 1;
        }

        private void InitializeCommands()
        {
            ConfirmAddCommand = new Command(ConfirmAdd, () => _count > 0);
        }

        private Content temp_content;

        private void ConfirmAdd()
        {
            History history = new History();
            history.ContentId = temp_content.Id;
            history.Datetime = DateTime.Now;
            history.CoffeeName = Coffee;
            history.Count = Count;
            history.Size = Content;
            history.BrandName = Brand;
            history.TotalCaffeine = Caffeine;
            _historyService.SaveHistory(history);
            NavigationDispatcher.Instance.Navigation.PopToRootAsync();
            MessagingCenter.Send(this, "RefreshHistories");
        }

        public async Task LoadData(Content content)
        {
            temp_content = content;
            Content = content.SizeName;
            _caffeinePerCup = content.Caffeine;
            Caffeine = _caffeinePerCup;
            var coffee = await _coffeeService.GetCoffeeByIdAsync(content.CoffeeId);
            var brand = await _brandService.GetBrandByIdAsync(coffee.BrandId);
            Brand = brand.BrandName;
            Coffee = coffee.CoffeeName;
            CoffeeAndContent = Coffee + ", " + Content;
        }
    }
}