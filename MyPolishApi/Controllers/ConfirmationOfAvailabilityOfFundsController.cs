using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ConfirmationOfAvailabilityOfFundsController : ControllerBase
    {
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public ConfirmationOfAvailabilityOfFundsController(MyPolishApiDbContext myPolishApiDbContext)
        {
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> GetConfirmationOfFunds(string accountNumber, decimal amount, string currency)
        {
            var accountInfo = await _myPolishApiDbContext.AccountInfo.FirstOrDefaultAsync(_ => _.AccountNumber == accountNumber && _.Currency == currency);

            if (accountInfo.AvailableBalance >= amount)
                return true;

            return false;
        }
    }
}
