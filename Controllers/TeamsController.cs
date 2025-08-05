using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

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
        public async Task<ActionResult<Team>> Create([FromBody] Team team)
        {
            if (team == null)
                return BadRequest("Invalid payload.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Set CreatedAt if missing and ensure UTC
            if (team.CreatedAt == default)
                team.CreatedAt = DateTime.UtcNow;
            else if (team.CreatedAt.Kind != DateTimeKind.Utc)
                team.CreatedAt = DateTime.SpecifyKind(team.CreatedAt, DateTimeKind.Utc);

            try
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
            }
            catch (DbUpdateException ex)
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
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