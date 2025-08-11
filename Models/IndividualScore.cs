using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

public class IndividualScore
{
    public int PlayerId { get; set; }
    public int RoundId { get; set; }
    public int Score { get; set; }
    public int Position { get; set; }
    public int PointsAwarded { get; set; }

    [ValidateNever]
    [JsonIgnore]
    public Player? Player { get; set; }

    [ValidateNever]
    [JsonIgnore]
    public Round? Round { get; set; }
}
