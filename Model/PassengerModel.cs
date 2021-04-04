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
        public IEnumerable<TicketModel> Tickets { get; set; }
    }
}
