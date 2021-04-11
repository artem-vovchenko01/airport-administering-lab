using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Model;

namespace Services.Abstract
{
    public interface IAirportService
    {
        void AddAirport(AirportModel airport);
        void RemoveAirport(Guid airportId);
        void EditAirport(AirportModel airport);
        IEnumerable<AirportModel> GetAllAirports();
    }
}
