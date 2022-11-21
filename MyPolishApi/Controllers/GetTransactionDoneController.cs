using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GetTransactionDoneController : ControllerBase
    {
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public GetTransactionDoneController(MyPolishApiDbContext myPolishApiDbContext)
        {
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<TransactionInfo>> GetTransactionDoneAsync(string accountNumber)
        {
            var outgoingTransfers = await _myPolishApiDbContext.TransactionInfo.Where(_ => _.Sender.AccountNumber == accountNumber && _.TransactionCategory == Entity.Enum.TransactionCategoryEnum.DEBIT).Include("Sender").ToListAsync();

            var incomingTransfers = await _myPolishApiDbContext.TransactionInfo.Where(_ => _.Recipient.AccountNumber == accountNumber && _.TransactionCategory == Entity.Enum.TransactionCategoryEnum.CREDIT).Include("Recipient").ToListAsync();

            var transactionInfo = new List<TransactionInfo>();
            transactionInfo.AddRange(outgoingTransfers);
            transactionInfo.AddRange(incomingTransfers);

            return new JsonResult(transactionInfo);
        }
    }
}
