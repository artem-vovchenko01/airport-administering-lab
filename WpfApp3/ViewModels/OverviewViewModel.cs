using System.Windows.Input;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels
{
    public class OverviewViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _showAllFlights;
        private ICommand _showAllRoutes;

        public OverviewViewModel()
        {
        }
        public ICommand ShowAllFlights
        {
            get
            {
                return _showAllFlights ??= new RelayCommand(obj =>
                {
                    Mediator.Notify("ShowAllFlights", "");
                });
            }
        }

        public ICommand ShowAllRoutes
        {
            get
            {
                return _showAllRoutes ??= new RelayCommand(obj =>
                {
                    Mediator.Notify("ShowAllRoutes", "");
                });
            }
        }
    }
}