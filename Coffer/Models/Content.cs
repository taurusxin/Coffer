using SQLite;

namespace Coffer.Models
{
    public class Content
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CoffeeId { get; set; }
        public string SizeName { get; set; }
        public int Caffeine { get; set; }
    }
}