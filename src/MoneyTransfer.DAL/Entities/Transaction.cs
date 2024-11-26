using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.DAL.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required] 
        public int SenderBankId { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int ReceiverBankId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
