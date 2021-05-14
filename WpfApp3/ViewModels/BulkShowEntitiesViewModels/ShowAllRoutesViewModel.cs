using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Services.Abstract;
using WpfApp3.Commands;
using WpfApp3.Services;

namespace WpfApp3.ViewModels.BulkShowEntitiesViewModels
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


        private void UpdateRoutes()
        {
            Routes.Clear();
            var routes = _routeService.GetAllRoutes();
            foreach (var route in routes)
            {
                Routes.Add(route); 
            }
        }
        
        private ICommand _addRoute;
        private ICommand _editRoute;
        private ICommand _deleteRoute;
        public ICommand AddRoute => _addRoute ??= new RelayCommand(OnAddRouteCommandExecute, (obj) => true);
        public ICommand EditRoute => _editRoute ??= new RelayCommand(OnEditRouteCommandExecute, IsRouteSelected);
        public ICommand DeleteRoute => _deleteRoute ??= new RelayCommand(OnDeleteRouteCommandExecute, IsRouteSelected);
        private bool IsRouteSelected(object r) => SelectedRoute != null;

        private void OnAddRouteCommandExecute(object r)
        {
            _dialogService.Add(new RouteModel());
            UpdateRoutes();
        }

        private void OnEditRouteCommandExecute(object r)
        {
            _dialogService.Edit(r);
            UpdateRoutes();
        }

        private void OnDeleteRouteCommandExecute(object r)
        {
            Routes.Remove(r as RouteModel);
            _routeService.RemoveRoute(((RouteModel)r).Id);
        }

        public ShowAllRoutesViewModel(IRouteService routeService, IUserDialogService dialogService)
        {
            _routeService = routeService;
            _dialogService = dialogService;
            Routes = new ObservableCollection<RouteModel>();
            UpdateRoutes();
        }
        
    }
}