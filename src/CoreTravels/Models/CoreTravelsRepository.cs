namespace CoreTravels.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class CoreTravelsRepository : ICoreTravelsRepository
    {
        private ICoreTravelsContext _context;

        public CoreTravelsRepository(ICoreTravelsContext context)
        {
            _context = context;
        }

        public void AddStop(int idTrip, Stop stop)
        {
            var trip = GetTripById(idTrip);

            if(trip != null)
            {
                trip.Stops.Add(stop);
                _context.Stops.Add(stop);
                _context.SaveChanges();
            }            
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
            _context.SaveChanges();
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripById(int idTrip)
        {
            return _context.Trips.Include(t => t.Stops).FirstOrDefault(x => x.Id == idTrip);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
