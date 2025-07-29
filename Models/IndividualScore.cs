public class IndividualScore
{
    public int PlayerId { get; set; }
    public int RoundId { get; set; }
    public int Score { get; set; }
    public int Position { get; set; }
    public int PointsAwarded { get; set; }

    public Player Player { get; set; }
    public Round Round { get; set; }
}
