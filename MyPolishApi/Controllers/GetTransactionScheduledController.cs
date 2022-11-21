using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GetTransactionScheduledController : ControllerBase
    {
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public GetTransactionScheduledController(MyPolishApiDbContext myPolishApiDbContext)
        {
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<TransactionScheduledInfo>> GetTransactionScheduledAsync(string accountNumber)
        {
            var accountInfo = await _myPolishApiDbContext.TransactionScheduledInfo.Where(_ => _.Sender.AccountNumber == accountNumber).ToListAsync();

            return new JsonResult(accountInfo);
        }
    }
}
