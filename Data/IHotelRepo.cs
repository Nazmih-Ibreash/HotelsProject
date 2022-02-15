using Hotels.Data.Entities;
using System.Collections.Generic;

namespace Hotels.Data
{
    public interface IHotelRepo
    {
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> GetHotelsByCategory(string category);
        Hotel GetHotelById(int id);
        bool SaveChanges();
        void AddEntity(object model);
    }
}