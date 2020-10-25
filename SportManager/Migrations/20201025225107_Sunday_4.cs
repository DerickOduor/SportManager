﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sunday_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("8a78e169-db54-49ff-999a-8bb1bcbe7956"),
                column: "ParentId",
                value: new Guid("910ce653-c7f1-4429-9b95-19270767129d"));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 26, 1, 51, 6, 465, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 51, 6, 462, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 51, 6, 465, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 51, 6, 466, DateTimeKind.Local).AddTicks(1332));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("8a78e169-db54-49ff-999a-8bb1bcbe7956"),
                column: "ParentId",
                value: new Guid("449511ee-43c6-46a7-931d-53f9895dd3cd"));

            migrationBuilder.UpdateData(
                table: "SportDiscipines",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 26, 1, 44, 9, 513, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("327d571a-1690-44e0-806d-65e0593364ad"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 44, 9, 510, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 44, 9, 513, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("910ce653-c7f1-4429-9b95-19270767129d"),
                column: "DateRegistered",
                value: new DateTime(2020, 10, 26, 1, 44, 9, 515, DateTimeKind.Local).AddTicks(760));
        }
    }
}