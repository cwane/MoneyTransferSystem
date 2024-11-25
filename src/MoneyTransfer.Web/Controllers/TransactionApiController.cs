using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;

namespace MoneyTransfer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionApiController(ITransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferMoney([FromBody] Transaction transaction)
        {
            if (transaction == null || transaction.Amount <= 0)
                return BadRequest("Invalid transaction data.");

            var success = await _transactionBusiness.TransferMoney(transaction);
            if (!success)
                return BadRequest("Transfer failed. Insufficient funds or invalid details.");

            return Ok("Transfer successful.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _transactionBusiness.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionBusiness.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _transactionBusiness.TransferMoney(transaction);
            if (!success)
                return BadRequest("Transfer failed. Ensure sufficient funds and valid details.");

            return RedirectToAction("Index");
        }


    }
}
