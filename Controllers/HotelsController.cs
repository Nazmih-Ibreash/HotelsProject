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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult <IEnumerable<SearchHotelResponse>> Get()
        {
            try
            {
                var hotels = _repo.GetAllHotels();
                var hotelsResponse = hotels.Select(h => new SearchHotelResponse
                {
                    Id = h.Id,
                    Name = h.Title,
                    Stars = h.Stars,
                    City = h.City,
                    Price= h.Price, 
                    Img= h.Img,
                    Description= h.Description

                });
                return Ok(hotelsResponse);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get hotels: {ex} ");
                return BadRequest("Failed to get hotels");
            }
            
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var hotel = _repo.GetHotelById(id);

                if (hotel != null) return Ok(hotel);
                else return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get hotels: {ex}");
                return BadRequest(ex.Message);
            }
        }

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

