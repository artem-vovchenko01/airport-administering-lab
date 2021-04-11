using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Model;

namespace Services.Abstract
{
    public interface IAirplaneService
    {
        void AddAirplane(AirplaneModel airplane);
        void EditAirplane(AirplaneModel airplane);
        void RemoveAirplane(Guid airplaneId);
        IEnumerable<AirplaneModel> GetAllAirplanes();
    }
}
