using System.Collections;
using System.Collections.Generic;
using Entities;
using Model;

namespace WpfApp3.ViewModels
{
    public class EditRouteViewModel : BaseViewModel, IPageViewModel
    {
        private RouteModel _route;
        private IEnumerable<AirportModel> _airports;
        private IEnumerable<AirplaneModel> _airplanes;
        private AirportModel _selectedAirportDepart;
        private AirportModel _selectedAirportArrive;
        private Airplane _selectedAirplane;

        public RouteModel Route
        {
            get => _route;
            set => Set(ref _route, value);
        }

        public IEnumerable<AirportModel> Airports
        {
            get => _airports;
            set => Set(ref _airports, value);
        }

        public IEnumerable<AirplaneModel> Airplanes
        {
            get => _airplanes;
            set => Set(ref _airplanes, value);
        }

        public AirportModel SelectedAirportDepart
        {
            get => _selectedAirportDepart;
            set => Set(ref _selectedAirportDepart, value);
        }

        public AirportModel SelectedAirportArrive
        {
            get => _selectedAirportArrive;
            set => Set(ref _selectedAirportArrive, value);
        }

        public Airplane SelectedAirplane
        {
            get => _selectedAirplane;
            set => Set(ref _selectedAirplane, value);
        }
    }
}
