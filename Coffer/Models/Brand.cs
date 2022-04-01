using Coffer.ViewModels;
using SQLite;

namespace Coffer.Models
{
    public class Brand
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandIcon { get; set; }
    }
}