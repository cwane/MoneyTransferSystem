using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.BLL.MoneyTransferInterface;
using MoneyTransfer.BLL.MoneyTransferService;
using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;

namespace MoneyTransfer.Web.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }
        public async  Task<IActionResult> Index()
        {
            ViewBag.AllTransaction = await _transactionBusiness.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction model)
        {
            if (ModelState.IsValid)
            {
                var trans = new Transaction
                {
                    Amount = model.Amount,
                    SenderBankId = model.SenderBankId,
                    ReceiverBankId = model.ReceiverBankId,
                    SenderId = model.SenderId,
                    ReceiverId = model.ReceiverId,
                    TransactionDate = model.TransactionDate,
                };

                await _transactionBusiness.TransferMoney(trans);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
