using SQLite;

namespace Coffer.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string CoffeeName { get; set; }
    }
}