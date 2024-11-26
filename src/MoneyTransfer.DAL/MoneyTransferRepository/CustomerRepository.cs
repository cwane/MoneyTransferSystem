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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MoneyTransferApplicationDbContext _context;

        public CustomerRepository(MoneyTransferApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _context.Set<Customer>().Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
