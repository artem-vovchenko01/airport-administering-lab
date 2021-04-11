using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using WpfApp3.Services;
using WpfApp3.ViewModels;

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
            
            
            serviceCollection.AddSingleton<IFlightService, FlightService>();
            serviceCollection.AddSingleton<IPassengerService, PassengerService>();
            serviceCollection.AddSingleton<ITicketService, TicketService>();
            serviceCollection.AddSingleton<IRouteService, RouteService>();
            serviceCollection.AddSingleton<IAirplaneService, AirplaneService>();
            serviceCollection.AddSingleton<IAirportService, AirportService>();

            serviceCollection.AddTransient<IUserDialogService, WindowsUserDialogService>();
            
            serviceCollection.AddTransient<MainWindowViewModel>();
            serviceCollection.AddTransient<ChosenFlightViewModel>();
            serviceCollection.AddTransient<OverviewViewModel>();
            serviceCollection.AddTransient<EditAirplaneViewModel>();
            serviceCollection.AddTransient<EditAirportViewModel>();
            serviceCollection.AddTransient<EditFlightViewModel>();
            serviceCollection.AddTransient<EditRouteViewModel>();
            serviceCollection.AddTransient<EditPassengerViewModel>();
            serviceCollection.AddTransient<EditTicketViewModel>();
            
            serviceCollection.AddTransient<ShowAllFlightsViewModel>();
            serviceCollection.AddTransient<ShowAllRoutesViewModel>();
            serviceCollection.AddTransient<ShowAllAirportsViewModel>();
            serviceCollection.AddTransient<ShowAllAirplanesViewModel>();
            serviceCollection.AddTransient<ShowAllPassengersViewModel>();
            serviceCollection.AddTransient<ShowAllTicketsViewModel>();




            // serviceCollection.AddTransient(typeof(IUserDialogService),
            //     sp => new WindowsUserDialogService(sp.GetRequiredService<IRouteService>(), sp.GetRequiredService<IFlightService>(), sp.GetRequiredService<IAirplaneService>(), sp.GetRequiredService<IAirportService>(), sp.GetRequiredService<PassengerService>(), sp.GetRequiredService<TicketService>()));
            //
            // serviceCollection.AddTransient<ChosenFlightViewModel>();
            // serviceCollection.AddTransient<OverviewViewModel>();
            //
            // serviceCollection.AddTransient(sp => new ShowAllRoutesViewModel(sp.GetRequiredService<IRouteService>(),
            //     sp.GetRequiredService<IUserDialogService>()));
            //
            // serviceCollection.AddTransient(sp =>
            //     new ShowAllFlightsViewModel(sp.GetRequiredService<IFlightService>(), sp.GetRequiredService<IUserDialogService>()));
            //
            // serviceCollection.AddTransient(sp => new ShowAllAirportsViewModel(sp.GetRequiredService<IAirportService>(),
            //     sp.GetRequiredService<IUserDialogService>()));
            //
            // serviceCollection.AddTransient(sp =>
            //     new ShowAllAirplanesViewModel(sp.GetRequiredService<IAirplaneService>(),
            //         sp.GetRequiredService<IUserDialogService>()));
            //
            // serviceCollection.AddTransient(sp =>
            //     new ShowAllPassengersViewModel(sp.GetRequiredService<IPassengerService>(),
            //         sp.GetRequiredService<IUserDialogService>()));
            //
            // serviceCollection.AddTransient(sp =>
            //     new MainWindowViewModel(sp.GetRequiredService<ShowAllFlightsViewModel>(), sp.GetRequiredService<OverviewViewModel>(), sp.GetRequiredService<ShowAllRoutesViewModel>(), sp.GetRequiredService<ShowAllAirplanesViewModel>(), sp.GetRequiredService<ShowAllAirportsViewModel>(), sp.GetRequiredService<ShowAllPassengersViewModel>(), sp.GetRequiredService<ShowAllTicketsViewModel>()));
        }

        // private void _testDb(IUnitOfWork uof)
        // {
        //     uof.Airports.Add(new Airport {City = "London", Country = "England", Name = "Heathrow"});
        //     uof.Airports.Add(new Airport{City = "Paris", Country = "France", Name = "Parisio"});
        //     uof.Airplanes.Add(new Airplane{ Company = "Boeing", Model = "TU48548", Seats = 400, DefaultPrice = 300});
        //     uof.Passengers.Add(new Passenger{ Age = 18, Name = "ARtem", Passport = 8548549, Surname = "Vovchenko"});
        //     uof.Complete();
        //     
        //     var airplane = uof.Airplanes.GetAll().ToList()[0];
        //     var airport1 = uof.Airports.GetAll().ToList()[0];
        //     var airport2 = uof.Airports.GetAll().ToList()[1];
        //     
        //     uof.Routes.Add(new Route{AirplaneId = airplane.Id, Carrier = "Turkish airlines", Code = "MXV48", AirportArriveId = airport1.Id, AirportDepartId = airport2.Id});
        //     uof.Complete();
        //     
        //     var route = uof.Routes.GetAll().ToList()[0];
        //     
        //     uof.Flights.Add(new Flight {MinDelayed = 0, TimeArrive = new DateTime(2015,4,13), StopBooking = new DateTime(2020,10,10), TimeDepart = new DateTime(2020,10,3), RouteId = route.Id});
        //     uof.Complete();
        //     
        //     var flight = uof.Flights.GetAll().ToList()[0];
        //     var passenger = uof.Passengers.GetAll().ToList()[0];
        //     
        //     uof.Tickets.Add(new Ticket {Adults = 2, Children = 3, FlightId = flight.Id, Price = 500, PassengerId = passenger.Id});
        //     uof.Complete();
        //     
        //     var ticket = uof.Tickets.GetAll().ToList()[0];
        //     
        //     uof.Seats.Add(new Seat {SeatNumber = 1, TicketId = ticket.Id});
        //     uof.Complete();
            
            // uof.Airplanes.Remove(airplane);
            // uof.Tickets.Remove(ticket);
            //
            // passenger.Name = "ARTEM";
            // ((PassengerRepository) uof.Passengers).Context.Update(passenger);
            // ((PassengerRepository) uof.Passengers).Context.Entry(passenger).State = EntityState.Modified;
            // Console.WriteLine(passenger.Id + " " + passenger.Name); 
            // uof.Passengers.Update(passenger);
            
            // uof.Complete();
        // }
    }
}
