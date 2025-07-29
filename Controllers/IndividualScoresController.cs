using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using SierraApi.Models;

namespace SierraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualScoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public IndividualScoresController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualScore>>> GetAll() => await _context.IndividualScores.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<IndividualScore>> Create(IndividualScore score)
        {
            _context.IndividualScores.Add(score);
            await _context.SaveChangesAsync();
            return Ok(score);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int playerId, [FromQuery] int roundId)
        {
            var score = await _context.IndividualScores.FindAsync(playerId, roundId);
            if (score == null) return NotFound();
            _context.IndividualScores.Remove(score);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
