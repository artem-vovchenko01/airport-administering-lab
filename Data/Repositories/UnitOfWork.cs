using Data.Repositories.Abstract;
using Data;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            Airplanes = new AirplaneRepository(context);
            Airports = new AirportRepository(context);
            Flights = new FlightRepository(context);
            Passengers = new PassengerRepository(context);
            Routes = new RouteRepository(context);
            Tickets = new TicketRepository(context);
            Seats = new SeatRepository(context);
            Carriers = new CarrierRepository(context);
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