using Model;

namespace WpfApp3.ViewModels.EntityEditViewModels
{
    public class EditAirplaneViewModel : BaseViewModel, IPageViewModel
    {
        private AirplaneModel _airplane;
        
        public AirplaneModel Airplane
        {
            get => _airplane;
            set => Set(ref _airplane, value);
        }
    }
}
