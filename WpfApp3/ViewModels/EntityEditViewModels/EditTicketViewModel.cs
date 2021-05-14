using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Model;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.EntityEditViewModels
{
    public class EditTicketViewModel : BaseViewModel, IPageViewModel
    {
        private TicketModel _ticket;
        private IEnumerable<FlightModel> _flights;
        private IEnumerable<PassengerModel> _passengers;
        private ICommand _openChooseSeatsDialog;
        private readonly IUserDialogService _dialogService;
        private bool _areSeatsSelected = false;
        private ICommand _closeDialog;

        public ICommand CloseDialog =>
            _closeDialog ??= new RelayCommand(OnCloseDialogCommandExecute, CanSaveAndClose);

        private bool CanSaveAndClose(object param)
        {
            VerifySeatsSelected();
            return _areSeatsSelected && _ticket.Flight != null && _ticket.Passenger != null;
        }

        private void VerifySeatsSelected()
        {
            if (_ticket.OccupiedSeats.Count == 0) _areSeatsSelected = false;
        }
        private void OnCloseDialogCommandExecute(object parameter)
        {
            var window = (Window) parameter;
            window.DialogResult = true;
            window.Close();
        }

        public EditTicketViewModel(IUserDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        
        public ICommand OpenChooseSeatsDialog => _openChooseSeatsDialog ??= new RelayCommand(OnOpenChooseSeatsDialogCommandExecute, o => _ticket.Flight != null);

        private void OnOpenChooseSeatsDialogCommandExecute(object obj)
        {
            var ticket = new TicketModel
            {
                Flight = _ticket.Flight,
                OccupiedSeats = _ticket.OccupiedSeats
            };
            (bool success, var seats) = _dialogService.ChooseSeats(ticket);
            if (success)
            {
                _ticket.Adults = seats.Count;
                _ticket.OccupiedSeats = seats;
                _areSeatsSelected = true;
            }
        }

        public TicketModel Ticket
        {
            get => _ticket;
            set
            {
                Set(ref _ticket, value);
                if (_ticket.OccupiedSeats.Count > 0) _areSeatsSelected = true;
            }
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
    }
}
