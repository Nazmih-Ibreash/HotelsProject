using Hotels.Data;
using Hotels.Data.Entities;
using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq; 


namespace Hotels.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepo _repo;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(IHotelRepo repo, ILogger<HotelsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [Route("")]
        [Route("{search}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<SearchHotelResponse>> GetHotels(string search)
        {
            try
            {
                var hotels = _repo.SearchHotels(search);

                var hotelsResponse = hotels.Select(h => new SearchHotelResponse
                {
                    Id = h.Id,
                    Name = h.Title,
                    Stars = h.Stars,
                    City = h.City,
                    Price = h.Price,
                    Img = h.Img,
                    Description = h.Description
                });

                if (hotelsResponse != null) return Ok(hotelsResponse);
                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get hotels: {ex}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var hotel = _repo.GetHotelById(id);

                var hotelResponse = new SearchHotelResponse
                {
                    Id = hotel.Id,
                    Name = hotel.Title,
                    Stars = hotel.Stars,
                    City = hotel.City,
                    Price = hotel.Price,
                    Img = hotel.Img,
                    Description = hotel.Description
                };

                if (hotelResponse != null) return Ok(hotelResponse);
                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get hotels: {ex}");
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody]Hotel model)
        {
            try
            {
                _repo.AddEntity(model);
                if (_repo.SaveChanges())
                {
                    return Created($"/api/hotels/{model.Id}", model);
                }
            
            }
            catch(Exception ex)
            {

                _logger.LogError($"Failed to add new hotel: {ex}");
            }
            return BadRequest("Failed to add new hotel");
        }
    }
}

