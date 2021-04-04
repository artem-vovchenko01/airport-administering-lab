using System.Collections.ObjectModel;
using Model;
using Services.Abstract;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class ShowAllRoutesViewModel : BaseViewModel, IPageViewModel
    {
        private RouteModel _selectedRoute;
        private readonly IRouteService _routeService;
        private readonly IUserDialogService _dialogService;
        
        public ObservableCollection<RouteModel> Routes { get; set; }

        public RouteModel SelectedRoute
        {
            get => _selectedRoute;
            set => Set(ref _selectedRoute, value);
        }

        public object ShowOverview
        {
            get { throw new System.NotImplementedException(); }
        }

        public ShowAllRoutesViewModel(IRouteService routeService, IUserDialogService dialogService)
        {
            _routeService = routeService;
            _dialogService = dialogService;
            Routes = new ObservableCollection<RouteModel>(_routeService.GetAllRoutes());
        }
        
    }
}