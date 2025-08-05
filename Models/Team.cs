using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 👈 detta är det viktiga
    public int Id { get; set; }

    public int RoundId { get; set; }
    public int TeamNumber { get; set; }
    public string TeamType { get; set; }
    public DateTime CreatedAt { get; set; }

    public Round? Round { get; set; } = null;
    public ICollection<TeamPlayer> TeamPlayers { get; set; } = new List<TeamPlayer>();
    public TeamScore? TeamScore { get; set; } = null;
}