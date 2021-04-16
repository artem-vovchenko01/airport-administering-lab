using Microsoft.Extensions.DependencyInjection;

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
        public OverviewViewModel OverviewViewModel => App.ServiceProvider.GetService<OverviewViewModel>();

        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetService<MainWindowViewModel>();
    }
}
