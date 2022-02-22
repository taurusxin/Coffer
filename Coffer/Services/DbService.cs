using Coffer.Interfaces;
using SQLite;

namespace Coffer.Services
{
    public class DbService : IDbService
    {
        private readonly SQLiteAsyncConnection _sqLiteConnection;
        
        public DbService()
        {
            _sqLiteConnection = new SQLiteAsyncConnection(Constants.DbPath);
        }
    }
}