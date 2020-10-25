using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sunday_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CssClass", "Level", "Link", "MenuType", "MenuUser", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("910ce653-c7f1-4429-9b95-19270767129d"), null, 1, "#Staff", "MAINMENU", "STAFF", "Manage Staff", new Guid("910ce653-c7f1-4429-9b95-19270767129d") },
                    { new Guid("33dcb26b-db77-4147-8398-d45a5d09e952"), null, 2, "#Disciplines", "MAINMENU", "STAFF", "Manage Sport Disciplines", new Guid("33dcb26b-db77-4147-8398-d45a5d09e952") },
                    { new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"), null, 3, "#Events", "MAINMENU", "STAFF", "Manage Events", new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74") },
                    { new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f"), null, 4, "#Venues", "MAINMENU", "STAFF", "Manage Venues", new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f") },
                    { new Guid("400dd70c-af53-4849-9889-823256adf99a"), null, 5, "#Store", "MAINMENU", "STAFF", "Sports Store", new Guid("400dd70c-af53-4849-9889-823256adf99a") },
                    { new Guid("832f9e6c-ee71-456c-9d70-c43cc756763b"), null, 6, "#Profiles", "MAINMENU", "STAFF", "Manage User Profiles", new Guid("832f9e6c-ee71-456c-9d70-c43cc756763b") },
                    { new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd"), null, 7, "#Maintenance", "MAINMENU", "STAFF", "Maintenance", new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd") }
                });

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 26, 1, 16, 12, 255, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 16, 12, 253, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 16, 12, 254, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 16, 12, 255, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.InsertData(
                table: "AccessRights",
                columns: new[] { "Id", "MenuId", "ParentMenuId", "ProfileId" },
                values: new object[,]
                {
                    { new Guid("910ce653-c7f1-4429-9b95-19270767129d"), new Guid("910ce653-c7f1-4429-9b95-19270767129d"), new Guid("910ce653-c7f1-4429-9b95-19270767129d"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("a1a2be93-a724-49db-b0a2-e9bac91a1bf6"), new Guid("33dcb26b-db77-4147-8398-d45a5d09e952"), new Guid("33dcb26b-db77-4147-8398-d45a5d09e952"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("9768817f-52ef-4876-8665-408ed66ea7a7"), new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"), new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("c94cfbeb-f24f-4373-a95e-e1538bb570f4"), new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f"), new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("76d95407-bd1c-4002-8257-bec8cd31b523"), new Guid("400dd70c-af53-4849-9889-823256adf99a"), new Guid("400dd70c-af53-4849-9889-823256adf99a"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("b624870d-5137-454a-9ce7-a17447edc16d"), new Guid("832f9e6c-ee71-456c-9d70-c43cc756763b"), new Guid("832f9e6c-ee71-456c-9d70-c43cc756763b"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") },
                    { new Guid("1c8b5f6a-5b26-4b24-b104-da026f87a210"), new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd"), new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd"), new Guid("327d571a-1690-44e0-806d-65e0593364ad") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("1c8b5f6a-5b26-4b24-b104-da026f87a210"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("76d95407-bd1c-4002-8257-bec8cd31b523"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("9768817f-52ef-4876-8665-408ed66ea7a7"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("a1a2be93-a724-49db-b0a2-e9bac91a1bf6"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("b624870d-5137-454a-9ce7-a17447edc16d"));

            migrationBuilder.DeleteData(
                table: "AccessRights",
                keyColumn: "Id",
                keyValue: new Guid("c94cfbeb-f24f-4373-a95e-e1538bb570f4"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("33dcb26b-db77-4147-8398-d45a5d09e952"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("400dd70c-af53-4849-9889-823256adf99a"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("832f9e6c-ee71-456c-9d70-c43cc756763b"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74"));

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
    }
}
