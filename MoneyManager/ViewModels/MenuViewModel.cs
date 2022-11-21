using MoneyManager.Views;
using Prism.Commands;
using Prism.Regions;

namespace MoneyManager.ViewModels
{
    public class MenuViewModel
    {
        private readonly IRegionManager _regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            HomePageCommand = new DelegateCommand(HomePageAction);
            ExpensesAnalysisCommand = new DelegateCommand(ExpensesAnalysisAction);
            BudgetCommand = new DelegateCommand(BudgetAction);
            GoalsCommand = new DelegateCommand(GoalsAction);
        }

        public DelegateCommand HomePageCommand { get; set; }
        public DelegateCommand ExpensesAnalysisCommand { get; set; }
        public DelegateCommand BudgetCommand { get; set; }
        public DelegateCommand GoalsCommand { get; set; }

        private void HomePageAction()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(HomePage));
        }

        private void ExpensesAnalysisAction()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(ExpensesAnalysis));
        }

        private void BudgetAction()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(Budget));
        }

        private void GoalsAction()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(Goals));
        }
    }
}
