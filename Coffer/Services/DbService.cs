using System.Collections.Generic;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;
using SQLite;
using SQLitePCL;

namespace Coffer.Services
{
    public class DbService : IDbService
    {
        private readonly SQLiteAsyncConnection _sqliteDataConnection;
        private readonly SQLiteAsyncConnection _sqliteUserConnection;
        
        public DbService()
        {
            if (!Settings.Settings.HasDB)
            {
                Settings.Settings.DownloadDB();
            }
            _sqliteDataConnection = new SQLiteAsyncConnection(Constants.DbPath);
            _sqliteUserConnection = new SQLiteAsyncConnection(Constants.UserDbPath);

            _sqliteDataConnection.CreateTableAsync<Brand>().Wait();
            _sqliteDataConnection.CreateTableAsync<Coffee>().Wait();
            _sqliteDataConnection.CreateTableAsync<Content>().Wait();
            
            _sqliteUserConnection.CreateTableAsync<History>().Wait();
        }

        public Task<List<Brand>> GetBrandsAsync()
        {
            return _sqliteDataConnection.Table<Brand>().ToListAsync();
        }

        public Task<List<Coffee>> GetCoffeeAsync(int brandId)
        {
            return _sqliteDataConnection.QueryAsync<Coffee>("select * from Coffee where BrandId=?", brandId);
        }

        public Task<List<Content>> GetContentAsync(int CoffeeId)
        {
            return _sqliteDataConnection.QueryAsync<Content>("select * from Content where CoffeeId=?", CoffeeId);
        }

        public Task<Coffee> GetCoffeeByIdAsync(int coffeeId)
        {
            return _sqliteDataConnection.Table<Coffee>().FirstOrDefaultAsync(c => c.Id == coffeeId);
        }

        public Task<Brand> GetBrandByIdAsync(int brandId)
        {
            return _sqliteDataConnection.Table<Brand>().FirstOrDefaultAsync(b => b.Id == brandId);
        }

        public Task<List<History>> GetHistoriesAsync()
        {
            return _sqliteUserConnection.Table<History>().OrderByDescending(h => h.Id).ToListAsync();
        }

        public Task<int> SaveHistory(History history)
        {
            return _sqliteUserConnection.InsertAsync(history);
        }

        public Task<int> DeleteHistory(History history)
        {
            return _sqliteUserConnection.DeleteAsync(history);
        }
    }
}