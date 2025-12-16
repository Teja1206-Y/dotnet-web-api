using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Officeworkflows.Api.Data;
using Officeworkflows.Api.Models;
using Officeworkflows.Api.Services.Dto.Holidays;

namespace Officeworkflows.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HolidayController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HolidayController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Add Holiday
        [HttpPost]
        public async Task<IActionResult> AddHoliday([FromBody] HolidayRequestDto dto)
        {
            var holiday = new Holiday
            {
                Date = dto.Date,
                Name = dto.Name,
                Type = dto.Type
            };

            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();

            return Ok(new HolidayResponseDto
            {
                Id = holiday.Id,
                Date = holiday.Date,
                Name = holiday.Name,
                Type = holiday.Type
            });
        }

        // ✅ Get all holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayResponseDto>>> GetHolidays()
        {
            var holidays = await _context.Holidays
                .Select(h => new HolidayResponseDto
                {
                    Id = h.Id,
                    Date = h.Date,
                    Name = h.Name,
                    Type = h.Type
                })
                .ToListAsync();

            return Ok(holidays);
        }

        // ✅ Delete holiday
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null) return NotFound();

            _context.Holidays.Remove(holiday);
            await _context.SaveChangesAsync();

            return Ok("Holiday deleted ❌");
        }
    }
}
