using Hotels.Data;
using Hotels.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Booked(Hotel bookedItem)
        {
            if (ModelState.IsValid)
            {
                return View(_repo.GetHotelById(bookedItem));
                //ModelState.Clear();
            }
            else
            {
                return RedirectToAction("Index");
               // return View(_repo.GetHotelsByCategory(bookedItem));
            }
        }
        /*
        public IActionResult Booked()
        {
            return View();
        }
        */
    }
}
