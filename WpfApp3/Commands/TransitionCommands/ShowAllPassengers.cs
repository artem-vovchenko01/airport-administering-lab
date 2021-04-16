using WpfApp3.ViewModels;

namespace WpfApp3.Commands.TransitionCommands
{
    public class ShowAllPassengers : BaseCommand
    {
        private readonly ViewModelLocator _locator;

        public ShowAllPassengers()
        {
            _locator = App.Current.TryFindResource("ViewModelLocator") as ViewModelLocator;
        }
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            MainWindowViewModel.CurrentInstance.ShowAllPassengers();
        }
    }
}