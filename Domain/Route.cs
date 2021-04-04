using System;

namespace Domain
{
    public class Route
    {
        public Guid Id { get; set; }
        public string Carrier { get; set; }
        public string Code { get; set;}
        public Guid AirportDepartId { get; set; }
        public Guid AirportArriveId { get; set; }
        public Guid AirplaneId { get; set; }
    }
}
