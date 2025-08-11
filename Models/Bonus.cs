using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

public class Bonus
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int RoundId { get; set; }
    public int HoleNumber { get; set; }
    public string Type { get; set; }
    public int Points { get; set; }
    public string Note { get; set; }

    [ValidateNever]
    [JsonIgnore]                 // (valfritt men tryggt för POST)
    public Player? Player { get; set; }   // gör nullable

    [ValidateNever]
    [JsonIgnore]
    public Round? Round { get; set; }     // gör nullable
}
