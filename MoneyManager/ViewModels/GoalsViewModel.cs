using MoneyManager.Interfaces;
using MoneyManager.Models;
using MoneyManager.Services;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyManager.ViewModels
{
    public class GoalsViewModel : ViewModelBase
    {
        private readonly IRestService _restService;
        private AppConfiguration _appConfiguration;

        private GoalModel _selectedGoal;
        private decimal? _goalAmount;
        private Visibility _addGoalVisibility;

        public GoalsViewModel(IRestService restService, AppConfiguration appConfiguration)
        {
            _restService = restService;
            _appConfiguration = appConfiguration;

            GoalCollection = new ObservableCollection<GoalModel>();

            PayExtraCommand = new DelegateCommand<object>(_ => PayExtraAction(_));
            SaveGoalCommand = new DelegateCommand(async () => await SaveGoalAction());
            CancelGoalCommand = new DelegateCommand(CancelGoalAction);

            AddGoalVisibility = Visibility.Collapsed;
        }

        public ObservableCollection<GoalModel> GoalCollection { get; set; }

        public GoalModel SelectedGoal
        {
            get { return _selectedGoal; }
            set { SetProperty(ref _selectedGoal, value); }
        }

        public DelegateCommand<object> PayExtraCommand { get; set; }
        public DelegateCommand SaveGoalCommand { get; set; }
        public DelegateCommand CancelGoalCommand { get; set; }

        public decimal? GoalAmount
        {
            get { return _goalAmount; }
            set { SetProperty(ref _goalAmount, value); }
        }

        public Visibility AddGoalVisibility
        {
            get { return _addGoalVisibility; }
            set { SetProperty(ref _addGoalVisibility, value); }
        }

        private void PayExtraAction(object parameters)
        {
            if (parameters is GoalModel selectedGoal)
            {
                SelectedGoal = selectedGoal;
                AddGoalVisibility = Visibility.Visible;
            }
        }

        private async Task SaveGoalAction()
        {
            if (!string.IsNullOrWhiteSpace(SelectedGoal.Name) && GoalAmount > 0m)
            {
                var isAmountAvailable = await _restService.GetConfirmationOfFunds(SelectedGoal.AccountNumber, GoalAmount.Value, SelectedGoal.Currency);

                if (isAmountAvailable)
                {
                    var result = await _restService.Domestic(_appConfiguration.AccountNumber, SelectedGoal.AccountNumber, "zasilenie", GoalAmount.Value, SelectedGoal.Currency, DateTime.Now);

                    if (result)
                    {
                        SelectedGoal.Amount += GoalAmount.Value;
                        int index = GoalCollection.IndexOf(SelectedGoal);
                        GoalCollection.RemoveAt(index);
                        GoalCollection.Insert(index, SelectedGoal);
                    }
                }

                AddGoalVisibility = Visibility.Collapsed;
            }
        }

        private void CancelGoalAction()
        {
            AddGoalVisibility = Visibility.Collapsed;

            SelectedGoal = null;
            GoalAmount = null;
        }

        protected override async Task NavigatedFrom(NavigationContext navigationContext)
        {

        }

        protected override async Task NavigatedTo(NavigationContext navigationContext)
        {
            GoalCollection.Clear();

            var accountInfo = await _restService.GetAccountAsync(_appConfiguration.AccountNumber);

            foreach (var linkedAccount in accountInfo.LinkedAccount)
            {
                var linkedAccountInfo = await _restService.GetAccountAsync(linkedAccount.LinkedAccountNumber);

                GoalCollection.Add(new GoalModel
                {
                    AccountNumber = linkedAccountInfo.AccountNumber,
                    Name = linkedAccountInfo.AccountNameClient,
                    Amount = linkedAccountInfo.AvailableBalance,
                    Currency = linkedAccountInfo.Currency
                });
            }
        }
    }
}
