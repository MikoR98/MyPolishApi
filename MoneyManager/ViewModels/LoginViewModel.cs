using MoneyManager.Interfaces;
using MoneyManager.Services;
using MoneyManager.Views;
using Prism.Commands;
using Prism.Regions;
using System.Threading.Tasks;

namespace MoneyManager.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IRestService _restService;
        private readonly IRegionManager _regionManager;
        private AppConfiguration _appConfiguration;

        private string _loginMessage;
        private bool _incorrectLogin;

        public LoginViewModel(IRestService restService,
            IRegionManager regionManager,
            AppConfiguration appConfiguration)
        {
            _restService = restService;
            _regionManager = regionManager;
            _appConfiguration = appConfiguration;

            LoginMessage = "Zaloguj się";
            IncorrectLogin = false;

            LoginCommand = new DelegateCommand(async () => await LoginAction());
        }

        public DelegateCommand LoginCommand { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public string LoginMessage
        {
            get { return _loginMessage; }
            set { SetProperty(ref _loginMessage, value); }
        }

        public bool IncorrectLogin
        {
            get { return _incorrectLogin; }
            set { SetProperty(ref _incorrectLogin, value); }
        }

        private async Task LoginAction()
        {
            var userAccount = await _restService.LoginAsync(Login, Password);

            if (userAccount != null && !string.IsNullOrWhiteSpace(userAccount.AccountNumber))
            {
                _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(Menu));
                _regionManager.RequestNavigate(RegionNames.MenuRegion, nameof(Menu));

                _appConfiguration.AccountNumber = userAccount.AccountNumber;
                _appConfiguration.Owner = userAccount.OwnerName;

                _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(HomePage));
            }
            else
            {
                LoginMessage = "Niepoprawne dane logowania. Wpisz poprwny login i hasło";
                IncorrectLogin = true;
            }
        }

        protected override async Task NavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
