using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.BulkShowEntitiesViewModels
{
    public class ShowAllAirplanesViewModel : BaseViewModel, IPageViewModel
    {
        private AirplaneModel _selectedAirplane;
        private readonly IAirplaneService _airplaneService;
        private readonly IUserDialogService _dialogService;

        public AirplaneModel SelectedAirplane
        {
            get => _selectedAirplane;
            set => Set(ref _selectedAirplane, value);
        }
        public ObservableCollection<AirplaneModel> Airplanes { get; set; }

        public ShowAllAirplanesViewModel(IAirplaneService airplaneService, IUserDialogService dialogService)
        {
            _airplaneService = airplaneService;
            _dialogService = dialogService;
            Airplanes = new ObservableCollection<AirplaneModel>();
            UpdateAirplanes();
        }

        private ICommand _addAirplane;
        private ICommand _editAirplane;
        private ICommand _deleteAirplane;

        public ICommand AddAirplane => _addAirplane ??= new RelayCommand(OnAddAirplaneCommandExecute, CanAlwaysExecute);
        public ICommand EditAirplane => _editAirplane ??= new RelayCommand(OnEditAirplaneCommandExecute, IsAirplaneSelected);
        public ICommand DeleteAirplane => _deleteAirplane ??= new RelayCommand(OnDeleteAirplaneCommandExecute, IsAirplaneSelected);

        private bool CanAlwaysExecute(object a) => true;
        private bool IsAirplaneSelected(object a) => _selectedAirplane != null;

        private void OnAddAirplaneCommandExecute(object a)
        {
            _dialogService.Add(new AirplaneModel());
            UpdateAirplanes();
        }

        private void OnEditAirplaneCommandExecute(object a)
        {
            _dialogService.Edit(a);
            UpdateAirplanes();
        }

        private void OnDeleteAirplaneCommandExecute(object a)
        {
            Airplanes.Remove(a as AirplaneModel);
            _airplaneService.RemoveAirplane(((AirplaneModel)a).Id);
        }

        private void UpdateAirplanes()
        {
            Airplanes.Clear();
            foreach (var airplane in _airplaneService.GetAllAirplanes())
            {
                Airplanes.Add(airplane); 
            }
        }
    }
}