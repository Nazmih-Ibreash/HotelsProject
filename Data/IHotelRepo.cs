using Hotels.Data.Entities;
using System.Collections.Generic;

namespace Hotels.Data
{
    public interface IHotelRepo
    {
        IEnumerable<Place> GetAllHotels();
        IEnumerable<Place> GetHotelsByCategory(string category);
        bool SaveChanges();
    }
}