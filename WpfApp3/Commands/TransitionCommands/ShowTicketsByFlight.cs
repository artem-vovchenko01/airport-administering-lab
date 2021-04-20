using Model;
using WpfApp3.ViewModels;

namespace WpfApp3.Commands.TransitionCommands
{
    public class ShowTicketsByFlight 
    {
        public void Show(FlightModel flightModel)
        {
            MainWindowViewModel.CurrentInstance.ShowTicketsByFlight(flightModel);
        }
    }
}