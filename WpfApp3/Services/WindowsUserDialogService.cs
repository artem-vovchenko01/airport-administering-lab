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
        public WindowsUserDialogService(IRouteService routeService, IFlightService flightService)
        {
            _routeService = routeService;
            _flightService = flightService;
        }

        public bool Add(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            switch (item)
            {
                case FlightModel flight:
                    return AddFlight(flight);
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
            CopyFlightFields(flight, flightCopy);
            ctx.Flight = flightCopy;
            ctx.Routes = _routeService.GetAllRoutes();
            flightCopy.RouteModel = ctx.Routes.Single(r => r.Id == flightCopy.RouteModel.Id);
            if (editWindow.ShowDialog() != true)
            {
                return false;
            }
            CopyFlightFields(flightCopy, flight);
            _flightService.EditFlight(flight); 
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
        
        private void CopyFlightFields(FlightModel src, FlightModel dest)
        {
            dest.Id = src.Id;
            dest.TimeDepart = src.TimeDepart;
            dest.TimeArrive = src.TimeArrive;
            dest.StopBooking = src.StopBooking;
            dest.SeatsAvailable = src.SeatsAvailable;
            dest.RouteModel = src.RouteModel;
            dest.MinDelayed = src.MinDelayed;
            dest.Tickets = src.Tickets;
        }
    }
}
