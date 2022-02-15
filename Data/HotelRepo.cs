using Hotels.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotels.Data
{
    public class HotelRepo : IHotelRepo
    {
        private readonly HotelContext _ctx;
        public HotelRepo(HotelContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _ctx.Hotels
                .OrderBy(prop => prop.Title).ToList<Hotel>();
        }

        public IEnumerable<Hotel> GetHotelsByCategory(string search)
        {
            return _ctx.Hotels
                    .Where(p => p.City.ToLower().Contains(search.ToLower()));
        }

        public Hotel GetHotelById(int id)
        {
            return _ctx.Hotels.Where(h => h.Id == id)
                .FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }
    }
}
