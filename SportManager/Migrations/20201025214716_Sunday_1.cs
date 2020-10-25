using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sunday_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangePassword",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChangePassword",
                table: "Staffs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 26, 0, 47, 15, 500, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 0, 47, 15, 498, DateTimeKind.Local).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 0, 47, 15, 500, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 0, 47, 15, 501, DateTimeKind.Local).AddTicks(6075));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "Staffs");

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 25, 22, 48, 24, 84, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 25, 22, 48, 24, 81, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 25, 22, 48, 24, 83, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 25, 22, 48, 24, 85, DateTimeKind.Local).AddTicks(11));
        }
    }
}
