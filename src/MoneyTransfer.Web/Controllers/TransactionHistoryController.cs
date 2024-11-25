using Microsoft.AspNetCore.Mvc;

namespace MoneyTransfer.Web.Controllers
{
    public class TransactionHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
