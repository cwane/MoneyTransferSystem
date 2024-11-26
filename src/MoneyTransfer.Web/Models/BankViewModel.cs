using MoneyTransfer.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Web.Models
{
    public class BankViewModel
    {
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
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }
  
    }
}
