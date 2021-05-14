using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Entities;
using Model;
using Services.Abstract;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels
{
    public class ChooseSeatsViewModel : BaseViewModel, IPageViewModel
    {
        private ObservableCollection<SeatModel> _seats;
        private TicketModel _ticket;
        private SeatModel _clickedSeat;
        private readonly ITicketService _ticketService;
        private readonly IFlightService _flightService;
        private FlightModel _flight;

        public SeatModel ClickedSeat
        {
            get
            {
                return _clickedSeat;
            }
            set
            {
                _clickedSeat = value;
                var state = _seats[_clickedSeat.Number - 1].State;
                if (state == SeatState.Chosen) _seats[_clickedSeat.Number-1].State = SeatState.Free;
                else if (state == SeatState.Free) _seats[_clickedSeat.Number-1].State = SeatState.Chosen;
            }
        }

        private ICommand _itemClicked;

        public ICommand ItemClicked
        {
            get => _itemClicked ??= new RelayCommand((seat) => ClickedSeat = _seats[(int)seat - 1], (obj) => true);
        }

        public TicketModel TicketModel
        {
            get => _ticket;
            set
            {
                _ticket = value;
                _flight = _ticket.Flight;
            }
        }

        public ObservableCollection<SeatModel> Seats
        {
            get => _seats;
        }
        
        public ChooseSeatsViewModel(ITicketService ticketService, IFlightService flightService)
        {
            _ticketService = ticketService;
            _flightService = flightService;
            _seats = new ObservableCollection<SeatModel>();
        }

        public void InitializeSeats()
        {
            int maxSeat = _flight.Airplane.Seats;
            var free = _flightService.SeatsAvailable(_flight).ToList();
            for (int seat = 1; seat <= maxSeat; seat++) _seats.Add(new SeatModel {Number = seat, State = SeatState.Occupied});
            foreach (var seat in free)
                _seats[seat-1].State = SeatState.Free;
            var alreadyChosen = _ticket.OccupiedSeats ??= new List<int>();
            foreach (var seat in alreadyChosen)
            {
                _seats[seat - 1].State = SeatState.Chosen;
            }
        }
    }
}