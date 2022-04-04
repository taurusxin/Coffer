using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Navigation;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class NewCoffeeViewModel : BaseViewModel
    {
        private string _brand;
        private string _coffee;
        private string _size1;
        private string _caffeine1;
        private string _size2;
        private string _caffeine2;
        private string _size3;
        private string _caffeine3;
        private string _more;
        private string _email;

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

        public string Size1
        {
            get => _size1;
            set
            {
                _size1 = value;
                OnPropertyChanged(nameof(Size1));
            }
        }

        public string Caffeine1
        {
            get => _caffeine1;
            set
            {
                _caffeine1 = value;
                OnPropertyChanged(nameof(Caffeine1));
            }
        }
        
        public string Size2
        {
            get => _size2;
            set
            {
                _size2 = value;
                OnPropertyChanged(nameof(Size2));
            }
        }

        public string Caffeine2
        {
            get => _caffeine2;
            set
            {
                _caffeine2 = value;
                OnPropertyChanged(nameof(Caffeine2));
            }
        }
        
        public string Size3
        {
            get => _size3;
            set
            {
                _size3 = value;
                OnPropertyChanged(nameof(Size3));
            }
        }

        public string Caffeine3
        {
            get => _caffeine3;
            set
            {
                _caffeine3 = value;
                OnPropertyChanged(nameof(Caffeine3));
            }
        }

        public string More
        {
            get => _more;
            set
            {
                _more = value;
                OnPropertyChanged(nameof(More));
            }
        }
        
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private bool _submitEnabled;

        public bool SubmitEnabled
        {
            get => _submitEnabled;
            set
            {
                _submitEnabled = value;
                OnPropertyChanged(nameof(SubmitEnabled));
            }
        }
        
        // Submit command
        public ICommand SubmitCommand;

        private readonly INewCoffeeService _newCoffeeService;

        public NewCoffeeViewModel(INewCoffeeService newCoffeeService)
        {
            SubmitCommand = new Command(async () => await Submit());
            _newCoffeeService = newCoffeeService;
            SubmitEnabled = true;

            Brand = string.Empty;
            Coffee = string.Empty;
            Size1 = string.Empty;
            Caffeine1 = string.Empty;
            Size2 = string.Empty;
            Caffeine2 = string.Empty;
            Size3 = string.Empty;
            Caffeine3 = string.Empty;
            More = string.Empty;
            Email = string.Empty;
        }

        private async Task Submit()
        {
            SubmitEnabled = false;
            try
            {
                var newCoffee = new NewCoffee()
                {
                    Brand = Brand,
                    Coffee = Coffee,
                    Size1 = Size1,
                    Caffeine1 = Caffeine1,
                    Size2 = Size2,
                    Caffeine2 = Caffeine2,
                    Size3 = Size3,
                    Caffeine3 = Caffeine3,
                    More = More,
                    Email = Email,
                    Datetime = DateTime.Now
                };

                var succeded = await _newCoffeeService.SubmitNewCoffee(newCoffee);

                if (succeded)
                {
                    await NavigationDispatcher.Instance.Navigation.PopAsync();
                    await Application.Current.MainPage.DisplayAlert("Thank you!"
                        , "Really appreciate your submission!" +
                          "\nWe will send you a email if the data is merge into database!"
                        , "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error"
                        , "Submit failed, please try again."
                        , "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Errors occured!\n" +
                                                                         "Please contact the developer", "OK");
            }
        }
    }
}