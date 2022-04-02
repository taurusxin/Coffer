using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class CoffeeService : ICoffeeService
    {
        private IDbService _dbService;

        public CoffeeService(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        public Task<List<Coffee>> GetCoffeeAsync(int brandId)
        {
            return _dbService.GetCoffeeAsync(brandId);
        }

        public Task<List<Coffee>> GetCoffeeByNameAsync(int BrandId, string name)
        {
            return _dbService.GetCoffeeByNameAsync(BrandId, name);
        }

        public Task<Coffee> GetCoffeeByIdAsync(int coffeeId)
        {
            return _dbService.GetCoffeeByIdAsync(coffeeId);
        }
    }
}