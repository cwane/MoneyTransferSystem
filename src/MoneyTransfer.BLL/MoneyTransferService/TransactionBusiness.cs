using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.DAL.MoneyTransferRepository;
using MoneyTransfer.DAL.MoneyTransferRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.BLL.MoneyTransferService
{
    public class TransactionBusiness : ITransactionBusiness
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankRepository _bankRepository;

        public TransactionBusiness(ITransactionRepository transactionRepository, 
                                    IBankRepository bankRepository)
        {
            _transactionRepository = transactionRepository;
            _bankRepository = bankRepository;
        }

        public async Task<bool> TransferMoney(Transaction transaction)
        {
            // Validation logic
            var senderBank = await _bankRepository.GetByIdAsync(transaction.SenderBankId);
            var receiverBank = await _bankRepository.GetByIdAsync(transaction.ReceiverBankId);

            if (senderBank == null || receiverBank == null)
                throw new Exception("Invalid bank details.");

            if (senderBank.Balance < transaction.Amount)
                throw new Exception("Insufficient funds.");

            // Perform transfer
            senderBank.Balance -= transaction.Amount;
            receiverBank.Balance += transaction.Amount;

            // Save transaction
            await _transactionRepository.AddAsync(transaction);
            return true;
        }


        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            return await _transactionRepository.GetTransactionByIdAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }
    }
}
