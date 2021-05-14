using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.BulkShowEntitiesViewModels
{
    public class ShowAllCarriersViewModel : BaseViewModel, IPageViewModel
    {
        private CarrierModel _selectedCarrier;
        private readonly IUserDialogService _dialogService;
        private readonly ICarrierService _carrierService;

        public CarrierModel SelectedCarrier
        {
            get => _selectedCarrier;
            set => Set(ref _selectedCarrier, value);
        }
        
        public ObservableCollection<CarrierModel> Carriers { get; set; }

        public ShowAllCarriersViewModel(ICarrierService carrierService, IUserDialogService dialogService)
        {
            _carrierService = carrierService;
            _dialogService = dialogService;
            Carriers = new ObservableCollection<CarrierModel>();
            UpdateCarriers();
        }

        private void UpdateCarriers()
        {
            Carriers.Clear();
            var carriers = _carrierService.GetAllCarriers();
            foreach (var carrier in carriers)
            {
                Carriers.Add(carrier); 
            }
        }

        private ICommand _addCarrier;
        private ICommand _editCarrier;
        private ICommand _deleteCarrier;

        public ICommand AddCarrier => _addCarrier ??= new RelayCommand(OnAddCarrierCommandExecute, o => true);

        public ICommand EditCarrier =>
            _editCarrier ??= new RelayCommand(OnEditCarrierCommandExecute, IsCarrierSelected);

        public ICommand DeleteCarrier =>
            _deleteCarrier ??= new RelayCommand(OnDeleteCarrierCommandExecute, IsCarrierSelected);

        private void OnDeleteCarrierCommandExecute(object c)
        {
            Carriers.Remove(c as CarrierModel);
            _carrierService.RemoveCarrier(((CarrierModel)c).Id);
        }

        private bool IsCarrierSelected(object obj) => _selectedCarrier != null;

        private void OnEditCarrierCommandExecute(object c)
        {
            _dialogService.Edit(c);
            UpdateCarriers(); 
        }

        private void OnAddCarrierCommandExecute(object obj)
        {
            _dialogService.Add(new CarrierModel());
            UpdateCarriers();
        }
    }
}