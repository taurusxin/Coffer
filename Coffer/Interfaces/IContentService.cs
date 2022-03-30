using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetContentAsync(int CoffeeId);
    }
}