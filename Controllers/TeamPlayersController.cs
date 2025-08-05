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

        [HttpGet("{teamId}/{playerId}")]
        public async Task<ActionResult<TeamPlayer>> Get(int teamId, int playerId)
        {
            var teamPlayer = await _context.TeamPlayers.FirstOrDefaultAsync(tp => tp.TeamId == teamId && tp.PlayerId == playerId);
            return teamPlayer == null ? NotFound() : teamPlayer;
        }

        [HttpPost]
        public async Task<ActionResult<TeamPlayer>> Create([FromBody] TeamPlayer tp)
        {
            if (tp == null)
                return BadRequest("Invalid payload.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.TeamPlayers.Add(tp);
                await _context.SaveChangesAsync();

                // Return the created TeamPlayer - since there's no single Id, we'll return Ok instead of CreatedAtAction
                return Ok(tp);
            }
            catch (DbUpdateException ex)
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
                return Problem(title: "Could not save team player", detail: detail, statusCode: 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int teamId, [FromQuery] int playerId)
        {
            var tp = await _context.TeamPlayers.FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == playerId);
            if (tp == null) return NotFound();

            _context.TeamPlayers.Remove(tp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}