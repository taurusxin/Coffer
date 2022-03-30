using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class ContentService : IContentService
    {
        private IDbService _dbService;

        public ContentService(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        public Task<List<Content>> GetContentAsync(int CoffeeId)
        {
            return _dbService.GetContentAsync(CoffeeId);
        }
    }
}