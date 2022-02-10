using Hotels.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Hotels.Data
{
    public class HotelSeeder
    {
        private readonly HotelContext _context;
        private readonly IWebHostEnvironment _env;

        public HotelSeeder(HotelContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void seed()
        {
            _context.Database.EnsureCreated();
            if (!_context.Hotels.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/data.json");
                var json = File.ReadAllText(filePath);
                var places = JsonSerializer.Deserialize<IEnumerable<Hotel>>(json);

                _context.Hotels.AddRange(places);


                _context.SaveChanges();
            }
        }
    }
}
