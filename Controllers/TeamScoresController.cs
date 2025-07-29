using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamScoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamScoresController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamScore>>> GetAll() => await _context.TeamScores.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<TeamScore>> Create(TeamScore score)
        {
            _context.TeamScores.Add(score);
            await _context.SaveChangesAsync();
            return Ok(score);
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> Delete(int teamId)
        {
            var score = await _context.TeamScores.FindAsync(teamId);
            if (score == null) return NotFound();
            _context.TeamScores.Remove(score);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
