using SierraApi.Models;

public class Team
{
    public int Id { get; set; }
    public int RoundId { get; set; }
    public int TeamNumber { get; set; }
    public string TeamType { get; set; }
    public DateTime CreatedAt { get; set; }

    public Round Round { get; set; }
    public ICollection<TeamPlayer> TeamPlayers { get; set; }
    public TeamScore TeamScore { get; set; }
}
