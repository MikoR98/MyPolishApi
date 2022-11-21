using DevExpress.Mvvm.Native;
using MoneyManager.Interfaces;
using MoneyManager.Models;
using MoneyManager.Properties;
using MoneyManager.Services;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MoneyManager.ViewModels
{
    public class ExpensesAnalysisViewModel : ViewModelBase
    {
        private readonly IRestService _restService;
        private AppConfiguration _appConfiguration;

        private decimal _accountBalance;
        private string _acountTypeName;

        public ExpensesAnalysisViewModel(IRestService restService, AppConfiguration appConfiguration)
        {
            _restService = restService;
            _appConfiguration = appConfiguration;

            Transactions = new ObservableCollection<ExpensesAnalysisModel>();

            SelectedItemChangedCommand = new DelegateCommand<object>(SelectedItemChangedAction);
        }

        public DelegateCommand<object> SelectedItemChangedCommand { get; set; }

        public ObservableCollection<ExpensesAnalysisModel> Transactions { get; set; }
        public Dictionary<string, string> ExpenseCategories { get; set; }

        public decimal AccountBalance
        {
            get { return _accountBalance; }
            set { SetProperty(ref _accountBalance, value); }
        }

        public string AccountTypeName
        {
            get { return _acountTypeName; }
            set { SetProperty(ref _acountTypeName, value); }
        }

        private void SelectedItemChangedAction(object parameters)
        {
            if (parameters != null && parameters is List<string> listOfParameters && listOfParameters.Count == 2)
            {
                var transactionId = listOfParameters[1];
                var categoryName = listOfParameters[0];

                foreach (SettingsProperty item in Settings.Default.Properties)
                {
                    if (Settings.Default[item.Name] is StringCollection listOfValues && listOfValues.Contains(transactionId))
                    {
                        listOfValues.Remove(transactionId);
                        Settings.Default[item.Name] = listOfValues;

                        break;
                    }
                }

                var category = Settings.Default[categoryName];
                if (category == null)
                    category = new StringCollection();
                    
                ((StringCollection)category).Add(transactionId);
                Settings.Default[categoryName] = category;

                Settings.Default.Save();
            }
        }

        private string GetCategoryForTransaction(string transactionId)
        {
            string category = string.Empty;

            foreach (SettingsProperty item in Settings.Default.Properties)
            {
                if (Settings.Default[item.Name] != null)
                {
                    if (Settings.Default[item.Name] is StringCollection listOfValues && listOfValues.Contains(transactionId))
                    {
                        category = item.Name;

                        break;
                    }
                }
            }

            return category;
        }

        protected override async Task NavigatedFrom(NavigationContext navigationContext)
        {

        }

        protected override async Task NavigatedTo(NavigationContext navigationContext)
        {
            var transactions = await _restService.GetTransactionInfoAsync(_appConfiguration.AccountNumber);
            var userAccount = await _restService.GetAccountAsync(_appConfiguration.AccountNumber);

            var ordered = new Dictionary<string, string>();
            foreach (SettingsProperty item in Settings.Default.Properties)
            {
                if (!item.Name.StartsWith("Budget"))
                    ordered.Add(item.Name, item.Name.Replace('_', ' '));
            }

            ExpenseCategories = new Dictionary<string, string>(ordered.OrderBy(_ => _.Value));

            Transactions.Clear();
            transactions.OrderByDescending(_ => _.TradeDate).ForEach(_ => Transactions.Add(new ExpensesAnalysisModel()
            {
                Id = _.ItemId,
                Amount = _.Amount,
                Currency = _.Currency,
                Description = _.Description,
                PostTransactionBalance = _.PostTransactionBalance,
                TradeDate = _.TradeDate.Value.ToString("D", CultureInfo.CurrentUICulture),
                TransactionCategory = _.TransactionCategory,
                TransactionStatus = _.TransactionStatus,
                Sender = _.Sender,
                Recipient = _.Recipient,
                ExpenseCategory = GetCategoryForTransaction(_.ItemId)
            }));

            AccountBalance = userAccount.AvailableBalance;
            AccountTypeName = userAccount.AccountTypeName;
        }
    }
}
