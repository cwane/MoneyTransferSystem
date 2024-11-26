using MoneyTransfer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.BLL.MoneyTransferServiceInterface
{
    public interface ITransactionBusiness
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<bool> TransferMoney(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    }
}
