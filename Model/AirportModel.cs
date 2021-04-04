using System;

namespace Model
{
    public class AirportModel : AbstractModel
    {
        private string _name;
        private string _city;
        private string _country;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }

        public string Country
        {
            get => _country;
            set => Set(ref _country, value);
        }

    }
}