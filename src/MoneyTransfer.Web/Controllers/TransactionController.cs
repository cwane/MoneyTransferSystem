using Microsoft.AspNetCore.Mvc;

namespace MoneyTransfer.Web.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
