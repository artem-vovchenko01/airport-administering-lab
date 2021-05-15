using System.Windows;
using Data;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using WpfApp3.Services;
using WpfApp3.ViewModels;
using WpfApp3.ViewModels.BulkShowEntitiesViewModels;
using WpfApp3.ViewModels.EntityEditViewModels;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            TestServices();
        }

        private void TestServices()
        {
            ServiceProvider.GetService<MyDbContext>();
            ServiceProvider.GetService<IUnitOfWork>();
            
            ServiceProvider.GetService<IFlightService>();
            ServiceProvider.GetService<IPassengerService>();
            ServiceProvider.GetService<ITicketService>();
            ServiceProvider.GetService<IRouteService>();
            ServiceProvider.GetService<IAirplaneService>();
            ServiceProvider.GetService<IAirportService>();
            ServiceProvider.GetService<ICarrierService>();

            ServiceProvider.GetService<IUserDialogService>();
            
            ServiceProvider.GetService<MainWindowViewModel>();
            ServiceProvider.GetService<OverviewViewModel>();
            ServiceProvider.GetService<EditAirplaneViewModel>();
            ServiceProvider.GetService<EditAirportViewModel>();
            ServiceProvider.GetService<EditFlightViewModel>();
            ServiceProvider.GetService<EditRouteViewModel>();
            ServiceProvider.GetService<EditPassengerViewModel>();
            ServiceProvider.GetService<EditTicketViewModel>();
            ServiceProvider.GetService<ChooseSeatsViewModel>();
            ServiceProvider.GetService<EditTicketViewModel>();
            ServiceProvider.GetService<EditCarrierViewModel>();
           
            ServiceProvider.GetService<ShowAllFlightsViewModel>();
            ServiceProvider.GetService<ShowAllRoutesViewModel>();
            ServiceProvider.GetService<ShowAllAirportsViewModel>();
            ServiceProvider.GetService<ShowAllAirplanesViewModel>();
            ServiceProvider.GetService<ShowAllPassengersViewModel>();
            ServiceProvider.GetService<ShowAllTicketsViewModel>();
            ServiceProvider.GetService<ShowAllCarriersViewModel>();

            ServiceProvider.GetService<SelectFlightViewModel>();
            ServiceProvider.GetService<SelectFlightViewModel>();
            ServiceProvider.GetService<TicketsByFlightViewModel>();
        }
        
        private void OnStartup(object sender, StartupEventArgs args)
        {
            var appWindow = ServiceProvider.GetService<MainWindow>();
            appWindow.Show();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddDbContext<MyDbContext>();
            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddSingleton(sp => sp);
            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddSingleton<IAirplaneRepository, AirplaneRepository>();
            serviceCollection.AddSingleton<IAirportRepository, AirportRepository>();
            serviceCollection.AddSingleton<IFlightRepository, FlightRepository>();
            serviceCollection.AddSingleton<IPassengerRepository, PassengerRepository>();
            serviceCollection.AddSingleton<IRouteRepository, RouteRepository>();
            serviceCollection.AddSingleton<ITicketRepository, TicketRepository>();
            serviceCollection.AddSingleton<ISeatRepository, SeatRepository>();
            serviceCollection.AddSingleton<ICarrierRepository, CarrierRepository>();
            
            serviceCollection.AddSingleton<IFlightService, FlightService>();
            serviceCollection.AddSingleton<IPassengerService, PassengerService>();
            serviceCollection.AddSingleton<ITicketService, TicketService>();
            serviceCollection.AddSingleton<IRouteService, RouteService>();
            serviceCollection.AddSingleton<IAirplaneService, AirplaneService>();
            serviceCollection.AddSingleton<IAirportService, AirportService>();
            serviceCollection.AddSingleton<ICarrierService, CarrierService>();

            serviceCollection.AddTransient<IUserDialogService, WindowsUserDialogService>();
            
            serviceCollection.AddTransient<MainWindowViewModel>();
            serviceCollection.AddTransient<OverviewViewModel>();
            serviceCollection.AddTransient<EditAirplaneViewModel>();
            serviceCollection.AddTransient<EditAirportViewModel>();
            serviceCollection.AddTransient<EditFlightViewModel>();
            serviceCollection.AddTransient<EditRouteViewModel>();
            serviceCollection.AddTransient<EditPassengerViewModel>();
            serviceCollection.AddTransient<EditTicketViewModel>();
            serviceCollection.AddTransient<ChooseSeatsViewModel>();
            serviceCollection.AddSingleton<EditTicketViewModel>();
            serviceCollection.AddSingleton<EditCarrierViewModel>();
            
            serviceCollection.AddTransient<ShowAllFlightsViewModel>();
            serviceCollection.AddTransient<ShowAllRoutesViewModel>();
            serviceCollection.AddTransient<ShowAllAirportsViewModel>();
            serviceCollection.AddTransient<ShowAllAirplanesViewModel>();
            serviceCollection.AddTransient<ShowAllPassengersViewModel>();
            serviceCollection.AddTransient<ShowAllTicketsViewModel>();
            serviceCollection.AddTransient<ShowAllCarriersViewModel>();

            serviceCollection.AddTransient<SelectFlightViewModel>();
            serviceCollection.AddTransient<SelectFlightViewModel>();
            serviceCollection.AddSingleton<TicketsByFlightViewModel>();
        }

    }
}
