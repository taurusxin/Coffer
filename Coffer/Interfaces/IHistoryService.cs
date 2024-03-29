using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface IHistoryService
    {
        Task<List<History>> GetHistoriesAsync();

        Task<int> SaveHistory(History history);

        Task<int> DeleteHistory(History history);

        Task<int> GetTodayCaffeine();
    }
}