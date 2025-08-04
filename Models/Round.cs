public class Round
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoundNumber { get; set; }
    public DateTime Date { get; set; }
    public string TeamFormat { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<IndividualScore> IndividualScores { get; set; } = new List<IndividualScore>();
    public ICollection<Bonus> Bonuses { get; set; } = new List<Bonus>();
}
