using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyTransfer.BLL.MoneyTransferInterface;
using MoneyTransfer.BLL.MoneyTransferService;
using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Data;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.DAL.MoneyTransferRepository;
using MoneyTransfer.DAL.MoneyTransferRepositoryInterface;

namespace MoneyTransfer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection") ?? 
                throw new InvalidOperationException("Connection string 'SqlServerConnection' not found.");

            builder.Services.AddDbContext<MoneyTransferApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MoneyTransferApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBankRepository, BankRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            builder.Services.AddScoped<IBankBusiness,BankBusiness>();
            builder.Services.AddScoped<ICustomerBusiness,CustomerBusiness>();
            builder.Services.AddScoped<ITransactionBusiness,TransactionBusiness>();
            builder.Services.AddScoped<ITransactionBusiness,TransactionBusiness>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //   name: "area",
            //   pattern: "{area:exist}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
