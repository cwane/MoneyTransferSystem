using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.ViewModels
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50, ErrorMessage = "Full Name cannot exceed 50 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [StringLength(50, ErrorMessage = "Code cannot exceed 50 characters.")]
        [Display(Name = "Customer Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Citizenship Number is required.")]
        [Display(Name = "Citizenship Number")]
        public string CitizenshipNumber { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }
    }
}
