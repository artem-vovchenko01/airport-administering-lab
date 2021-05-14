using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.BulkShowEntitiesViewModels
{
    public class ShowAllPassengersViewModel : BaseViewModel, IPageViewModel
    {
        private PassengerModel _selectedPassenger;
        private readonly IUserDialogService _dialogService;
        private readonly IPassengerService _passengerService;

        public PassengerModel SelectedPassenger
        {
            get => _selectedPassenger;
            set => Set(ref _selectedPassenger, value);
        }
        public ObservableCollection<PassengerModel> Passengers { get; set; }
        
        public ShowAllPassengersViewModel(IPassengerService passengerService, IUserDialogService dialogService)
        {
            _passengerService = passengerService;
            _dialogService = dialogService;
            Passengers = new ObservableCollection<PassengerModel>();
            UpdatePassengers();
        }

        private void UpdatePassengers()
        {
            Passengers.Clear();
            var passengers = _passengerService.GetAllPassengers();
            foreach (var passengerModel in passengers)
            {
                Passengers.Add(passengerModel); 
            }
        }
        
        private ICommand _addPassenger;
        private ICommand _editPassenger;
        private ICommand _deletePassenger;

        public ICommand AddPassenger => _addPassenger ??= new RelayCommand(OnAddPassengerCommandExecute, (obj) => true);
        public ICommand EditPassenger => _editPassenger ??= new RelayCommand(OnEditPassengerCommandExecute, IsPassengerSelected);
        public ICommand DeletePassenger => _deletePassenger ??= new RelayCommand(OnDeletePassengerCommandExecute, IsPassengerSelected);

        private bool IsPassengerSelected(object p) => _selectedPassenger != null;

        private void OnAddPassengerCommandExecute(object p)
        {
            _dialogService.Add(new PassengerModel());
            UpdatePassengers();
        }

        private void OnEditPassengerCommandExecute(object p)
        {
            _dialogService.Edit(p);
            UpdatePassengers();
        }

        private void OnDeletePassengerCommandExecute(object p)
        {
            Passengers.Remove(p as PassengerModel);
            _passengerService.RemovePassenger(((PassengerModel)p).Id);
        }
        
    }
}
