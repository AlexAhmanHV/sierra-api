using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;
using SierraApi.Models.Dtos;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetAll() => await _context.Teams.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> Get(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return team == null ? NotFound() : team;
        }

        [HttpPost]
        public async Task<ActionResult<Team>> Create([FromBody] TeamCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.Teams
                .FirstOrDefaultAsync(t => t.RoundId == dto.RoundId && t.TeamNumber == dto.TeamNumber);

            if (existing != null)
                return Conflict($"Team number {dto.TeamNumber} already exists for this round.");

            var team = new Team
            {
                RoundId = dto.RoundId,
                TeamNumber = dto.TeamNumber,
                TeamType = dto.TeamType,
                CreatedAt = DateTime.UtcNow
            };

            Console.WriteLine($"👀 Attempting to create team: roundId={team.RoundId}, teamNumber={team.TeamNumber}, teamType={team.TeamType}");

            try
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
            }
            catch (DbUpdateException ex)
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
                Console.WriteLine($"❌ DB error: {detail}");
                return Problem(title: "Could not save team", detail: detail, statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Team team)
        {
            if (id != team.Id) return BadRequest();

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                    return NotFound();
                throw;
            }
            catch (DbUpdateException ex)
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
                return Problem(title: "Could not update team", detail: detail, statusCode: 500);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}