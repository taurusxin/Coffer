using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using SQLite;

namespace Coffer.Services
{
    public class DbService : IDbService
    {
        private readonly SQLiteAsyncConnection _sqLiteConnection;
        
        public DbService()
        {
            _sqLiteConnection = new SQLiteAsyncConnection(Constants.DbPath);
            _sqLiteConnection.CreateTableAsync<Brand>().Wait();
            _sqLiteConnection.CreateTableAsync<Coffee>().Wait();
            _sqLiteConnection.CreateTableAsync<Content>().Wait();
        }

        public Task<List<Brand>> GetBrandsAsync()
        {
            return _sqLiteConnection.Table<Brand>().ToListAsync();
        }

        public Task<List<Coffee>> GetCoffeeAsync(int brandId)
        {
            return _sqLiteConnection.QueryAsync<Coffee>("select * from Coffee where BrandId=?", brandId);
        }

        public Task<List<Content>> GetContentAsync(int CoffeeId)
        {
            return _sqLiteConnection.QueryAsync<Content>("select * from Content where CoffeeId=?", CoffeeId);
        }

        public Task<Coffee> GetCoffeeByIdAsync(int coffeeId)
        {
            return _sqLiteConnection.Table<Coffee>().FirstOrDefaultAsync(c => c.Id == coffeeId);
        }

        public Task<Brand> GetBrandByIdAsync(int brandId)
        {
            return _sqLiteConnection.Table<Brand>().FirstOrDefaultAsync(b => b.Id == brandId);
        }
    }
}