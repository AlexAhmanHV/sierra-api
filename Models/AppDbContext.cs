using Microsoft.EntityFrameworkCore;
using SierraApi.Models;

namespace SierraApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<TeamScore> TeamScores { get; set; }
        public DbSet<IndividualScore> IndividualScores { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Player
            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            });

            // 🔹 Round
            modelBuilder.Entity<Round>(entity =>
            {
                entity.ToTable("rounds");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.RoundNumber).HasColumnName("round_number");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.TeamFormat).HasColumnName("team_format");
            });

            // 🔹 Team
            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoundId).HasColumnName("round_id");
                entity.Property(e => e.TeamNumber).HasColumnName("team_number");
                entity.Property(e => e.TeamType).HasColumnName("team_type");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            });

            // 🔹 TeamPlayer
            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("team_players");
                entity.HasKey(e => new { e.TeamId, e.PlayerId });
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.PlayerId).HasColumnName("player_id");
            });

            // 🔹 TeamScore
            modelBuilder.Entity<TeamScore>(entity =>
            {
                entity.ToTable("team_scores");
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.Position).HasColumnName("position");
                entity.Property(e => e.PointsAwarded).HasColumnName("points_awarded");
            });

            // 🔹 IndividualScore
            modelBuilder.Entity<IndividualScore>(entity =>
            {
                entity.ToTable("individual_scores");
                entity.HasKey(e => new { e.PlayerId, e.RoundId });
                entity.Property(e => e.PlayerId).HasColumnName("player_id");
                entity.Property(e => e.RoundId).HasColumnName("round_id");
                entity.Property(e => e.Score).HasColumnName("score");
                entity.Property(e => e.Position).HasColumnName("position");
                entity.Property(e => e.PointsAwarded).HasColumnName("points_awarded");
            });

            // 🔹 Bonus
            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.ToTable("bonuses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PlayerId).HasColumnName("player_id");
                entity.Property(e => e.RoundId).HasColumnName("round_id");
                entity.Property(e => e.HoleNumber).HasColumnName("hole_number");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Points).HasColumnName("points");
                entity.Property(e => e.Note).HasColumnName("note");
            });

            // 🔗 Relationships (samma som tidigare)
            modelBuilder.Entity<TeamPlayer>()
                .HasOne(tp => tp.Team)
                .WithMany(t => t.TeamPlayers)
                .HasForeignKey(tp => tp.TeamId);

            modelBuilder.Entity<TeamPlayer>()
                .HasOne(tp => tp.Player)
                .WithMany(p => p.TeamPlayers)
                .HasForeignKey(tp => tp.PlayerId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Round)
                .WithMany(r => r.Teams)
                .HasForeignKey(t => t.RoundId);

            modelBuilder.Entity<TeamScore>()
                .HasOne(ts => ts.Team)
                .WithOne(t => t.TeamScore)
                .HasForeignKey<TeamScore>(ts => ts.TeamId);

            modelBuilder.Entity<IndividualScore>()
                .HasOne(i => i.Player)
                .WithMany(p => p.IndividualScores)
                .HasForeignKey(i => i.PlayerId);

            modelBuilder.Entity<IndividualScore>()
                .HasOne(i => i.Round)
                .WithMany(r => r.IndividualScores)
                .HasForeignKey(i => i.RoundId);

            modelBuilder.Entity<Bonus>()
                .HasOne(b => b.Player)
                .WithMany(p => p.Bonuses)
                .HasForeignKey(b => b.PlayerId);

            modelBuilder.Entity<Bonus>()
                .HasOne(b => b.Round)
                .WithMany(r => r.Bonuses)
                .HasForeignKey(b => b.RoundId);
        }

    }
}
