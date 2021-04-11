using System;
using System.Linq;
using System.Windows;
using Entities;
using Model;
using Services.Abstract;
using WpfApp3.ViewModels;
using WpfApp3.Views;

namespace WpfApp3.Services
{
    public class WindowsUserDialogService : IUserDialogService
    {
        private readonly IRouteService _routeService;
        private readonly IFlightService _flightService;
        private readonly IAirplaneService _airplaneService;
        private readonly IAirportService _airportService;
        private readonly IPassengerService _passengerService;
        private readonly ITicketService _ticketService;
        public WindowsUserDialogService(IRouteService routeService, IFlightService flightService, IAirplaneService airplaneService, IAirportService airportService, IPassengerService passengerService, ITicketService ticketService)
        {
            _routeService = routeService;
            _flightService = flightService;
            _airplaneService = airplaneService;
            _airportService = airportService;
            _passengerService = passengerService;
            _ticketService = ticketService;
        }

        public bool Add(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case FlightModel flight:
                    return AddFlight(flight);
                case RouteModel route:
                    return AddRoute(route);
                case AirplaneModel airplane:
                    return AddAirplane(airplane);
                case AirportModel airport:
                    return AddAirport(airport);
                case PassengerModel passenger:
                    return AddPassenger(passenger);
                case TicketModel ticket:
                    return AddTicket(ticket);
                default:
                    throw new NotSupportedException($"Adding the object of type {item.GetType().Name} is not supported ");
            }
        }
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case FlightModel flight:
                    return EditFlight(flight);
                case RouteModel route:
                    return EditRoute(route);
                case AirplaneModel airplane:
                    return EditAirplane(airplane);
                case AirportModel airport:
                    return EditAirport(airport);
                case PassengerModel passenger:
                    return EditPassenger(passenger);
                case TicketModel ticket:
                    return EditTicket(ticket);
                default:
                    throw new NotSupportedException($"Editing the object of type {item.GetType().Name} is not supported ");
            }
        }

        public void ShowInformation(string information, string caption) => MessageBox.Show(information, caption,
            MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string message, string caption) =>
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void ShowError(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public bool Confirm(string message, string caption, bool exclamation = false)
        {
            var b = MessageBox.Show(message, caption, MessageBoxButton.YesNo,
                exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question);
            return b == MessageBoxResult.Yes;
        }

        private bool EditFlight(FlightModel flight)
        {
            var editWindow = new EditFlightWindow();
            var ctx =  (EditFlightViewModel) editWindow.DataContext;
            var flightCopy = new FlightModel();
            CopyFields(flight, flightCopy);
            ctx.Flight = flightCopy;
            ctx.Routes = _routeService.GetAllRoutes();
            flightCopy.RouteModel = ctx.Routes.Single(r => r.Id == flightCopy.RouteModel.Id);
            if (editWindow.ShowDialog() != true)
            {
                return false;
            }
            CopyFields(flightCopy, flight);
            _flightService.EditFlight(flight); 
            return true;
        }

        private bool EditRoute(RouteModel route)
        {
            var editWindow = new EditRouteWindow();
            var ctx = (EditRouteViewModel) editWindow.DataContext;
            var routeCopy = new RouteModel();
            CopyFields(route, routeCopy);
            ctx.Route = routeCopy;
            ctx.Airports = _airportService.GetAllAirports();
            ctx.Airplanes = _airplaneService.GetAllAirplanes();
            routeCopy.AirportDepart = ctx.Airports.Single(a => a.Id == routeCopy.AirportDepart.Id);
            routeCopy.AirportArrive = ctx.Airports.Single(a => a.Id == routeCopy.AirportArrive.Id);
            routeCopy.Airplane = ctx.Airplanes.Single(a => a.Id == routeCopy.Airplane.Id);
            if (editWindow.ShowDialog() != true) return false;
            CopyFields(routeCopy, route);
            _routeService.EditRoute(route);
            return true;
        }

        private bool EditAirplane(AirplaneModel airplane)
        {
            var editWindow = new EditAirplaneWindow();
            var ctx = (EditAirplaneViewModel) editWindow.DataContext;
            var airplaneCopy = new AirplaneModel();
            CopyFields(airplane, airplaneCopy);
            ctx.Airplane = airplaneCopy;
            if (editWindow.ShowDialog() != true) return false;
            CopyFields(airplaneCopy, airplane);
            _airplaneService.EditAirplane(airplane);
            return true;
        }

        private bool EditAirport(AirportModel airport)
        {
             var editWindow = new EditAirportWindow();
             var ctx = (EditAirportViewModel) editWindow.DataContext;
             var airportCopy = new AirportModel();
             CopyFields(airport, airportCopy);
             ctx.Airport = airportCopy;
             if (editWindow.ShowDialog() != true) return false;
             CopyFields(airportCopy, airport);
             _airportService.EditAirport(airport);
             return true;           
        }

        private bool EditPassenger(PassengerModel passenger)
        {
              var editWindow = new EditPassengerWindow();
              var ctx = (EditPassengerViewModel) editWindow.DataContext;
              var passengerCopy = new PassengerModel();
              CopyFields(passenger, passengerCopy);
              ctx.Passenger = passengerCopy;
              if (editWindow.ShowDialog() != true) return false;
              CopyFields(passengerCopy, passenger);
              _passengerService.EditPassenger(passenger);
              return true;                      
        }

        private bool EditTicket(TicketModel ticket)
        {
               var editWindow = new EditTicketWindow();
               var ctx = (EditTicketViewModel) editWindow.DataContext;
               var ticketCopy = new TicketModel();
               CopyFields(ticket, ticketCopy);
               ctx.Ticket = ticketCopy;
               ctx.Flights = _flightService.GetAllFlights();
               ctx.Passengers = _passengerService.GetAllPassengers();
               ticketCopy.Flight = ctx.Flights.Single(f => f.Id == ticketCopy.Flight.Id);
               ticketCopy.Passenger = ctx.Passengers.Single(p => p.Id == ticketCopy.Passenger.Id);
               if (editWindow.ShowDialog() != true) return false;
               CopyFields(ticketCopy, ticket);
               _ticketService.EditTicket(ticket);
               return true;                                 
        }
        private bool AddFlight(FlightModel flightModel)
        {
            var editWindow = new EditFlightWindow();
            var ctx =  (EditFlightViewModel) editWindow.DataContext;
            ctx.Flight = flightModel;
            ctx.Routes = _routeService.GetAllRoutes();
            if (editWindow.ShowDialog() != true)
            {
                return false;
            }
            _flightService.AddFlight(flightModel); 
            return true;
        }

        private bool AddAirplane(AirplaneModel airplaneModel)
        {
             var editWindow = new EditAirplaneWindow();
             var ctx =  (EditAirplaneViewModel) editWindow.DataContext;
             ctx.Airplane = airplaneModel;
             if (editWindow.ShowDialog() != true)
             {
                 return false;
             }
             _airplaneService.AddAirplane(airplaneModel);
             return true;           
        }

        private bool AddAirport(AirportModel airportModel)
        {
              var editWindow = new EditAirportWindow();
              var ctx =  (EditAirportViewModel) editWindow.DataContext;
              ctx.Airport = airportModel;
              if (editWindow.ShowDialog() != true)
              {
                  return false;
              }
              _airportService.AddAirport(airportModel);
              return true;                      
        }

        private bool AddPassenger(PassengerModel passengerModel)
        {
               var editWindow = new EditPassengerWindow();
               var ctx =  (EditPassengerViewModel) editWindow.DataContext;
               ctx.Passenger = passengerModel;
               if (editWindow.ShowDialog() != true)
               {
                   return false;
               }
               _passengerService.AddPassenger(passengerModel);
               return true;                                 
        }

        private bool AddTicket(TicketModel ticketModel)
        {
            var editWindow = new EditTicketWindow();
            var ctx =  (EditTicketViewModel) editWindow.DataContext;
            ctx.Ticket = ticketModel;
            ctx.Flights = _flightService.GetAllFlights();
            ctx.Passengers = _passengerService.GetAllPassengers();
            if (editWindow.ShowDialog() != true)
            {
                return false;
            }
            _ticketService.AddTicket(ticketModel);
            return true;                                            
        }

        private bool AddRoute(RouteModel routeModel)
        {
            var editWindow = new EditRouteWindow();
            var ctx = (EditRouteViewModel) editWindow.DataContext;
            ctx.Route = routeModel;
            ctx.Airports = _airportService.GetAllAirports();
            ctx.Airplanes = _airplaneService.GetAllAirplanes();
            if (editWindow.ShowDialog() != true) return false;
            _routeService.AddRoute(routeModel);
            return true;
        }
        
        // private void CopyFlightFields(FlightModel src, FlightModel dest)
        // {
        //     dest.Id = src.Id;
        //     dest.TimeDepart = src.TimeDepart;
        //     dest.TimeArrive = src.TimeArrive;
        //     dest.StopBooking = src.StopBooking;
        //     dest.SeatsAvailable = src.SeatsAvailable;
        //     dest.RouteModel = src.RouteModel;
        //     dest.MinDelayed = src.MinDelayed;
        //     dest.Tickets = src.Tickets;
        // }

        private void CopyFields(object src, object dest)
        {
            var srcProperties = src.GetType().GetProperties();
            var destProperties = dest.GetType().GetProperties();
            foreach (var srcProp in srcProperties)
            {
                foreach (var destProp in destProperties)
                {
                    if (srcProp.Name == destProp.Name && srcProp.GetType() == destProp.GetType())
                    {
                        destProp.SetValue(dest, srcProp.GetValue(src));
                        break;
                    } 
                } 
            }
        }

        // private void CopyRouteFields(RouteModel src, RouteModel dest)
        // {
        //     
        // }
    }
}
