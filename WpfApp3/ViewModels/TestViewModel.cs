using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Data.Repositories;
using Model;
using Model.Annotations;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels
{
    public class ChosenFlightViewModel : BaseViewModel
    {

        public ObservableCollection<PassengerModel> Passengers { get; }
        // private FlightModel flight;
        private string _title = "This is cool";
        private PassengerModel _selectedPassenger;

        public ChosenFlightViewModel()
        {
            var passengers = Enumerable.Range(1, 50).Select(i => new PassengerModel
            {
                Age = 18,
                Name = "Passengeer" + i,
                Tickets = Enumerable.Range(1,30).Select(t => new TicketModel
                {
                    Adults = 2,
                    Children = 3,
                    Price = 700
                })
            });
            Passengers = new ObservableCollection<PassengerModel>(passengers);
        }
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public PassengerModel SelectedPassenger
        {
            get => _selectedPassenger;
            set => Set(ref _selectedPassenger, value);
        }

        // public FlightModel Flight
        // {
        //     get => flight;
        //     set
        //     {
        //         flight = value;
        //         OnPropertyChanged("Flight");
        //     }
        // }

    }
}