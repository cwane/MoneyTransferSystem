using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.DAL.MoneyTransferRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer.BLL.MoneyTransferService
{
    public class BankBusiness : IBankBusiness
    {
        private readonly IBankRepository _bankRepository;

        public BankBusiness(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await _bankRepository.GetAllAsync();
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _bankRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Bank bank)
        {
            await _bankRepository.AddAsync(bank);
        }

        public async Task UpdateAsync(Bank bank)
        {
            await _bankRepository.UpdateAsync(bank);
        }

        public async Task DeleteAsync(int id)
        {
            await _bankRepository.DeleteAsync(id);
        }
    }
}
