using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Model;
using Services;
using Services.Abstract;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels
{
    public class SelectFlightViewModel : BaseViewModel, IPageViewModel
    {
        private FlightModel _selectedFlight;
        private ICommand _confirmSelection;
        private readonly IFlightService _flightService;
        
        public IEnumerable<FlightModel> Flights { get; set; }

        public SelectFlightViewModel(IFlightService flightService)
        {
            _flightService = flightService;
            Flights = _flightService.GetAllFlights();
        }
        
        public FlightModel SelectedFlight
        {
            get => _selectedFlight;
            set => Set(ref _selectedFlight, value);
        }

        public ICommand ConfirmSelection => _confirmSelection ??= new RelayCommand(OnConfirmSelectionCommandExecute, IsFlightSelected);

        private bool IsFlightSelected(object f) => _selectedFlight != null;

        private void OnConfirmSelectionCommandExecute(object f)
        {
            var window = (Window) f;
            window.DialogResult = true;
            window.Close();
        }
    }
}