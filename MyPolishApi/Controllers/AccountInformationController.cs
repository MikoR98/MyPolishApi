using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AccountInformationController : ControllerBase
    {
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public AccountInformationController(MyPolishApiDbContext myPolishApiDbContext)
        {
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAccountAsync(string accountNumber)
        {
            var accountInfo = await _myPolishApiDbContext.AccountInfo.FirstOrDefaultAsync(_ => _.AccountNumber == accountNumber);

            var result = JsonConvert.SerializeObject(accountInfo, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return result;
        }
    }
}
