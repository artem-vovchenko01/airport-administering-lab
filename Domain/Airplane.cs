using System;

namespace Domain
{
    public class Airplane
    {
        public Guid Id { get; set; }
        public string Company {get; set; }
        public string Model {get; set; }
        public int Seats {get; set; }
        public int DefaultPrice {get; set; }
    }
}