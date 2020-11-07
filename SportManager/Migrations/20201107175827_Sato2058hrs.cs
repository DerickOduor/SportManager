using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sato2058hrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRights",
                columns: new[] { "Id", "MenuId", "ParentMenuId", "ProfileId" },
                values: new object[,]
                {
                    { new Guid("759b44d1-3f41-41c0-99ad-19880524962a"), new Guid("96deb675-0d05-47e8-9827-3fbd3b6be7a8"), new Guid("400dd70c-af53-4849-9889-823256adf99a"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("14e558bc-3474-462c-8000-71fd082fe64e"), new Guid("a4f70713-403c-449d-b60f-20cee0087f55"), new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("902527af-cc96-460f-86f8-b0f7eabaf512"), new Guid("ebc9b700-2cd3-4984-811c-01dd30c6beb6"), new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a4f70713-403c-449d-b60f-20cee0087f55"),
                column: "Name",
                value: "View events");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("14e558bc-3474-462c-8000-71fd082fe64e"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("759b44d1-3f41-41c0-99ad-19880524962a"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("902527af-cc96-460f-86f8-b0f7eabaf512"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a4f70713-403c-449d-b60f-20cee0087f55"),
                column: "Name",
                value: "View event");

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("27f9810e-3e57-4f56-b787-8e8df67fd9ff"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("8d5d6ccb-c34f-44b6-8bc7-0b19e5d0e472"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 578, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("44c04a3e-844d-46e6-ae44-1e3e2853e50c"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 580, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 580, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 582, DateTimeKind.Local).AddTicks(6562));
        }
    }
}
