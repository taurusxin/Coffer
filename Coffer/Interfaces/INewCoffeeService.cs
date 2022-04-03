using System.Threading.Tasks;
using Coffer.Models;

namespace Coffer.Interfaces
{
    public interface INewCoffeeService
    {
        Task<bool> SubmitNewCoffee(NewCoffee newCoffee);
    }
}