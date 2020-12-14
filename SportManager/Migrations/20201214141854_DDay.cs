using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class DDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NoOfMatches = table.Column<int>(nullable: false),
                    MatchesWon = table.Column<int>(nullable: false),
                    MatchesLost = table.Column<int>(nullable: false),
                    MatchesDrawn = table.Column<int>(nullable: false),
                    SportDisciplinesInEventId = table.Column<Guid>(nullable: false),
                    TournamentStageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventResults_SportDisciplinesInEvents_SportDisciplinesInEventId",
                        column: x => x.SportDisciplinesInEventId,
                        principalTable: "SportDisciplinesInEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventResults_TournamentStages_TournamentStageId",
                        column: x => x.TournamentStageId,
                        principalTable: "TournamentStages",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("27f9810e-3e57-4f56-b787-8e8df67fd9ff"),
                column: "DateAdded",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 503, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"),
                column: "DateAdded",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 503, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("8d5d6ccb-c34f-44b6-8bc7-0b19e5d0e472"),
                column: "DateAdded",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 503, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 501, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 497, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("44c04a3e-844d-46e6-ae44-1e3e2853e50c"),
                column: "DateRegistered",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 500, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 500, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 12, 14, 17, 18, 52, 506, DateTimeKind.Local).AddTicks(2929));

            migrationBuilder.InsertData(
                table: "TournamentStages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("910ce653-c7f1-4429-9b95-19270767129d"), "Group Stage" },
                    { new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"), "Round of 16" },
                    { new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"), "Quarter-finals" },
                    { new Guid("33dcb26b-db77-4147-8398-d45a5d09e952"), "Semi-finals" },
                    { new Guid("400dd70c-af53-4849-9889-823256adf99a"), "Finals" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_SportDisciplinesInEventId",
                table: "EventResults",
                column: "SportDisciplinesInEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventResults_TournamentStageId",
                table: "EventResults",
                column: "TournamentStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventResults");

            migrationBuilder.DropTable(
                name: "TournamentStages");

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("27f9810e-3e57-4f56-b787-8e8df67fd9ff"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 70, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 70, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("8d5d6ccb-c34f-44b6-8bc7-0b19e5d0e472"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 70, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 69, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 67, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("44c04a3e-844d-46e6-ae44-1e3e2853e50c"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 69, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 69, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 58, 27, 70, DateTimeKind.Local).AddTicks(8329));
        }
    }
}
