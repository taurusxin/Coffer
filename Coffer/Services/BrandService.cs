using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class BrandService : IBrandService
    {
        private IDbService _dbService;
        public BrandService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await _dbService.GetBrandsAsync();
        }
    }
}