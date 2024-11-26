using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransfer.DAL.Entities;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [StringLength(50)]
    public string Code { get; set; }

    [Required]
    public string CitizenshipNumber { get; set; }

    [Required]
    public string Contact { get; set; }

    [ForeignKey(nameof(Bank))]
    public int? BankId { get; set; }
    public Bank? Bank { get; set; }


}
