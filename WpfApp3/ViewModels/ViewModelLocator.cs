using Microsoft.Extensions.DependencyInjection;

namespace WpfApp3.ViewModels
{
    public class ViewModelLocator
    {
        public ShowAllFlightsViewModel ShowAllFlightsViewModel => App.ServiceProvider.GetService<ShowAllFlightsViewModel>();

        public ShowAllRoutesViewModel ShowAllRoutesViewModel =>
            App.ServiceProvider.GetService<ShowAllRoutesViewModel>();
        public OverviewViewModel OverviewViewModel => App.ServiceProvider.GetService<OverviewViewModel>();

        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetService<ViewModels.MainWindowViewModel>();
    }
}
