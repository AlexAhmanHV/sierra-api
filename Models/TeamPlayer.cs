using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

public class TeamPlayer
{
    public int TeamId { get; set; }
    public int PlayerId { get; set; }

    [ValidateNever]
    [JsonIgnore]           // ← POST kräver då inte dessa fält
    public Team? Team { get; set; }

    [ValidateNever]
    [JsonIgnore]
    public Player? Player { get; set; }
}
