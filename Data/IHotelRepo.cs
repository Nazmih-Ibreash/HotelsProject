using Hotels.Data.Entities;
using System.Collections.Generic;

namespace Hotels.Data
{
    public interface IHotelRepo
    {
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> GetHotelsByCategory(string category);
        bool SaveChanges();
        Hotel GetHotelById(Hotel hotel);
    }
}