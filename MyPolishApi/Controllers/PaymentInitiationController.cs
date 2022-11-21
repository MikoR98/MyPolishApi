using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity;
using MyPolishApi.Entity.Enum;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System;
using System.Threading.Tasks;

namespace MyPolishApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PaymentInitiationController : ControllerBase
    {
        private readonly MyPolishApiDbContext _myPolishApiDbContext;

        public PaymentInitiationController(MyPolishApiDbContext myPolishApiDbContext)
        {
            _myPolishApiDbContext = myPolishApiDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Domestic(string senderAccountNumber, string recipientAccountNumber, string description, string amount, string currency, string executionDate)
        {
            var currentDate = DateTime.Now;

            try
            {
                decimal dAmount = decimal.Parse(amount);

                var accountInfo = await _myPolishApiDbContext.AccountInfo.FirstOrDefaultAsync(_ => _.AccountNumber == senderAccountNumber);

                var newAvailableBalance = accountInfo.AvailableBalance - dAmount;
                var newBookingBalance = accountInfo.BookingBalance - dAmount;

                accountInfo.AvailableBalance = newAvailableBalance;
                accountInfo.BookingBalance = newBookingBalance;

                _myPolishApiDbContext.AccountInfo.Attach(accountInfo);
                _myPolishApiDbContext.Entry(accountInfo).Property("AvailableBalance").IsModified = true;
                _myPolishApiDbContext.Entry(accountInfo).Property("BookingBalance").IsModified = true;

                await _myPolishApiDbContext.TransactionInfo.AddAsync(new TransactionInfo
                {
                    Amount = dAmount,
                    Currency = currency,
                    Description = description,
                    TransactionType = "Standard",
                    TradeDate = DateTime.Parse(executionDate),
                    TransactionCategory = TransactionCategoryEnum.DEBIT,
                    TransactionStatus = "2",
                    SenderId = senderAccountNumber,
                    RecipientId = recipientAccountNumber,
                    BookingDate = currentDate,
                    PostTransactionBalance = newAvailableBalance
                });

                var goalAccountInfo = await _myPolishApiDbContext.AccountInfo.FirstOrDefaultAsync(_ => _.AccountNumber == recipientAccountNumber);

                newAvailableBalance = goalAccountInfo.AvailableBalance + dAmount;
                newBookingBalance = goalAccountInfo.BookingBalance + dAmount;

                goalAccountInfo.AvailableBalance = newAvailableBalance;
                goalAccountInfo.BookingBalance = newBookingBalance;

                _myPolishApiDbContext.AccountInfo.Attach(goalAccountInfo);
                _myPolishApiDbContext.Entry(goalAccountInfo).Property("AvailableBalance").IsModified = true;
                _myPolishApiDbContext.Entry(goalAccountInfo).Property("BookingBalance").IsModified = true;

                await _myPolishApiDbContext.TransactionInfo.AddAsync(new TransactionInfo
                {
                    Amount = dAmount,
                    Currency = currency,
                    Description = description,
                    TransactionType = "Standard",
                    TradeDate = currentDate,
                    TransactionCategory = TransactionCategoryEnum.CREDIT,
                    TransactionStatus = "2",
                    SenderId = senderAccountNumber,
                    RecipientId = recipientAccountNumber,
                    BookingDate = currentDate,
                    PostTransactionBalance = newAvailableBalance
                });

                await _myPolishApiDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }        
        }
    }
}
