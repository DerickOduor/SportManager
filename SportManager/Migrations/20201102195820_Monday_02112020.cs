using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Monday_02112020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportDiscipinePatrons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SportDiscipineId = table.Column<Guid>(nullable: false),
                    StaffId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportDiscipinePatrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportDiscipinePatrons_SportDiscipines_SportDiscipineId",
                        column: x => x.SportDiscipineId,
                        principalTable: "SportDiscipines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportDiscipinePatrons_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 2, 22, 58, 19, 352, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 2, 22, 58, 19, 350, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 2, 22, 58, 19, 352, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 2, 22, 58, 19, 353, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.CreateIndex(
                name: "IX_SportDiscipinePatrons_SportDiscipineId",
                table: "SportDiscipinePatrons",
                column: "SportDiscipineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportDiscipinePatrons_StaffId",
                table: "SportDiscipinePatrons",
                column: "StaffId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportDiscipinePatrons");

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 29, 11, 33, 48, 288, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 29, 11, 33, 48, 285, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 29, 11, 33, 48, 287, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 29, 11, 33, 48, 289, DateTimeKind.Local).AddTicks(597));
        }
    }
}
