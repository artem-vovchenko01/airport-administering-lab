using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class TicketsByFlightViewModel : BaseViewModel, IPageViewModel
    {
         private TicketModel _selectedTicket;
         private readonly ITicketService _ticketService;
         private readonly IUserDialogService _dialogService;
         private FlightModel _currentFlightModel;

         public FlightModel CurrentFlightModel
         {
             get => _currentFlightModel;
             set
             {
                 _currentFlightModel = value;
                 UpdateTickets();
             }
         }

         public ObservableCollection<TicketModel> Tickets { get; set; }
 
         public TicketsByFlightViewModel(ITicketService ticketService, IUserDialogService dialogService, IFlightService flightService)
         {
             _ticketService = ticketService;
             _dialogService = dialogService;
             Tickets = new ObservableCollection<TicketModel>();
         }
 
         public TicketModel SelectedTicket
         {
             get => _selectedTicket;
             set => Set(ref _selectedTicket, value);
         }
 
         public void UpdateTickets()
         {
             Tickets.Clear();
             var tickets = _ticketService.SoldTickets(CurrentFlightModel);
             foreach (var ticketModel in tickets)
             {
                 Tickets.Add(ticketModel);
             }

         }
 
         private ICommand _addTicket;
         private ICommand _editTicket;
         private ICommand _deleteTicket;
 
         public ICommand AddTicket => _addTicket ??= new RelayCommand(OnAddTicketCommandExecute, CanAlwaysExecute);
         public ICommand EditTicket => _editTicket ??= new RelayCommand(OnEditTicketCommandExecute, IsTicketSelected);
         public ICommand DeleteTicket => _deleteTicket ??= new RelayCommand(OnDeleteTicketCommandExecute, IsTicketSelected);
 
         private bool CanAlwaysExecute(object t) => true;
         private bool IsTicketSelected(object t) => _selectedTicket != null;
 
         private void OnAddTicketCommandExecute(object t)
         {
             _dialogService.Add(new TicketModel { OccupiedSeats = new List<int>()});
             UpdateTickets();
         }
 
         private void OnEditTicketCommandExecute(object t)
         {
             _dialogService.Edit(t);
             UpdateTickets();
         }
 
         private void OnDeleteTicketCommandExecute(object t)
         {
             Tickets.Remove(t as TicketModel);
             _ticketService.RemoveTicket(((TicketModel)t).Id);
         }       
    }
}