using System;
using System.Collections.Generic;

namespace Model
{
    public class PassengerModel : AbstractModel
    {
        private string _name;
        private string _surname;
        private long _passport;
        private int _age;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public long Passport
        {
            get => _passport;
            set => Set(ref _passport, value);
        }

        public int Age
        {
            get => _age;
            set => Set(ref _age, value);
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
                    case nameof(Surname):
                        if (string.IsNullOrWhiteSpace(Surname))
                            error = "Blank value not allowed for the field" + nameof(Surname);
                        break;
                    case nameof(Passport):
                        if (Passport < 100_000_000 || Passport > 999_999_999)
                            error = "Valid passport value should be of length 9";
                        break;
                    case nameof(Age):
                        int minAge = 16;
                        int maxAge = 140;
                        if (Age < minAge || Age > maxAge)
                            error = nameof(Age) + "Allowed values for age: " + minAge + " to " + maxAge;
                        break;
                }

                return error;
            }
        }

        public IEnumerable<TicketModel> Tickets { get; set; }
    }
}