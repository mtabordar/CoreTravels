using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTravels.Models
{
    public class CoreTravelsRepository : ICoreTravelsRepository
    {
        private ICoreTravelsContext _context;

        public CoreTravelsRepository(ICoreTravelsContext context)
        {
            _context = context;
        }

        public void AddStop(string tripName, Stop stop)
        {
            var trip = GetTripByName(tripName);

            if(tripName.Any())
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

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips.Include(t => t.Stops).FirstOrDefault(x => x.Name == tripName);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
