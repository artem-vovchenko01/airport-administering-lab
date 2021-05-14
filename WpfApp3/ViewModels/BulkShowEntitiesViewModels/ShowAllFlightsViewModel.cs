using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly IAirportService _airportService;
        private SelectedAirportWrapper _selectedAirportWrapper;

        private IEnumerable<AirportModel> _airports;
        public ObservableCollection<FlightModel> Flights { get; set; }

        private IEnumerable<AirportModel> Airports
        {
            get => _airports;
            set
            {
                _airports = value;
                _airportWrappers = _airports.Select(a => new SelectedAirportWrapper {Airport = a, IsAllAirport = false}).ToList();
                _airportWrappers.Insert(0, new SelectedAirportWrapper {IsAllAirport = true});
            }
        }

        private List<SelectedAirportWrapper> _airportWrappers { get; set; }

        public List<SelectedAirportWrapper> AirportWrappers
        {
            get => _airportWrappers;
        }
        public FlightModel SelectedFlight
        {
            get => _selectedFlight;
            set => Set(ref _selectedFlight, value);
        }

        public SelectedAirportWrapper SelectedAirportWrapper
        {
            get => _selectedAirportWrapper;
            set
            {
                Set(ref _selectedAirportWrapper, value);
                UpdateFlights();
            }
        }

        public ShowAllFlightsViewModel(IFlightService flightService, IUserDialogService dialogService, IAirportService airportService)
        {
            _dialogService = dialogService;
            _flightService = flightService;
            _airportService = airportService;
            Flights = new ObservableCollection<FlightModel>();
            Airports = _airportService.GetAllAirports();
            UpdateFlights();
        }

        private void UpdateFlights()
        {
            Flights.Clear();
            IEnumerable<FlightModel> updFlights;
            if (_selectedAirportWrapper == null || _selectedAirportWrapper.IsAllAirport)
                updFlights = _flightService.GetAllFlights();
            else
                updFlights = _flightService.GetFlightsByAirport(_selectedAirportWrapper.Airport.Id);
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
