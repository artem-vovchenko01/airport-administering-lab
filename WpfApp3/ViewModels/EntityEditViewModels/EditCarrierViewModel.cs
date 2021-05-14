using Model;

namespace WpfApp3.ViewModels.EntityEditViewModels
{
    public class EditCarrierViewModel : BaseViewModel, IPageViewModel
    {
        private CarrierModel _carrier;

        public CarrierModel Carrier
        {
            get => _carrier;
            set => Set(ref _carrier, value);
        }
    }
}