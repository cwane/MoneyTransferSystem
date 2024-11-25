using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.BLL.MoneyTransferServiceInterface;
using MoneyTransfer.DAL.Entities;

namespace MoneyTransfer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankApiController : ControllerBase
    {
        private readonly IBankBusiness _bankBusiness;

        public BankApiController(IBankBusiness bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetAll()
        {
            var banks = await _bankBusiness.GetAllAsync();
            return Ok(banks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetById(int id)
        {
            var bank = await _bankBusiness.GetByIdAsync(id);
            if (bank == null)
            {
                return NotFound();
            }
            return Ok(bank);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Bank bank)
        {
            await _bankBusiness.AddAsync(bank);
            return CreatedAtAction(nameof(GetById), new { id = bank.Id }, bank);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }

            await _bankBusiness.UpdateAsync(bank);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bankBusiness.DeleteAsync(id);
            return NoContent();
        }
    }
}
