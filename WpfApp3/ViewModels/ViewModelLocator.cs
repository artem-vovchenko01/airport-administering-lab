using Microsoft.Extensions.DependencyInjection;
using WpfApp3.ViewModels.BulkShowEntitiesViewModels;
using WpfApp3.ViewModels.EntityEditViewModels;

namespace WpfApp3.ViewModels
{
    public class ViewModelLocator
    {
        public ShowAllFlightsViewModel ShowAllFlightsViewModel => App.ServiceProvider.GetService<ShowAllFlightsViewModel>();

        public ShowAllRoutesViewModel ShowAllRoutesViewModel =>
            App.ServiceProvider.GetService<ShowAllRoutesViewModel>();

        public ShowAllAirplanesViewModel ShowAllAirplanesViewModel =>
            App.ServiceProvider.GetService<ShowAllAirplanesViewModel>();

        public ShowAllAirportsViewModel ShowAllAirportsViewModel =>
            App.ServiceProvider.GetService<ShowAllAirportsViewModel>();

        public ShowAllTicketsViewModel ShowAllTicketsViewModel =>
            App.ServiceProvider.GetService<ShowAllTicketsViewModel>();

        public ShowAllPassengersViewModel ShowAllPassengersViewModel =>
            App.ServiceProvider.GetService<ShowAllPassengersViewModel>();

        public ShowAllCarriersViewModel ShowAllCarriersViewModel =>
            App.ServiceProvider.GetService<ShowAllCarriersViewModel>();
        public OverviewViewModel OverviewViewModel => App.ServiceProvider.GetService<OverviewViewModel>();

        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetService<MainWindowViewModel>();
        public SelectFlightViewModel SelectFlightViewModel => App.ServiceProvider.GetService<SelectFlightViewModel>();

        public TicketsByFlightViewModel TicketsByFlightViewModel =>
            App.ServiceProvider.GetService<TicketsByFlightViewModel>();

        public ChooseSeatsViewModel ChooseSeatsViewModel => App.ServiceProvider.GetService<ChooseSeatsViewModel>();

        public EditTicketViewModel EditTicketViewModel => App.ServiceProvider.GetService<EditTicketViewModel>();
    }
}
