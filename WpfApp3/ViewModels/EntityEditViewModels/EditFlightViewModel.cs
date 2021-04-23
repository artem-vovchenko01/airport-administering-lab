using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Model;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels.EntityEditViewModels
{
    public class EditFlightViewModel : BaseViewModel, IPageViewModel
    {
        private FlightModel _flight;
        private IEnumerable<RouteModel> _routes;
        private ICommand _closeDialog;

        public ICommand CloseDialog => _closeDialog ??=
            new RelayCommand(OnCloseDialogCommandExecute, (param) => _flight.RouteModel != null);

        private void OnCloseDialogCommandExecute(object parameter)
        {
            var window = (Window) parameter;
            window.DialogResult = true;
            window.Close();
        }
        public FlightModel Flight
        {
            get => _flight;
            set => Set(ref _flight, value);
        }

        public IEnumerable<RouteModel> Routes
        {
            get => _routes;
            set => Set(ref _routes, value);
        }
    }
}