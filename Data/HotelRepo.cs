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

        public IEnumerable<Place> GetAllHotels()
        {
            return _ctx.Hotels
                .OrderBy(prop => prop.Title).ToList<Place>();
        }

        public IEnumerable<Place> GetHotelsByCategory(string search)
        {
            return _ctx.Hotels
                    .Where(p => p.Category == search);
            /* 
            from p in _ctx.Hotels
                   where p.Category == search
                   select p;
            */
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
