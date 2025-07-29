public class Bonus
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int RoundId { get; set; }
    public int HoleNumber { get; set; }
    public string Type { get; set; }
    public int Points { get; set; }
    public string Note { get; set; }

    public Player Player { get; set; }
    public Round Round { get; set; }
}
