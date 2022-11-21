using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Interfaces
{
    public interface IRestService
    {
        Task<UserAccount> LoginAsync(string login, string password);
        Task<AccountInfo> GetAccountAsync(string accountNumber);
        Task<List<TransactionInfo>> GetTransactionInfoAsync(string accountNumber);
        Task<List<TransactionScheduledInfo>> GetTransactionScheduledAsync(string accountNumber);
        Task<bool> GetConfirmationOfFunds(string accountNumber, decimal amount, string currency);
        Task<bool> Domestic(string senderAccountNumber, string recipientAccountNumber, string description, decimal amount, string currency, DateTime executionDate);
    }
}
