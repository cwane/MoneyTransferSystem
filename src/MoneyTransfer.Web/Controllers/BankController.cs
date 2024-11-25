using Microsoft.AspNetCore.Mvc;

namespace MoneyTransfer.Web.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
