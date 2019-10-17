using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfDraft2.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    DraftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DraftName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.DraftId);
                });

            migrationBuilder.CreateTable(
                name: "MyTeams",
                columns: table => new
                {
                    MyTeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    FantasyLeagueID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DraftId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTeams", x => x.MyTeamID);
                    table.ForeignKey(
                        name: "FK_MyTeams_Drafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Drafts",
                        principalColumn: "DraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyTeams_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Swings = table.Column<string>(nullable: true),
                    PgaDebut = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthCity = table.Column<string>(nullable: true),
                    BirthState = table.Column<string>(nullable: true),
                    College = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    DraftId = table.Column<int>(nullable: true),
                    MyTeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Drafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Drafts",
                        principalColumn: "DraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_MyTeams_MyTeamID",
                        column: x => x.MyTeamID,
                        principalTable: "MyTeams",
                        principalColumn: "MyTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTeams_DraftId",
                table: "MyTeams",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTeams_UserID",
                table: "MyTeams",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DraftId",
                table: "Players",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_MyTeamID",
                table: "Players",
                column: "MyTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "MyTeams");

            migrationBuilder.DropTable(
                name: "Drafts");
        }
    }
}
