using System.Collections.Generic;

namespace CoreTravels.Models
{
    public interface ICoreTravelsRepository
    {
        IEnumerable<Trip> GetAllTrips();

        void AddTrip(Trip trip);

        bool SaveChanges();

        Trip GetTripByName(string tripName);

        void AddStop(string tripName, Stop stop);
    }
}