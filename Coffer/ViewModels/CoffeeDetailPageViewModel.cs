using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.ViewModels
{
    public class CoffeeDetailPageViewModel : BaseViewModel
    {
        public readonly IContentService _contentService;

        public ObservableCollection<Content> ObContent { get; set; } = new ObservableCollection<Content>();

        public CoffeeDetailPageViewModel(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task LoadContent(Coffee coffee)
        {
            var currentContent = await _contentService.GetContentAsync(coffee.Id);
            if (currentContent.Count > 0)
            {
                currentContent.ForEach(content => ObContent.Add(content));
            }
        }
    }
}