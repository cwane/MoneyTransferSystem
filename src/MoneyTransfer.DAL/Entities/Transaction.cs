using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.DAL.Entities
{
    public class Transaction
    {
        [Required]
        public int SenderId { get; set; }

        [Required] 
        public int SenderBankId { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int ReceiverBankId { get; set; }

        [Required]
        public int SenderTransactionId { get; set; }

        [Required]
        public int ReceiverTransactionId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
