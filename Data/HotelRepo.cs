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
                    .Where(p => p.City.ToLower() == search.ToLower());
            /* 
            from p in _ctx.Hotels
                   where p.Category == search
                   select p;
            */  
        }

        public Hotel GetHotelById(Hotel hotel)
        {
            return (Hotel)_ctx.Hotels
                    .Where(p => p.City == hotel.City);
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

   
    }
}
