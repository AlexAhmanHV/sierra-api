using SierraApi.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<TeamPlayer> TeamPlayers { get; set; }
    public ICollection<IndividualScore> IndividualScores { get; set; }
    public ICollection<Bonus> Bonuses { get; set; }
}
