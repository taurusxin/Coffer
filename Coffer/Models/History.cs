using System;

namespace Coffer.Models
{
    public class History
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int Count { get; set; }
        public double TotalCaffeine { get; set; }
        public DateTime Datetime { get; set; }
    }
}