using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamPlayersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamPlayersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamPlayer>>> GetAll() => await _context.TeamPlayers.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<TeamPlayer>> Create(TeamPlayer tp)
        {
            _context.TeamPlayers.Add(tp);
            await _context.SaveChangesAsync();
            return Ok(tp);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int teamId, [FromQuery] int playerId)
        {
            var tp = await _context.TeamPlayers.FindAsync(teamId, playerId);
            if (tp == null) return NotFound();
            _context.TeamPlayers.Remove(tp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
