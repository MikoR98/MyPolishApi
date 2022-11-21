using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPolishApi.Entity;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public UserAccountController(
            ILogger<UserAccountController> logger,
            MyPolishApiDbContext myPolishApiDbContext
            )
        {
            _logger = logger;
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpGet]
        public async Task<UserAccount> GetUserAccount(string login, string password)
        {
            var userAccount = await _myPolishApiDbContext.UserAccount.FirstOrDefaultAsync(_ => _.Login == login && _.Password == password);

            return userAccount;
        }

        [HttpPut]
        public async Task AddUserAccount(string login, string password, string accountNumber)
        {
            var hashedPassword = HashPassword(password);

            await _myPolishApiDbContext.UserAccount.AddAsync(new UserAccount
            {
                Login = login,
                Password = hashedPassword,
                AccountNumber = accountNumber
            });

            await _myPolishApiDbContext.SaveChangesAsync();
        }

        private string HashPassword(string password)
        {
            var passwordArray = Encoding.UTF8.GetBytes(password);

            var sha512 = SHA512.Create();
            var hashedPassword = sha512.ComputeHash(passwordArray);

            var sBuilder = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                sBuilder.Append(hashedPassword[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
