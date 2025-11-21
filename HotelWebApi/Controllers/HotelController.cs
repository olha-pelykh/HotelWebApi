using HotelWebApi.Data;
using HotelWebApi.Models.ViewModels;
using HotelWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IHotelMappingService mappingService;

        public HotelController(ApplicationDBContext dBContext, IHotelMappingService mappingService)
        {
            this.dbContext = dBContext;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelListViewModel>>> GetAllHotels()
        {
            try
            {
                var hotels = await dbContext.Hotels.ToListAsync();
                var hotelViewModels = mappingService.ToListViewModelList(hotels);
                return Ok(hotelViewModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<HotelViewModel>> GetHotelByID(Guid id)
        {
            try
            {
                var hotel = await dbContext.Hotels.FindAsync(id);
                if (hotel == null)
                {
                    return NotFound($"Hotel with ID {id} not found.");
                }

                var hotelViewModel = mappingService.ToViewModel(hotel);
                return Ok(hotelViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HotelViewModel>> AddHotel(CreateHotelViewModel createHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotelEntity = mappingService.ToEntity(createHotelViewModel);
                dbContext.Hotels.Add(hotelEntity);
                await dbContext.SaveChangesAsync();

                var hotelViewModel = mappingService.ToViewModel(hotelEntity);
                return CreatedAtAction(nameof(GetHotelByID), new { id = hotelEntity.ID }, hotelViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<HotelViewModel>> UpdateHotel(Guid id, UpdateHotelViewModel updateHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await dbContext.Hotels.FindAsync(id);
                if (hotel == null)
                {
                    return NotFound($"Hotel with ID {id} not found.");
                }

                mappingService.UpdateEntity(hotel, updateHotelViewModel);
                await dbContext.SaveChangesAsync();

                var hotelViewModel = mappingService.ToViewModel(hotel);
                return Ok(hotelViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]                
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            try
            {
                var hotel = await dbContext.Hotels.FindAsync(id);
                if (hotel == null)
                {
                    return NotFound($"Hotel with ID {id} not found.");
                }

                dbContext.Hotels.Remove(hotel);
                await dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
