using System;

namespace Data.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAirplaneRepository Airplanes { get; } 
        IAirportRepository Airports { get; }
        IFlightRepository Flights { get; }
        IPassengerRepository Passengers { get; }
        IRouteRepository Routes { get; }
        ITicketRepository Tickets { get; }
        ISeatRepository Seats { get; }
        ICarrierRepository Carriers { get; }

        int Complete();
    }
}