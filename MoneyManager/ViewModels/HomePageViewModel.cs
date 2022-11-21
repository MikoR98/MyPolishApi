using MoneyManager.Interfaces;
using MoneyManager.Services;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using Prism.Regions;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IRestService _restService;
        private AppConfiguration _appConfiguration;

        private decimal _accountBalance;
        private decimal _currentBalance;
        private string _myAccountName;
        private string _acountName;
        private string _accountNumber;
        private string _iBAN;
        private string _bicSwift;
        private string _authorizedPersons;

        public HomePageViewModel(IRestService restService, AppConfiguration appConfiguration)
        {
            _restService = restService;
            _appConfiguration = appConfiguration;
        }

        public decimal AccountBalance
        {
            get { return _accountBalance; }
            set { SetProperty(ref _accountBalance, value); }
        }
        public decimal CurrentBalance
        {
            get { return _currentBalance; }
            set { SetProperty(ref _currentBalance, value); }
        }
        public string MyAccountName
        {
            get { return _myAccountName; }
            set { SetProperty(ref _myAccountName, value); }
        }
        public string AccountName
        {
            get { return _acountName; }
            set { SetProperty(ref _acountName, value); }
        }
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { SetProperty(ref _accountNumber, value); }
        }
        public string IBAN
        {
            get { return _iBAN; }
            set { SetProperty(ref _iBAN, value); }
        }
        public string BicSwift
        {
            get { return _bicSwift; }
            set { SetProperty(ref _bicSwift, value); }
        }
        public string AuthorizedPersons
        {
            get { return _authorizedPersons; }
            set { SetProperty(ref _authorizedPersons, value); }
        }

        protected override async Task NavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        protected override async Task NavigatedTo(NavigationContext navigationContext)
        {
            var userAccount = await _restService.GetAccountAsync(_appConfiguration.AccountNumber);
            var transactions = await _restService.GetTransactionInfoAsync(_appConfiguration.AccountNumber);

            var sumOfTransaction = transactions.Sum(_ => _.Amount);

            if (userAccount != null)
            {
                AccountBalance = userAccount.AvailableBalance;
                CurrentBalance = userAccount.BookingBalance;
                MyAccountName = userAccount.AccountNameClient;
                AccountName = userAccount.AccountTypeName;
                AccountNumber = userAccount.AccountNumber;
                IBAN = userAccount.BicOrSwift;
                BicSwift = userAccount.BicOrSwift;
                AuthorizedPersons = _appConfiguration.Owner;
            }
        }
    }
}
