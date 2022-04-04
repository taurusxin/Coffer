using System.ComponentModel.DataAnnotations;

namespace CofferBackend.Models;

public class NewCoffee
{
    [Key]
    public int Id { get; set; }
    
    public string Brand { get; set; }

    public string Coffee { get; set; }

    public string Size1 { get; set; }
    public string Caffeine1 { get; set; }
    
    public string Size2 { get; set; }
    public string Caffeine2 { get; set; }
    
    public string Size3 { get; set; }
    public string Caffeine3 { get; set; }
    
    public string More { get; set; }
    
    public string Email { get; set; }
    
    public DateTime Datetime { get; set; }
}