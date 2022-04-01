using System;
using SQLite;

namespace Coffer.Models
{
    public class History
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ContentId { get; set; }
        public DateTime Datetime { get; set; }
        
        public string CoffeeName { get; set; }
        public double Count { get; set; }
        
        public string Size { get; set; }
        public double TotalCaffeine { get; set; }
    }
}