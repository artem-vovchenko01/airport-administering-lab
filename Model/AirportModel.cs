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

        public override string this[string columnName]
        {
            get
            {
                var error = string.Empty;

                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            error = "Blank value not allowed for the field" + nameof(Name);
                        break;
                    case nameof(City):
                        if (string.IsNullOrWhiteSpace(City))
                            error = "Blank value not allowed for the field" + nameof(City);
                        break;
                    case nameof(Country):
                        if (string.IsNullOrWhiteSpace(Country))
                            error = "Blank value not allowed for the field" + nameof(Country);
                        break;
                }

                return error;
            }
        }
    }
}