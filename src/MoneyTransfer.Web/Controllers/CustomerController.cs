using Microsoft.AspNetCore.Mvc;

namespace MoneyTransfer.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
