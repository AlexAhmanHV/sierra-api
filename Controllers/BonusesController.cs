using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonusesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BonusesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetAll() => await _context.Bonuses.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Bonus>> Create(Bonus bonus)
        {
            _context.Bonuses.Add(bonus);
            await _context.SaveChangesAsync();
            return Ok(bonus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bonus = await _context.Bonuses.FindAsync(id);
            if (bonus == null) return NotFound();
            _context.Bonuses.Remove(bonus);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
