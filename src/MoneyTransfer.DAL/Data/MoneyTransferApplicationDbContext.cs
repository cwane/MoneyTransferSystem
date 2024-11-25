using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyTransfer.DAL.Entities;

namespace MoneyTransfer.DAL.Data;

public class MoneyTransferApplicationDbContext : IdentityDbContext<User>
{
    public MoneyTransferApplicationDbContext(DbContextOptions<MoneyTransferApplicationDbContext> options)
        : base(options)
    {
        
    }

    #region DbSet
    public DbSet<User> User { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Bank> Bank { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Transaction> Transaction { get; set; }

    #endregion
}
