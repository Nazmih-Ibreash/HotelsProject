using Hotels.Data.Entities;
using System.Collections.Generic;

namespace Hotels.Data
{
    public interface IHotelRepo
    {
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> GetHotelByName(string search);
        Hotel GetHotelById(int id);
        bool SaveChanges();
        void AddEntity(object model);
    }
}