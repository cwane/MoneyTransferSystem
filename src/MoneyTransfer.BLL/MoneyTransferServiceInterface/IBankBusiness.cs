using MoneyTransfer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.BLL.MoneyTransferServiceInterface
{
    public interface IBankBusiness
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<Bank> GetByIdAsync(int id);
        Task AddAsync(Bank bank);
        Task UpdateAsync(Bank bank);
        Task DeleteAsync(int id);
    }
}
