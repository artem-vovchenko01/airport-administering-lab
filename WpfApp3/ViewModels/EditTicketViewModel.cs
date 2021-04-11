using System.Collections;
using System.Collections.Generic;
using Model;

namespace WpfApp3.ViewModels
{
    public class EditTicketViewModel : BaseViewModel, IPageViewModel
    {
        private TicketModel _ticket;
        private IEnumerable<FlightModel> _flights;
        private IEnumerable<PassengerModel> _passengers;
        private FlightModel _selectedFlight;
        private PassengerModel _selectedPassenger;

        public TicketModel Ticket
        {
            get => _ticket;
            set => Set(ref _ticket, value);
        }

        public IEnumerable<FlightModel> Flights
        {
            get => _flights;
            set => Set(ref _flights, value);
        }

        public IEnumerable<PassengerModel> Passengers
        {
            get => _passengers;
            set => Set(ref _passengers, value);
        }

        public FlightModel SelectedFlight
        {
            get => _selectedFlight;
            set => Set(ref _selectedFlight, value);
        }

        public PassengerModel SelectedPassenger
        {
            get => _selectedPassenger;
            set => Set(ref _selectedPassenger, value);
        }
    }
}
