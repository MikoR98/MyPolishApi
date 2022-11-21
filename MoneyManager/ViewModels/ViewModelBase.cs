using Prism.Mvvm;
using Prism.Regions;
using System.Threading.Tasks;

namespace MoneyManager.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return NavigationTarget(navigationContext);
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Task result = Task.Run(async () => 
            {
                await NavigatedFrom(navigationContext);
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Task result = NavigatedTo(navigationContext);
        }

        protected virtual async Task NavigatedTo(NavigationContext navigationContext)
        {
            
        }

        protected virtual async Task NavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual bool NavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
    }
}
