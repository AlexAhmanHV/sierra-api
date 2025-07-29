public class TeamScore
{
    public int TeamId { get; set; }
    public int Position { get; set; }
    public int PointsAwarded { get; set; }

    public Team Team { get; set; }
}
