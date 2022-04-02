using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface ICoffeeService
    {
        Task<List<Coffee>> GetCoffeeAsync(int BrandId);
        
        Task<List<Coffee>> GetCoffeeByNameAsync(int BrandId, string name);
        
        Task<Coffee> GetCoffeeByIdAsync(int coffeeId);
        
    }
}