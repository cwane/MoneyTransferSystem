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
    public class BankRepository : IBankRepository
    {
        private readonly MoneyTransferApplicationDbContext _context;

        public BankRepository(MoneyTransferApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await _context.Set<Bank>()
                                 .Include(b => b.Location) // Include related Location
                                 .Include(b => b.Customers) // Include related Customers
                                 .ToListAsync();
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _context.Bank
                                 .Include(b => b.Location)
                                 .Include(b => b.Customers)
                                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Bank bank, Location location)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Location.AddAsync(location);
                    await _context.SaveChangesAsync();

                    bank.LocationId = location.Id;
                    await _context.Bank.AddAsync(bank);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
               
        }

        public async Task UpdateAsync(Bank bank)
        {
            _context.Set<Bank>().Update(bank);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bank = await GetByIdAsync(id);
            if (bank != null)
            {
                _context.Set<Bank>().Remove(bank);
                await _context.SaveChangesAsync();
            }
        }
    }
}
