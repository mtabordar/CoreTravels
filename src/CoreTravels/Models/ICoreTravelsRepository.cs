namespace CoreTravels.Models
{
    using System.Collections.Generic;

    public interface ICoreTravelsRepository
    {
        IEnumerable<Trip> GetAllTrips();

        void AddTrip(Trip trip);

        bool SaveChanges();

        Trip GetTripById(int id);

        void AddStop(int idTrip, Stop stop);
    }
}