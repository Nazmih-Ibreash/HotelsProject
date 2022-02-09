using Hotels.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hotels.Controllers
{
    public class AppController : Controller
    {
        private readonly IHotelRepo _repo;
        public AppController(IHotelRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View(_repo.GetAllHotels());
            }
            else
            {
                return View(_repo.GetHotelsByCategory(search));
            }
        }
            public IActionResult Search()
        {
            return View();
        }
    }
}
