using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories;
using WpfApp3.Commands.TransitionCommands;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;

        public static MainWindowViewModel CurrentInstance { get; set; }
        private readonly OverviewViewModel _overviewViewModel;
        private readonly ShowAllFlightsViewModel _showAllFlightsViewModel;
        private readonly ShowAllRoutesViewModel _showAllRoutesViewModel;
        private readonly ShowAllAirplanesViewModel _showAllAirplanesViewModel;
        private readonly ShowAllAirportsViewModel _showAllAirportsViewModel;
        private readonly ShowAllPassengersViewModel _showAllPassengersViewModel;
        private readonly ShowAllTicketsViewModel _showAllTicketsViewModel;
        public MainWindowViewModel(ShowAllFlightsViewModel showAllFlightsViewModel, OverviewViewModel overviewViewModel, ShowAllRoutesViewModel showAllRoutesViewModel, ShowAllAirplanesViewModel showAllAirplanesViewModel, ShowAllAirportsViewModel showAllAirportsViewModel, ShowAllPassengersViewModel showAllPassengersViewModel, ShowAllTicketsViewModel showAllTicketsViewModel)
        {
            CurrentInstance = this;
            _overviewViewModel = overviewViewModel;
            _showAllAirplanesViewModel = showAllAirplanesViewModel;
            _showAllAirportsViewModel = showAllAirportsViewModel;
            _showAllFlightsViewModel = showAllFlightsViewModel;
            _showAllPassengersViewModel = showAllPassengersViewModel;
            _showAllRoutesViewModel = showAllRoutesViewModel;
            _showAllTicketsViewModel = showAllTicketsViewModel;

            _currentPageViewModel = overviewViewModel;
            // PageViewModels.Add(overviewViewModel);
            // PageViewModels.Add(showAllFlightsViewModel);
            // PageViewModels.Add(showAllRoutesViewModel);
            // PageViewModels.Add(showAllAirplanesViewModel);
            // PageViewModels.Add(showAllAirportsViewModel);
            // PageViewModels.Add(showAllPassengersViewModel);
            // PageViewModels.Add(showAllTicketsViewModel);
            // CurrentPageViewModel = PageViewModels[0]; 
            // Mediator.Subscribe("ShowAllFlights", ShowAllFlights);
            // Mediator.Subscribe("ShowOverview", ShowOverview);
            // Mediator.Subscribe("ShowAllRoutes", ShowAllRoutes);
            // Mediator.Subscribe("ShowAllAirplanes", ShowAllAirplanes);
            // Mediator.Subscribe("ShowAllAirports", ShowAllAirports);
            // Mediator.Subscribe("ShowAllPassengers", ShowAllPassengers);
            // Mediator.Subscribe("ShowAllTickets", ShowAllTickets);
        }

        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set => Set(ref _currentPageViewModel, value);
        }

        public void ShowOverview()
        {
            CurrentPageViewModel = _overviewViewModel;
        }
        public void ShowAllFlights()
        {
            CurrentPageViewModel = _showAllFlightsViewModel;
        }
        public void ShowAllRoutes()
        {
            CurrentPageViewModel = _showAllRoutesViewModel;
        }
        public void ShowAllAirplanes()
        {
            CurrentPageViewModel = _showAllAirplanesViewModel;
        }

        public void ShowAllAirports()
        {
            CurrentPageViewModel = _showAllAirportsViewModel;
        }

        public void ShowAllPassengers()
        {
            CurrentPageViewModel = _showAllPassengersViewModel;
        }

        public void ShowAllTickets()
        {
            CurrentPageViewModel = _showAllTicketsViewModel;
        }
    }
}