using SierraApi.Models;

public class Round
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoundNumber { get; set; }
    public DateTime Date { get; set; }
    public string TeamFormat { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Team> Teams { get; set; }
    public ICollection<IndividualScore> IndividualScores { get; set; }
    public ICollection<Bonus> Bonuses { get; set; }
}
