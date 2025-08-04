public class Team
{
    public int Id { get; set; }
    public int RoundId { get; set; }
    public int TeamNumber { get; set; }
    public string TeamType { get; set; }
    public DateTime CreatedAt { get; set; }

    public Round? Round { get; set; } = null; // ✅ optional
    public ICollection<TeamPlayer> TeamPlayers { get; set; } = new List<TeamPlayer>(); // ✅ initierad
    public TeamScore? TeamScore { get; set; } = null; // ✅ optional
}
