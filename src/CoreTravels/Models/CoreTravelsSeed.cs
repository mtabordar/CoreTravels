using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTravels.Models
{
    public class CoreTravelsSeed
    {
        private ICoreTravelsContext _context;

        public CoreTravelsSeed(ICoreTravelsContext context)
        {
            _context = context;
        }

        //public async Task EnsureSeedData()
        //{
        //    if (!_context.Trips.Any())
        //    {
        //        var usTrip = new Trip()
        //        {
        //            DateCreated = DateTime.UtcNow,
        //            Name = "US trip",
        //            UserName = string.Empty,
        //            Stops = new List<Stop>()
        //            {

        //            }
        //        };

        //        _context.Trips.Add(usTrip);
        //        _context.Stops.AddRange(usTrip.Stops);

        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
