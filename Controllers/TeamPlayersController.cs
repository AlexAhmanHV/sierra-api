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

        // GET: /api/TeamPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamPlayer>>> GetAll() =>
            await _context.TeamPlayers.AsNoTracking().ToListAsync();

        // GET: /api/TeamPlayers/by-round/5
        [HttpGet("by-round/{roundId:int}")]
        public async Task<ActionResult<IEnumerable<TeamPlayer>>> GetByRound(int roundId)
        {
            var list = await _context.TeamPlayers
                .AsNoTracking()
                .Where(tp => tp.Team!.RoundId == roundId)  // EF översätter till JOIN, ingen Include behövs
                .ToListAsync();

            return list;
        }

        // POST: /api/TeamPlayers
        // Body: { "teamId": 1, "playerId": 12 }
        // Enkel "create" som är idempotent (gör inget om länken redan finns)
        [HttpPost]
        public async Task<ActionResult<TeamPlayer>> Create([FromBody] TeamPlayer link)
        {
            if (link.TeamId <= 0 || link.PlayerId <= 0)
                return BadRequest("TeamId och PlayerId krävs.");

            var exists = await _context.TeamPlayers.FindAsync(link.TeamId, link.PlayerId);
            if (exists is not null) return Ok(exists);

            _context.TeamPlayers.Add(link);
            await _context.SaveChangesAsync();
            return Ok(link);
        }

        // POST: /api/TeamPlayers/assign
        // Body: { "teamId": 1, "playerId": 12 }
        // Flytta spelaren inom *samma runda*:
        // - tar bort ev. befintlig koppling i rundan
        // - lägger till ny koppling till angivet lag
        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] AssignDto dto)
        {
            if (dto.TeamId <= 0 || dto.PlayerId <= 0)
                return BadRequest("TeamId och PlayerId krävs.");

            var team = await _context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == dto.TeamId);
            if (team is null) return NotFound("Team saknas.");

            // Ta bort ev. tidigare team-koppling för spelaren i samma runda
            var oldLinks = await _context.TeamPlayers
                .Where(tp => tp.PlayerId == dto.PlayerId && tp.Team!.RoundId == team.RoundId)
                .ToListAsync();

            if (oldLinks.Count > 0)
                _context.TeamPlayers.RemoveRange(oldLinks);

            // Lägg till ny koppling (om den inte redan råkar finnas)
            var exists = await _context.TeamPlayers.FindAsync(dto.TeamId, dto.PlayerId);
            if (exists is null)
                _context.TeamPlayers.Add(new TeamPlayer { TeamId = dto.TeamId, PlayerId = dto.PlayerId });

            await _context.SaveChangesAsync();
            return Ok(new { ok = true });
        }

        public class AssignDto
        {
            public int TeamId { get; set; }
            public int PlayerId { get; set; }
        }

        // DELETE via query: /api/TeamPlayers?teamId=1&playerId=12
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int teamId, [FromQuery] int playerId)
        {
            if (teamId <= 0 || playerId <= 0) return BadRequest();

            var link = await _context.TeamPlayers.FindAsync(teamId, playerId);
            if (link is null) return NotFound();

            _context.TeamPlayers.Remove(link);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: /api/TeamPlayers/bulk-replace
        // Body:
        // {
        //   "roundId": 5,
        //   "assignments": [
        //     { "teamId": 11, "playerIds": [1,2,3] },
        //     { "teamId": 12, "playerIds": [4,5,6] }
        //   ]
        // }
        // Ersätter HELA rundans uppställning atomiskt.
        [HttpPost("bulk-replace")]
        public async Task<IActionResult> BulkReplace([FromBody] BulkReplaceDto dto)
        {
            if (dto.RoundId <= 0) return BadRequest("RoundId krävs.");

            var roundTeamIds = await _context.Teams
                .Where(t => t.RoundId == dto.RoundId)
                .Select(t => t.Id)
                .ToListAsync();

            // Validera att alla inkommande teamId tillhör rundan
            var incomingTeamIds = dto.Assignments.Select(a => a.TeamId).Distinct().ToList();
            if (incomingTeamIds.Except(roundTeamIds).Any())
                return BadRequest("Minst ett teamId tillhör inte angiven runda.");

            using var tx = await _context.Database.BeginTransactionAsync();

            // Ta bort alla kopplingar i rundan
            var oldLinks = _context.TeamPlayers.Where(tp => roundTeamIds.Contains(tp.TeamId));
            _context.TeamPlayers.RemoveRange(oldLinks);
            await _context.SaveChangesAsync();

            // Lägg in nya
            var newLinks = new List<TeamPlayer>();
            foreach (var a in dto.Assignments)
            {
                foreach (var pid in a.PlayerIds.Distinct())
                {
                    if (pid > 0)
                        newLinks.Add(new TeamPlayer { TeamId = a.TeamId, PlayerId = pid });
                }
            }

            if (newLinks.Count > 0)
                await _context.TeamPlayers.AddRangeAsync(newLinks);

            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return Ok(new { ok = true, added = newLinks.Count });
        }

        public class BulkReplaceDto
        {
            public int RoundId { get; set; }
            public List<BulkAssignment> Assignments { get; set; } = new();
        }

        public class BulkAssignment
        {
            public int TeamId { get; set; }
            public List<int> PlayerIds { get; set; } = new();
        }
    }
}
