using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoundsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoundsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Round>>> GetAll() => await _context.Rounds.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Round>> Get(int id)
        {
            var round = await _context.Rounds.FindAsync(id);
            return round == null ? NotFound() : round;
        }

        [HttpPost]
        public async Task<ActionResult<Round>> Create(Round round)
        {
            _context.Rounds.Add(round);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = round.Id }, round);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Round round)
        {
            if (id != round.Id) return BadRequest();
            _context.Entry(round).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var round = await _context.Rounds.FindAsync(id);
            if (round == null) return NotFound();
            _context.Rounds.Remove(round);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
