using HotelWebApi.Data;
using HotelWebApi.Models;
using HotelWebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public HotelController(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            return Ok(dbContext.Hotels.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]    
        public IActionResult GetHotelByID(Guid id)
        {
            var hotel = dbContext.Hotels.Find(id);
            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult AddHotel(AddHotelDto addHotelDto)
        {
            var hotelEntity = new Hotel()
            {
                HotelName = addHotelDto.HotelName,
                HotelDescription = addHotelDto.HotelDescription,
                HotelAddress = addHotelDto.HotelAddress,
                HotelPhone = addHotelDto.HotelPhone,
                HotelEmail = addHotelDto.HotelEmail
            };

            dbContext.Hotels.Add(hotelEntity);
            dbContext.SaveChanges();

            return Ok(hotelEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateHotel(Guid id, UpdateHotelDto updateHotelDto)
        {
            var hotel = dbContext.Hotels.Find(id);
            if (hotel is null)
            {
                return NotFound();
            }

            hotel.HotelName = updateHotelDto.HotelName;
            hotel.HotelDescription = updateHotelDto.HotelDescription;
            hotel.HotelAddress = updateHotelDto.HotelAddress;
            hotel.HotelPhone = updateHotelDto.HotelPhone;
            hotel.HotelEmail = updateHotelDto.HotelEmail;
           
            dbContext.SaveChanges();

            return Ok(hotel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteHotel(Guid id)
        {
            var hotel = dbContext.Hotels.Find(id);
            if (hotel is null)
            {
                return NotFound();
            }

            dbContext.Hotels.Remove(hotel);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
