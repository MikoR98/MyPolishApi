using MoneyManager.Interfaces;
using MoneyManager.Models;
using MoneyManager.Properties;
using MoneyManager.Services;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using Prism.Commands;
using Prism.Regions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyManager.ViewModels
{
    public class BudgetViewModel : ViewModelBase
    {
        private readonly IRestService _restService;
        private AppConfiguration _appConfiguration;

        private List<TransactionInfo> _transactionsDone;
        private List<TransactionScheduledInfo> _transactionsScheduled;

        private decimal _budget;
        private decimal _newBudget;
        private decimal _freeBudget;
        private decimal _moneySpent;
        private decimal _moneyScheduled;
        private string _monthName;
        private string _monthPeriod;
        private Visibility _editBudgetLabelVisibility;
        private Visibility _editBudgetTextBoxVisibility;
        private Visibility _nextMonthVisibility;
        private Visibility _previousMonthVisibility;
        private DateTime _currentDate;
        private DateTime _dateAvailableOnView;
        private DateTime _firstTransactionDate;
        private string _budgetPeriod;

        public BudgetViewModel(IRestService restService, AppConfiguration appConfiguration)
        {
            _restService = restService;
            _appConfiguration = appConfiguration;

            BudgetCollection = new ObservableCollection<BudgetModel>();

            EditBudgetCommand = new DelegateCommand(EditBudgetAction);
            SaveBudgetCommand = new DelegateCommand(SaveBudgetAction);
            RejectBudgetCommand = new DelegateCommand(RejectBudgetAction);
            NextMonthCommand = new DelegateCommand(NextMonthAction);
            PreviousMonthCommand = new DelegateCommand(PreviousMonthAction);

            EditBudgetLabelVisibility = Visibility.Visible;
            EditBudgetTextBoxVisibility = Visibility.Collapsed;
        }

        public DelegateCommand EditBudgetCommand { get; set; }
        public DelegateCommand SaveBudgetCommand { get; set; }
        public DelegateCommand RejectBudgetCommand { get; set; }
        public DelegateCommand NextMonthCommand { get; set; }
        public DelegateCommand PreviousMonthCommand { get; set; }

        public ObservableCollection<BudgetModel> BudgetCollection { get; set; }

        public List<ExpensesAnalysisModel> Transactions { get; set; }

        public decimal Budget
        {
            get { return _budget; }
            set { SetProperty(ref _budget, value); }
        }

        public decimal NewBudget
        {
            get { return _newBudget; }
            set { SetProperty(ref _newBudget, value); }
        }

        public decimal FreeBudget
        {
            get { return _freeBudget; }
            set { SetProperty(ref _freeBudget, value); }
        }

        public decimal MoneySpent
        {
            get { return _moneySpent; }
            set { SetProperty(ref _moneySpent, value); }
        }

        public decimal MoneyScheduled
        {
            get { return _moneyScheduled; }
            set { SetProperty(ref _moneyScheduled, value); }
        }

        public string MonthName
        {
            get { return _monthName; }
            set { SetProperty(ref _monthName, value); }
        }

        public string MonthPeriod
        {
            get { return _monthPeriod; }
            set { SetProperty(ref _monthPeriod, value); }
        }

        public Visibility EditBudgetLabelVisibility
        {
            get { return _editBudgetLabelVisibility; }
            set { SetProperty(ref _editBudgetLabelVisibility, value); }
        }

        public Visibility EditBudgetTextBoxVisibility
        {
            get { return _editBudgetTextBoxVisibility; }
            set { SetProperty(ref _editBudgetTextBoxVisibility, value); }
        }

        public Visibility NextMonthVisibility
        {
            get { return _nextMonthVisibility; }
            set { SetProperty(ref _nextMonthVisibility, value); }
        }

        public Visibility PreviousMonthVisibility
        {
            get { return _previousMonthVisibility; }
            set { SetProperty(ref _previousMonthVisibility, value); }
        }

        private void EditBudgetAction()
        {
            EditBudgetLabelVisibility = Visibility.Collapsed;
            EditBudgetTextBoxVisibility = Visibility.Visible;
        }

        private void SaveBudgetAction()
        {
            _appConfiguration.AddOrUpdateBudgetForMonth(NewBudget, _budgetPeriod);

            Budget = NewBudget;
            FreeBudget = Budget - (MoneySpent + MoneyScheduled);

            BudgetCollection.Clear();
            BudgetCollection.Add(new BudgetModel { Argument = "Wydano", Value = MoneySpent });
            BudgetCollection.Add(new BudgetModel { Argument = "Zaplanowane wydatki", Value = MoneyScheduled });
            BudgetCollection.Add(new BudgetModel { Argument = "Do Wydania", Value = FreeBudget });

            EditBudgetLabelVisibility = Visibility.Visible;
            EditBudgetTextBoxVisibility = Visibility.Collapsed;
        }

        private void RejectBudgetAction()
        {
            NewBudget = Budget;

            EditBudgetLabelVisibility = Visibility.Visible;
            EditBudgetTextBoxVisibility = Visibility.Collapsed;
        }

        private void SpecifyCurrentMonth()
        {
            _currentDate = DateTime.Now;
            _currentDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            _dateAvailableOnView = _currentDate;
        }

        private void PreviousMonthAction()
        {
            _dateAvailableOnView = _dateAvailableOnView.AddMonths(-1);

            PrepareTitle();

            CalculateBudget();

            BudgetCollection.Clear();
            BudgetCollection.Add(new BudgetModel { Argument = "Wydano", Value = MoneySpent });
            BudgetCollection.Add(new BudgetModel { Argument = "Zaplanowane wydatki", Value = MoneyScheduled });
            BudgetCollection.Add(new BudgetModel { Argument = "Do wydania", Value = FreeBudget });

            if (_firstTransactionDate < _dateAvailableOnView)
                PreviousMonthVisibility = Visibility.Visible; 
            else
                PreviousMonthVisibility = Visibility.Collapsed;

            if (_currentDate > _dateAvailableOnView)
                NextMonthVisibility = Visibility.Visible;
            else
                NextMonthVisibility = Visibility.Collapsed;
        }

        private void NextMonthAction()
        {
            _dateAvailableOnView = _dateAvailableOnView.AddMonths(1);

            PrepareTitle();

            CalculateBudget();

            BudgetCollection.Clear();
            BudgetCollection.Add(new BudgetModel { Argument = "Wydano", Value = MoneySpent });
            BudgetCollection.Add(new BudgetModel { Argument = "Zaplanowane wydatki", Value = MoneyScheduled });
            BudgetCollection.Add(new BudgetModel { Argument = "Do wydania", Value = FreeBudget });

            if (_firstTransactionDate < _dateAvailableOnView)
                PreviousMonthVisibility = Visibility.Visible;
            else
                PreviousMonthVisibility = Visibility.Collapsed;

            if (_currentDate > _dateAvailableOnView)
                NextMonthVisibility = Visibility.Visible;
            else
                NextMonthVisibility = Visibility.Collapsed;
        }

        private void PrepareTitle()
        {
            var tmp = $"0{_dateAvailableOnView.Month}";
            var acctualMonth = tmp.Substring(tmp.Length - 2, 2);
            var lastDayInMonth = DateTime.DaysInMonth(_dateAvailableOnView.Year, _dateAvailableOnView.Month);

            MonthName = $"Twój miesiąc - {DateTimeFormatInfo.CurrentInfo.GetMonthName(_dateAvailableOnView.Month).ToUpper()}";
            MonthPeriod = $"01.{acctualMonth}.{_dateAvailableOnView.Year} - {lastDayInMonth}.{acctualMonth}.{_dateAvailableOnView.Year}";
        }

        private void CalculateBudget()
        {
            MoneySpent = _transactionsDone.Where(_ => _.BookingDate.Value.Month == _dateAvailableOnView.Month && _.BookingDate.Value.Year == _dateAvailableOnView.Year).Sum(_ => _.Amount);
            MoneyScheduled = _transactionsScheduled.Where(_ => _.TradeDate.Value.Month == _dateAvailableOnView.Month && _.TradeDate.Value.Year == _dateAvailableOnView.Year).Sum(_ => _.Amount);

            _budgetPeriod = $"Budget_{_dateAvailableOnView.Month}_{_dateAvailableOnView.Year}";

            Budget = _appConfiguration.GetBudgetForMonth(_budgetPeriod);
            NewBudget = Budget;
            FreeBudget = Budget - (MoneySpent + MoneyScheduled);
        }

        protected override async Task NavigatedFrom(NavigationContext navigationContext)
        {

        }

        protected override async Task NavigatedTo(NavigationContext navigationContext)
        {
            SpecifyCurrentMonth();

            _transactionsDone = await _restService.GetTransactionInfoAsync(_appConfiguration.AccountNumber);
            _transactionsScheduled = await _restService.GetTransactionScheduledAsync(_appConfiguration.AccountNumber);

            var minTransactionDate = _transactionsDone.Min(_ => _.BookingDate).Value;
            _firstTransactionDate = new DateTime(minTransactionDate.Year, minTransactionDate.Month, 1);

            PrepareTitle();

            CalculateBudget();

            BudgetCollection.Clear();
            BudgetCollection.Add(new BudgetModel { Argument = "Wydano", Value = MoneySpent });
            BudgetCollection.Add(new BudgetModel { Argument = "Zaplanowane wydatki", Value = MoneyScheduled });
            BudgetCollection.Add(new BudgetModel { Argument = "Do wydania", Value = FreeBudget });

            NextMonthVisibility = (_currentDate > _dateAvailableOnView) ? Visibility.Visible : Visibility.Collapsed;
            PreviousMonthVisibility = (_firstTransactionDate < _dateAvailableOnView) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
