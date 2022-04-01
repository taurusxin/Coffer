using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.Navigation;
using Coffer.Views;
using Xamarin.Forms;

namespace Coffer.ViewModels
{
    public class CoffeeDetailPageViewModel : BaseViewModel
    {
        public readonly IContentService _contentService;

        public Content SelectedContent { get; set; }

        public Command GoToAddHistoryCommand { get; set; }

        public ObservableCollection<Content> ObContent { get; set; } = new ObservableCollection<Content>();

        public CoffeeDetailPageViewModel(IContentService contentService)
        {
            _contentService = contentService;
            
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GoToAddHistoryCommand = new Command<Content>(NavigateToAddHistoryView);

        }

        public async Task LoadContent(Coffee coffee)
        {
            var currentContent = await _contentService.GetContentAsync(coffee.Id);
            if (currentContent.Count > 0)
            {
                currentContent.ForEach(content => ObContent.Add(content));
            }
        }
        
        private void NavigateToAddHistoryView(Content content)
        {
            var newPage = new AddHistoryPage(content);
            NavigationDispatcher.Instance.Navigation.PushAsync(newPage);
        }
    }
}