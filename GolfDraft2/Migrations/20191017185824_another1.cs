using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfDraft2.Migrations
{
    public partial class another1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTeams_Drafts_DraftId",
                table: "MyTeams");

            migrationBuilder.DropIndex(
                name: "IX_MyTeams_DraftId",
                table: "MyTeams");

            migrationBuilder.DropColumn(
                name: "DraftId",
                table: "MyTeams");

            migrationBuilder.AddColumn<int>(
                name: "MyTeamID",
                table: "Drafts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_MyTeamID",
                table: "Drafts",
                column: "MyTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drafts_MyTeams_MyTeamID",
                table: "Drafts",
                column: "MyTeamID",
                principalTable: "MyTeams",
                principalColumn: "MyTeamID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drafts_MyTeams_MyTeamID",
                table: "Drafts");

            migrationBuilder.DropIndex(
                name: "IX_Drafts_MyTeamID",
                table: "Drafts");

            migrationBuilder.DropColumn(
                name: "MyTeamID",
                table: "Drafts");

            migrationBuilder.AddColumn<int>(
                name: "DraftId",
                table: "MyTeams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyTeams_DraftId",
                table: "MyTeams",
                column: "DraftId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTeams_Drafts_DraftId",
                table: "MyTeams",
                column: "DraftId",
                principalTable: "Drafts",
                principalColumn: "DraftId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
