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
        public async Task<ActionResult<Round>> CreateRound([FromBody] Round round)
        {
            if (round == null)
                return BadRequest("Ogiltig payload.");

            // Kontrollera ModelState för valideringsfel
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Sätt CreatedAt om den saknas
            if (round.CreatedAt == default)
                round.CreatedAt = DateTime.UtcNow;

            // Normalisera datum till endast datumdel och sätt till UTC
            round.Date = DateTime.SpecifyKind(round.Date.Date, DateTimeKind.Utc);

            // Säkerställ att CreatedAt är UTC
            if (round.CreatedAt.Kind != DateTimeKind.Utc)
                round.CreatedAt = DateTime.SpecifyKind(round.CreatedAt, DateTimeKind.Utc);

            try
            {
                _context.Rounds.Add(round);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Skicka tillbaka inner exception text så vi ser exakt DB-felet i Network-tabben
                var detail = ex.InnerException?.Message ?? ex.Message;
                return Problem(title: "Kunde inte spara runda", detail: detail, statusCode: 500);
            }

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