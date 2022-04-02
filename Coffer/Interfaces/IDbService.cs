using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface IDbService
    {
        Task<List<Brand>> GetBrandsAsync();

        Task<List<Coffee>> GetCoffeeAsync(int brandId);
        
        Task<List<Coffee>> GetCoffeeByNameAsync(int brandId, string name);

        Task<List<Content>> GetContentAsync(int CoffeeId);

        Task<Coffee> GetCoffeeByIdAsync(int coffeeId);

        Task<Brand> GetBrandByIdAsync(int brandId);

        Task<List<History>> GetHistoriesAsync();

        Task<int> SaveHistory(History history);
        
        Task<int> DeleteHistory(History history);

        Task<int> GetTodayCaffeineAsync();
    }
}