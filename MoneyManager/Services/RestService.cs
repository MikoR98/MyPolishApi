using MoneyManager.Interfaces;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class RestService : IRestService
    {
        public async Task<UserAccount> LoginAsync(string login, string password)
        {
            var request = new RestRequest("UserAccount", DataFormat.Json);
            request.AddParameter("login", login);
            request.AddParameter("password", password);

            var response = await GetAsync<UserAccount>(request);

            return response;
        }

        public async Task<AccountInfo> GetAccountAsync(string accountNumber)
        {
            var request = new RestRequest("AccountInformation", DataFormat.Json);
            request.AddParameter("accountNumber", accountNumber);

            var response = await GetAsync<string>(request);

            var result = JsonConvert.DeserializeObject<AccountInfo>(response);
            return result;
        }

        public async Task<List<TransactionInfo>> GetTransactionInfoAsync(string accountNumber)
        {
            var request = new RestRequest("GetTransactionDone", DataFormat.Json);
            request.AddParameter("accountNumber", accountNumber);

            var response = await GetAsync<List<TransactionInfo>>(request);

            return response;
        }

        public async Task<List<TransactionScheduledInfo>> GetTransactionScheduledAsync(string accountNumber)
        {
            var request = new RestRequest("GetTransactionScheduled", DataFormat.Json);
            request.AddParameter("accountNumber", accountNumber);

            var response = await GetAsync<List<TransactionScheduledInfo>>(request);

            return response;
        }

        public async Task<bool> GetConfirmationOfFunds(string accountNumber, decimal amount, string currency)
        {
            var request = new RestRequest("ConfirmationOfAvailabilityOfFunds", DataFormat.Json);
            request.AddParameter("accountNumber", accountNumber);
            request.AddParameter("amount", amount);
            request.AddParameter("currency", currency);

            var response = await GetAsync<bool>(request);

            return response;
        }

        public async Task<bool> Domestic(string senderAccountNumber, string recipientAccountNumber, string description, decimal amount, string currency, DateTime executionDate)
        {
            var request = new RestRequest("PaymentInitiation", DataFormat.Json);
            request.AddQueryParameter("senderAccountNumber", senderAccountNumber);
            request.AddQueryParameter("recipientAccountNumber", recipientAccountNumber);
            request.AddQueryParameter("description", description);
            request.AddQueryParameter("amount", amount.ToString());
            request.AddQueryParameter("currency", currency);
            request.AddQueryParameter("executionDate", executionDate.ToString());

            var response = await PostAsync<bool>(request);

            return response;
        }

        private async Task<T> GetAsync<T>(RestRequest restRequest)
        {
            var client = new RestClient("https://localhost:44321/");
            client.Authenticator = new NtlmAuthenticator();

            var response = await client.GetAsync<T>(restRequest);

            return response;
        }

        private async Task<T> PostAsync<T>(RestRequest restRequest)
        {
            var client = new RestClient("https://localhost:44321/");
            client.Authenticator = new NtlmAuthenticator();

            var response = await client.PostAsync<T>(restRequest);

            return response;
        }
    }
}
