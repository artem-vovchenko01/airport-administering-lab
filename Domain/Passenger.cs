using System;

namespace Domain
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string Name {get; set;}
        public string Surname {get; set; }
        public long Passport {get; set; }
        public int Age {get; set; }
    }
}
