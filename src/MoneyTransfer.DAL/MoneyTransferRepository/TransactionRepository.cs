using Microsoft.EntityFrameworkCore;
using MoneyTransfer.DAL.Data;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.DAL.MoneyTransferRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.DAL.MoneyTransferRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MoneyTransferApplicationDbContext _context;

        public TransactionRepository(MoneyTransferApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TransferMoney(Transaction transaction)
        {
            using var transactionScope = await _context.Database.BeginTransactionAsync();

            try
            {
                // Get sender bank
                var senderBank = await _context.Set<Bank>().FindAsync(transaction.SenderBankId);
                if (senderBank == null || senderBank.Balance < transaction.Amount)
                    return false; // Insufficient funds or bank not found

                // Get receiver bank
                var receiverBank = await _context.Set<Bank>().FindAsync(transaction.ReceiverBankId);
                if (receiverBank == null)
                    return false;

                // Update balances
                senderBank.Balance -= transaction.Amount;
                receiverBank.Balance += transaction.Amount;

                // Add transaction
                await _context.Set<Transaction>().AddAsync(transaction);

                // Save changes
                await _context.SaveChangesAsync();

                // Commit transaction
                await transactionScope.CommitAsync();

                return true;
            }
            catch
            {
                // Rollback on error
                await transactionScope.RollbackAsync();
                throw;
            }
        }


        public async Task AddAsync(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();
        }
        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            return await _context.Set<Transaction>().FindAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Set<Transaction>().ToListAsync();
        }
    }
}
