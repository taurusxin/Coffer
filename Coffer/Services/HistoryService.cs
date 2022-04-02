using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class HistoryService : IHistoryService
    {
        private IDbService _dbService;

        public HistoryService(IDbService dbService)
        {
            this._dbService = dbService;
        }
        
        public Task<List<History>> GetHistoriesAsync()
        {
            return _dbService.GetHistoriesAsync();
        }

        public Task<int> SaveHistory(History history)
        {
            return _dbService.SaveHistory(history);
        }

        public Task<int> DeleteHistory(History history)
        {
            return _dbService.DeleteHistory(history);
        }

        public Task<int> GetTodayCaffeine()
        {
            return _dbService.GetTodayCaffeineAsync();
        }
    }
}