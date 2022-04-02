using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.ViewModels
{
    public class HistoryPageViewModel : BaseViewModel
    {
        private readonly IHistoryService _historyService;
        
        public ObservableCollection<History> ObHistories { get; set; } = new ObservableCollection<History>();

        public HistoryPageViewModel(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public async Task LoadHistories()
        {
            ObHistories.Clear();
            var currentHistories = await _historyService.GetHistoriesAsync();
            if (currentHistories.Count > 0)
            {
                currentHistories.ForEach(history => ObHistories.Add(history));
            }
        }

        public async void ConfirmDelete(History history)
        {
            await _historyService.DeleteHistory(history);
            ObHistories.Remove(history);
            // await LoadHistories();
        }
        
        public async void ConfirmDuplicate(History history)
        {
            var newHistory = new History
            {
                ContentId = history.ContentId,
                Datetime = DateTime.Now,
                CoffeeName = history.CoffeeName,
                Count = history.Count,
                Size = history.Size,
                BrandName = history.BrandName,
                TotalCaffeine = history.TotalCaffeine
            };
            await _historyService.SaveHistory(newHistory);
            ObHistories.Insert(0, newHistory);
        }
    }
}