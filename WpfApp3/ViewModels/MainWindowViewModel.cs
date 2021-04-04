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

        public MainWindowViewModel(ShowAllFlightsViewModel showAllFlightsViewModel, OverviewViewModel overviewViewModel, ShowAllRoutesViewModel showAllRoutesViewModel)
        {
            PageViewModels.Add(overviewViewModel);
            PageViewModels.Add(showAllFlightsViewModel);
            PageViewModels.Add(showAllRoutesViewModel);
            CurrentPageViewModel = PageViewModels[0]; 
            Mediator.Subscribe("ShowAllFlights", ShowAllFlights);
            Mediator.Subscribe("ShowOverview", ShowOverview);
            Mediator.Subscribe("ShowAllRoutes", ShowAllRoutes);
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

        private void ShowAllRoutes(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }
        private void ShowAllFlights(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
        
        private void ShowOverview(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);         
        }
    }
}