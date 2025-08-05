using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FixAutoIncrementIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_Players_PlayerId",
                table: "Bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_Rounds_RoundId",
                table: "Bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualScores_Players_PlayerId",
                table: "IndividualScores");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualScores_Rounds_RoundId",
                table: "IndividualScores");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Players_PlayerId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Teams_TeamId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Rounds_RoundId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamScores_Teams_TeamId",
                table: "TeamScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bonuses",
                table: "Bonuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamScores",
                table: "TeamScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamPlayers",
                table: "TeamPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualScores",
                table: "IndividualScores");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "teams");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "rounds");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "players");

            migrationBuilder.RenameTable(
                name: "Bonuses",
                newName: "bonuses");

            migrationBuilder.RenameTable(
                name: "TeamScores",
                newName: "team_scores");

            migrationBuilder.RenameTable(
                name: "TeamPlayers",
                newName: "team_players");

            migrationBuilder.RenameTable(
                name: "IndividualScores",
                newName: "individual_scores");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "teams",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TeamType",
                table: "teams",
                newName: "team_type");

            migrationBuilder.RenameColumn(
                name: "TeamNumber",
                table: "teams",
                newName: "team_number");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "teams",
                newName: "round_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "teams",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_RoundId",
                table: "teams",
                newName: "IX_teams_round_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "rounds",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "rounds",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rounds",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TeamFormat",
                table: "rounds",
                newName: "team_format");

            migrationBuilder.RenameColumn(
                name: "RoundNumber",
                table: "rounds",
                newName: "round_number");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "rounds",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "players",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "players",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "players",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "bonuses",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "bonuses",
                newName: "points");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "bonuses",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bonuses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "bonuses",
                newName: "round_id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "bonuses",
                newName: "player_id");

            migrationBuilder.RenameColumn(
                name: "HoleNumber",
                table: "bonuses",
                newName: "hole_number");

            migrationBuilder.RenameIndex(
                name: "IX_Bonuses_RoundId",
                table: "bonuses",
                newName: "IX_bonuses_round_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bonuses_PlayerId",
                table: "bonuses",
                newName: "IX_bonuses_player_id");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "team_scores",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "PointsAwarded",
                table: "team_scores",
                newName: "points_awarded");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "team_scores",
                newName: "team_id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "team_players",
                newName: "player_id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "team_players",
                newName: "team_id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "team_players",
                newName: "IX_team_players_player_id");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "individual_scores",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "individual_scores",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "PointsAwarded",
                table: "individual_scores",
                newName: "points_awarded");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "individual_scores",
                newName: "round_id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "individual_scores",
                newName: "player_id");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualScores_RoundId",
                table: "individual_scores",
                newName: "IX_individual_scores_round_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teams",
                table: "teams",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rounds",
                table: "rounds",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bonuses",
                table: "bonuses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_scores",
                table: "team_scores",
                column: "team_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_players",
                table: "team_players",
                columns: new[] { "team_id", "player_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_individual_scores",
                table: "individual_scores",
                columns: new[] { "player_id", "round_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_bonuses_players_player_id",
                table: "bonuses",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bonuses_rounds_round_id",
                table: "bonuses",
                column: "round_id",
                principalTable: "rounds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_individual_scores_players_player_id",
                table: "individual_scores",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_individual_scores_rounds_round_id",
                table: "individual_scores",
                column: "round_id",
                principalTable: "rounds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_players_players_player_id",
                table: "team_players",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_players_teams_team_id",
                table: "team_players",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_scores_teams_team_id",
                table: "team_scores",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_rounds_round_id",
                table: "teams",
                column: "round_id",
                principalTable: "rounds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bonuses_players_player_id",
                table: "bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_bonuses_rounds_round_id",
                table: "bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_individual_scores_players_player_id",
                table: "individual_scores");

            migrationBuilder.DropForeignKey(
                name: "FK_individual_scores_rounds_round_id",
                table: "individual_scores");

            migrationBuilder.DropForeignKey(
                name: "FK_team_players_players_player_id",
                table: "team_players");

            migrationBuilder.DropForeignKey(
                name: "FK_team_players_teams_team_id",
                table: "team_players");

            migrationBuilder.DropForeignKey(
                name: "FK_team_scores_teams_team_id",
                table: "team_scores");

            migrationBuilder.DropForeignKey(
                name: "FK_teams_rounds_round_id",
                table: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teams",
                table: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rounds",
                table: "rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bonuses",
                table: "bonuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team_scores",
                table: "team_scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team_players",
                table: "team_players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_individual_scores",
                table: "individual_scores");

            migrationBuilder.RenameTable(
                name: "teams",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "rounds",
                newName: "Rounds");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "bonuses",
                newName: "Bonuses");

            migrationBuilder.RenameTable(
                name: "team_scores",
                newName: "TeamScores");

            migrationBuilder.RenameTable(
                name: "team_players",
                newName: "TeamPlayers");

            migrationBuilder.RenameTable(
                name: "individual_scores",
                newName: "IndividualScores");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "team_type",
                table: "Teams",
                newName: "TeamType");

            migrationBuilder.RenameColumn(
                name: "team_number",
                table: "Teams",
                newName: "TeamNumber");

            migrationBuilder.RenameColumn(
                name: "round_id",
                table: "Teams",
                newName: "RoundId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Teams",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_teams_round_id",
                table: "Teams",
                newName: "IX_Teams_RoundId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rounds",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Rounds",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rounds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "team_format",
                table: "Rounds",
                newName: "TeamFormat");

            migrationBuilder.RenameColumn(
                name: "round_number",
                table: "Rounds",
                newName: "RoundNumber");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Rounds",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Players",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Bonuses",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "points",
                table: "Bonuses",
                newName: "Points");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "Bonuses",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bonuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "round_id",
                table: "Bonuses",
                newName: "RoundId");

            migrationBuilder.RenameColumn(
                name: "player_id",
                table: "Bonuses",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "hole_number",
                table: "Bonuses",
                newName: "HoleNumber");

            migrationBuilder.RenameIndex(
                name: "IX_bonuses_round_id",
                table: "Bonuses",
                newName: "IX_Bonuses_RoundId");

            migrationBuilder.RenameIndex(
                name: "IX_bonuses_player_id",
                table: "Bonuses",
                newName: "IX_Bonuses_PlayerId");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "TeamScores",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "points_awarded",
                table: "TeamScores",
                newName: "PointsAwarded");

            migrationBuilder.RenameColumn(
                name: "team_id",
                table: "TeamScores",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "player_id",
                table: "TeamPlayers",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "team_id",
                table: "TeamPlayers",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_team_players_player_id",
                table: "TeamPlayers",
                newName: "IX_TeamPlayers_PlayerId");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "IndividualScores",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "IndividualScores",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "points_awarded",
                table: "IndividualScores",
                newName: "PointsAwarded");

            migrationBuilder.RenameColumn(
                name: "round_id",
                table: "IndividualScores",
                newName: "RoundId");

            migrationBuilder.RenameColumn(
                name: "player_id",
                table: "IndividualScores",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_individual_scores_round_id",
                table: "IndividualScores",
                newName: "IX_IndividualScores_RoundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bonuses",
                table: "Bonuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamScores",
                table: "TeamScores",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamPlayers",
                table: "TeamPlayers",
                columns: new[] { "TeamId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualScores",
                table: "IndividualScores",
                columns: new[] { "PlayerId", "RoundId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_Players_PlayerId",
                table: "Bonuses",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_Rounds_RoundId",
                table: "Bonuses",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualScores_Players_PlayerId",
                table: "IndividualScores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualScores_Rounds_RoundId",
                table: "IndividualScores",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Players_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Teams_TeamId",
                table: "TeamPlayers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Rounds_RoundId",
                table: "Teams",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamScores_Teams_TeamId",
                table: "TeamScores",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
