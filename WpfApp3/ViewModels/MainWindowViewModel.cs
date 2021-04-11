using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repositories;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public MainWindowViewModel(ShowAllFlightsViewModel showAllFlightsViewModel, OverviewViewModel overviewViewModel, ShowAllRoutesViewModel showAllRoutesViewModel, ShowAllAirplanesViewModel showAllAirplanesViewModel, ShowAllAirportsViewModel showAllAirportsViewModel, ShowAllPassengersViewModel showAllPassengersViewModel, ShowAllTicketsViewModel showAllTicketsViewModel)
        {
            PageViewModels.Add(overviewViewModel);
            PageViewModels.Add(showAllFlightsViewModel);
            PageViewModels.Add(showAllRoutesViewModel);
            PageViewModels.Add(showAllAirplanesViewModel);
            PageViewModels.Add(showAllAirportsViewModel);
            PageViewModels.Add(showAllPassengersViewModel);
            PageViewModels.Add(showAllTicketsViewModel);
            CurrentPageViewModel = PageViewModels[0]; 
            Mediator.Subscribe("ShowAllFlights", ShowAllFlights);
            Mediator.Subscribe("ShowOverview", ShowOverview);
            Mediator.Subscribe("ShowAllRoutes", ShowAllRoutes);
            Mediator.Subscribe("ShowAllAirplanes", ShowAllAirplanes);
            Mediator.Subscribe("ShowAllAirports", ShowAllAirports);
            Mediator.Subscribe("ShowAllPassengers", ShowAllPassengers);
            Mediator.Subscribe("ShowAllTickets", ShowAllTickets);
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null) _pageViewModels = new List<IPageViewModel>();
                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set => Set(ref _currentPageViewModel, value);
        }

        private void ShowOverview(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }
        private void ShowAllFlights(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
        private void ShowAllRoutes(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }
        private void ShowAllAirplanes(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void ShowAllAirports(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }

        private void ShowAllPassengers(object obj)
        {
            ChangeViewModel(PageViewModels[5]);
        }

        private void ShowAllTickets(object obj)
        {
            ChangeViewModel(PageViewModels[6]);
        }
        
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);         
        }
    }
}