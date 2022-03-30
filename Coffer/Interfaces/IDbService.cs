using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface IDbService
    {
        Task<List<Brand>> GetBrandsAsync();

        Task<List<Coffee>> GetCoffeeAsync(int brandId);
    }
}