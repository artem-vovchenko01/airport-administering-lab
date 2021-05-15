using Data.Repositories.Abstract;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        public UnitOfWork(MyDbContext context, IAirplaneRepository airplaneRepository, IAirportRepository airportRepository, IFlightRepository flightRepository, IPassengerRepository passengerRepository, IRouteRepository routeRepository, ITicketRepository ticketRepository, ISeatRepository seatRepository, ICarrierRepository carrierRepository)
        {
            _context = context;
            Airplanes = airplaneRepository;
            Airports = airportRepository;
            Flights = flightRepository;
            Passengers = passengerRepository;
            Routes = routeRepository;
            Tickets = ticketRepository;
            Seats = seatRepository;
            Carriers = carrierRepository;
        }

        public IAirplaneRepository Airplanes { get; }
        public IAirportRepository Airports { get; }
        public IFlightRepository Flights { get; }
        public IPassengerRepository Passengers { get; }
        public IRouteRepository Routes { get; }
        public ITicketRepository Tickets { get; }
        public ISeatRepository Seats { get; }
        public ICarrierRepository Carriers { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}