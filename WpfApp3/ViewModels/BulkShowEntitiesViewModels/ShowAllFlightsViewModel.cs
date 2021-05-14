using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.BulkShowEntitiesViewModels
{
    public class ShowAllFlightsViewModel : BaseViewModel, IPageViewModel
    {
        private FlightModel _selectedFlight;
        private readonly IFlightService _flightService;
        private readonly IUserDialogService _dialogService;

        public ObservableCollection<FlightModel> Flights { get; set; }

        public FlightModel SelectedFlight
        {
            get => _selectedFlight;
            set => Set(ref _selectedFlight, value);
        }

        public ShowAllFlightsViewModel(IFlightService flightService, IUserDialogService dialogService)
        {
            _dialogService = dialogService;
            _flightService = flightService;
            Flights = new ObservableCollection<FlightModel>();
            UpdateFlights();
        }

        private void UpdateFlights()
        {
            Flights.Clear();
            var updFlights = _flightService.GetAllFlights();
            foreach (var flight in updFlights)
            {
                Flights.Add(flight);
            }
        }

        private ICommand _editFlight;
        private ICommand _deleteFlight;
        private ICommand _addFlight;

        public ICommand EditFlight =>
            _editFlight ??= new RelayCommand(OnEditFlightCommandExecute, IsFlightSelected);

        public ICommand DeleteFlight => _deleteFlight ??= new RelayCommand(OnDeleteFlightCommandExecute, IsFlightSelected);
        public ICommand AddFlight => _addFlight ??= new RelayCommand(OnAddFlightCommandExecute, (obj) => true);

        private bool IsFlightSelected(object f) => SelectedFlight != null;
        private void OnEditFlightCommandExecute(object f)
        {
            _dialogService.Edit(f);
            UpdateFlights();
        }

        private void OnDeleteFlightCommandExecute(object f)
        {
            Flights.Remove(f as FlightModel);
            _flightService.RemoveFlight(((FlightModel) f).Id);
        }

        private void OnAddFlightCommandExecute(object f)
        {
            _dialogService.Add(new FlightModel());
            UpdateFlights();
        }
    }
}
