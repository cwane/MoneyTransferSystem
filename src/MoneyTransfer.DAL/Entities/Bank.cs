using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransfer.DAL.Entities;

public class Bank
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Required]
    [StringLength(150)]
    public string Description { get; set; }

    [Required]
    [StringLength(9)]
    public string SwiftCode { get; set; }
    [Required]
    public decimal Balance { get; set; }

    [ForeignKey(nameof(Location))]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }

    public ICollection<Customer> Customers { get; set; }

}
