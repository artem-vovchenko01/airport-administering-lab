using System.Windows.Input;
using Model;
using WpfApp3.Commands;
using WpfApp3.Commands.TransitionCommands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class OverviewViewModel : BaseViewModel, IPageViewModel
    {
        private readonly IUserDialogService _dialogService;

        public OverviewViewModel(IUserDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private ICommand _showTicketsBySelectedFlight;

        public ICommand ShowTicketsBySelectedFlight => _showTicketsBySelectedFlight ??=
            new RelayCommand(OnShowTicketsBySelectedFlightCommandExecute, (obj) => true);
        
        private void OnShowTicketsBySelectedFlightCommandExecute(object obj)
        {
            (bool success, FlightModel flight) = _dialogService.SelectFlight();
            if (success)
            {
                var comm = new ShowTicketsByFlight();
                comm.Show(flight);
            } 
        }
    }
}