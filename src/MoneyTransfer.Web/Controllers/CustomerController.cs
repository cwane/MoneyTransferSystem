using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.BLL.MoneyTransferInterface;
using MoneyTransfer.DAL.Entities;
using MoneyTransfer.ViewModels;

namespace MoneyTransfer.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerBusiness _customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.AllCustomesr = await _customerBusiness.GetAllAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    FullName = model.FullName,
                    CitizenshipNumber = model.CitizenshipNumber,
                    Code = model.Code,
                    Contact = model.Contact,
                    BankId = model.BankId,
                };

                await _customerBusiness.AddAsync(customer);
                return RedirectToAction("Index"); 
            }
            return View(model);
        }
    }
}
