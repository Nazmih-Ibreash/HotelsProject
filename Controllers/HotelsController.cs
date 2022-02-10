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
                    NoOfStars= h.Stars
                });
                return Ok(hotelsResponse);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get hotels: {ex} ");
                return BadRequest("Failed to get hotels");
            }
            
        }
    }
}

