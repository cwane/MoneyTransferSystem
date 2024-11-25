using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.DAL.Entities;

public class Location
{
    [Key] 
    public int Id { get; set; }

    [Required]
    public string CountryCode { get; set; }

    [Required] 
    public string Country { get; set; }

    [Required]
    public string CityCode { get; set; }
    [Required] 
    public string City { get; set; }
    
    public ICollection<Bank> Banks { get; set; }
}
