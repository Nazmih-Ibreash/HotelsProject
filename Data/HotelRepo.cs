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

        public IEnumerable<Hotel> SearchHotels(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return GetAllHotels();
            }
            var results = _ctx.Hotels
                    .Where(p => p.City.ToLower().Contains(search.ToLower()) || 
                    p.Title.ToLower().Contains(search.ToLower()));
            return results.ToList<Hotel>();
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
