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
        public async Task<ActionResult<Team>> Create(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Team team)
        {
            if (id != team.Id) return BadRequest();
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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
    }
}
