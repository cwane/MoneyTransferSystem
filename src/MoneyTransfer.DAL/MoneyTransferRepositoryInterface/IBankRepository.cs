using MoneyTransfer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.DAL.MoneyTransferRepositoryInterface
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<Bank> GetByIdAsync(int id);
        Task AddAsync(Bank bank, Location location);
        Task UpdateAsync(Bank bank);
        Task DeleteAsync(int id);
    }
}
