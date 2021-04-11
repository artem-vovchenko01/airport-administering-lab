﻿using Model;

namespace WpfApp3.ViewModels
{
    public class EditPassengerViewModel : BaseViewModel, IPageViewModel
    {
        private PassengerModel _passenger;

        public PassengerModel Passenger
        {
            get => _passenger;
            set => Set(ref _passenger, value);
        }
    }
}