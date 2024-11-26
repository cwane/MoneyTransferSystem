using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.Web.Models;

namespace MoneyTransfer.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankBusiness _bankBusiness;

        public BankController(IBankBusiness bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.AllBank = await _bankBusiness.GetAllAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BankViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bank bank = new()
                {
                    Name = model.Name,
                    SwiftCode = model.SwiftCode,
                    Description = model.Description,
                    Balance = model.Balance,

                };
                Location location = new()
                {
                    City = model.City,
                    CityCode = model.CityCode,
                    CountryCode = model.CountryCode,
                    Country = model.Country,

                };
                await _bankBusiness.AddAsync(bank, location);
                return RedirectToAction("Index"); 
            }
            return View(model); 
        }
    }
}
