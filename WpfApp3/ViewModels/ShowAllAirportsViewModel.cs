using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class ShowAllAirportsViewModel : BaseViewModel, IPageViewModel
    {
        private AirportModel _selectedAirport;
        private readonly IAirportService _airportService;
        private readonly IUserDialogService _dialogService;

        public ObservableCollection<AirportModel> Airports { get; set; }
            
        public ShowAllAirportsViewModel(IAirportService airportService, IUserDialogService dialogService)
        {
            _airportService = airportService;
            _dialogService = dialogService;
            Airports = new ObservableCollection<AirportModel>();
        }

        private ICommand _addAirport;
        private ICommand _editAirport;
        private ICommand _deleteAirport;

        public ICommand AddAirport => _addAirport ??= new RelayCommand(OnAddAirportCommandExecute, CanAlwaysExecute);

        public ICommand EditAirport =>
            _editAirport ??= new RelayCommand(OnEditAirportCommandExecute, IsAirportSelected);
        public ICommand DeleteAirport => _deleteAirport ??= new RelayCommand(OnDeleteAirportCommandExecute, IsAirportSelected);

        private bool CanAlwaysExecute(object a) => true;
        private bool IsAirportSelected(object a) => _selectedAirport != null;

        private void OnAddAirportCommandExecute(object a)
        {
            _dialogService.Add(a);
            UpdateAirports();
        }

        private void OnEditAirportCommandExecute(object a)
        {
            _dialogService.Edit(a);
            UpdateAirports();
        }

        private void OnDeleteAirportCommandExecute(object a)
        {
            Airports.Remove(a as AirportModel);
            _airportService.RemoveAirport(((AirportModel)a).Id);
        }
        
        public AirportModel SelectedAirport
        {
            get => _selectedAirport;
            set => Set(ref _selectedAirport, value);
        }

        private void UpdateAirports()
        {
            Airports.Clear();
            foreach (var airport in _airportService.GetAllAirports())
            {
                Airports.Add(airport); 
            }
        }
    }
}