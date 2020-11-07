using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sato2050hrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CssClass", "Level", "Link", "MenuType", "MenuUser", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("96deb675-0d05-47e8-9827-3fbd3b6be7a8"), null, 1, "/Store/", "SUB-MENU", "STAFF", "Store", new Guid("400dd70c-af53-4849-9889-823256adf99a") },
                    { new Guid("a4f70713-403c-449d-b60f-20cee0087f55"), null, 1, "/Event/", "SUB-MENU", "STAFF", "View event", new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74") },
                    { new Guid("3a0672c3-5af1-416f-a09c-ae3143fe31c2"), null, 2, "/Event/Create/", "SUB-MENU", "STAFF", "Add event", new Guid("d0e36979-1c0e-41a8-9a4a-c19293390f74") },
                    { new Guid("ebc9b700-2cd3-4984-811c-01dd30c6beb6"), null, 2, "/Venue/", "SUB-MENU", "STAFF", "View venues", new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f") },
                    { new Guid("8d3d14a1-0209-49e4-bbbf-b3a79f7381b6"), null, 2, "/Venue/", "SUB-MENU", "STAFF", "View venues", new Guid("1f37b623-7973-43f0-baf5-bd15c995e89f") }
                });

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.InsertData(
                table: "SportDiscipines",
                columns: new[] { "Id", "DateAdded", "Deleted", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("27f9810e-3e57-4f56-b787-8e8df67fd9ff"), new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5911), false, "Basketball", true },
                    { new Guid("8d5d6ccb-c34f-44b6-8bc7-0b19e5d0e472"), new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5975), false, "Volleyball", true },
                    { new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"), new DateTime(2020, 11, 7, 20, 51, 39, 581, DateTimeKind.Local).AddTicks(5982), false, "Racket games", true }
                });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 578, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                columns: new[] { "DateRegistered", "ProfileId", "RegistrationNumber" },
                values: new object[] { new DateTime(2020, 11, 7, 20, 51, 39, 580, DateTimeKind.Local).AddTicks(9598), new Guid("bfdedc6a-01d1-44f7-9e70-595b8091342a"), "ST002" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Authorized", "ChangePassword", "DateRegistered", "Deleted", "Email", "Firstname", "Lastname", "Otp", "OtpDate", "Password", "Phone", "ProfileId", "RegistrationNumber", "RegistrationVerified", "Status" },
                values: new object[] { new Guid("44c04a3e-844d-46e6-ae44-1e3e2853e50c"), true, false, new DateTime(2020, 11, 7, 20, 51, 39, 580, DateTimeKind.Local).AddTicks(9829), false, "derick_oduor@yahoo.com", "Derick", "Oduor", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTbfZW0odYQ9g2uyGrB+Rw==", "+254712345678", new Guid("cb8f202b-549b-448d-a2e8-927ff944813e"), "ST003", false, false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 7, 20, 51, 39, 582, DateTimeKind.Local).AddTicks(6562));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("3a0672c3-5af1-416f-a09c-ae3143fe31c2"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("8d3d14a1-0209-49e4-bbbf-b3a79f7381b6"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("96deb675-0d05-47e8-9827-3fbd3b6be7a8"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a4f70713-403c-449d-b60f-20cee0087f55"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("ebc9b700-2cd3-4984-811c-01dd30c6beb6"));

            migrationBuilder.DeleteData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("27f9810e-3e57-4f56-b787-8e8df67fd9ff"));

            migrationBuilder.DeleteData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("73503878-6414-42fc-87a6-b98c1bc17b5c"));

            migrationBuilder.DeleteData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("8d5d6ccb-c34f-44b6-8bc7-0b19e5d0e472"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("44c04a3e-844d-46e6-ae44-1e3e2853e50c"));

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
                columns: new[] { "DateRegistered", "ProfileId", "RegistrationNumber" },
                values: new object[] { new DateTime(2020, 11, 2, 22, 58, 19, 352, DateTimeKind.Local).AddTicks(1306), new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "ST001" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 11, 2, 22, 58, 19, 353, DateTimeKind.Local).AddTicks(6101));
        }
    }
}
