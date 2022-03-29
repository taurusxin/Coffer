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
    }
}