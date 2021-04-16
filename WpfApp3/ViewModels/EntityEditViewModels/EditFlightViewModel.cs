using System.Collections.Generic;
using Model;

namespace WpfApp3.ViewModels.EntityEditViewModels
{
    public class EditFlightViewModel : BaseViewModel, IPageViewModel
    {
        private FlightModel _flight;
        private IEnumerable<RouteModel> _routes;
        private RouteModel _selectedRoute;

        public FlightModel Flight
        {
            get => _flight;
            set => Set(ref _flight, value);
        }

        public RouteModel SelectedRoute
        {
            get => _selectedRoute;
            set => Set(ref _selectedRoute, value);
        }

        public IEnumerable<RouteModel> Routes
        {
            get => _routes;
            set => Set(ref _routes, value);
        }
    }
}