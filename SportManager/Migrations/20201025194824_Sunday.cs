using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportManager.Migrations
{
    public partial class Sunday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Error = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CssClass = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    MenuType = table.Column<string>(nullable: true),
                    MenuUser = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecepientAddress = table.Column<string>(nullable: true),
                    RecepientName = table.Column<string>(nullable: true),
                    MessageSubject = table.Column<string>(nullable: true),
                    MessageText = table.Column<string>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    Sent = table.Column<bool>(nullable: false),
                    MessageDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsPassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PasswordText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportDiscipines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportDiscipines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessRights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false),
                    ParentMenuId = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessRights_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRights_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Otp = table.Column<string>(nullable: true),
                    OtpDate = table.Column<DateTime>(nullable: false),
                    Authorized = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Otp = table.Column<string>(nullable: true),
                    OtpDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Authorized = table.Column<bool>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false),
                    SportDiscipineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SportDiscipines_SportDiscipineId",
                        column: x => x.SportDiscipineId,
                        principalTable: "SportDiscipines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StoreCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_StoreCategories_StoreCategoryId",
                        column: x => x.StoreCategoryId,
                        principalTable: "StoreCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    VenueId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSessions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSessions_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportDisciplinesInEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    SportDiscipineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportDisciplinesInEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportDisciplinesInEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportDisciplinesInEvents_SportDiscipines_SportDiscipineId",
                        column: x => x.SportDiscipineId,
                        principalTable: "SportDiscipines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EventId = table.Column<Guid>(nullable: false),
                    SportDiscipineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_SportDiscipines_SportDiscipineId",
                        column: x => x.SportDiscipineId,
                        principalTable: "SportDiscipines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakerCheckers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SqlQuery = table.Column<string>(nullable: true),
                    Entity = table.Column<string>(nullable: true),
                    Action = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MakerId = table.Column<Guid>(nullable: false),
                    CheckerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakerCheckers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakerCheckers_Staffs_CheckerId",
                        column: x => x.CheckerId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MakerCheckers_Staffs_MakerId",
                        column: x => x.MakerId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsParticipatingInEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    SportDisciplinesInEventId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsParticipatingInEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsParticipatingInEvents_SportDisciplinesInEvents_SportDisciplinesInEventId",
                        column: x => x.SportDisciplinesInEventId,
                        principalTable: "SportDisciplinesInEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentsParticipatingInEvents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreItemInUse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StoreItemId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    SportDiscipineId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Rejected = table.Column<bool>(nullable: false),
                    Returned = table.Column<bool>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    DateApproved = table.Column<DateTime>(nullable: false),
                    DateReturned = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItemInUse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreItemInUse_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreItemInUse_SportDiscipines_SportDiscipineId",
                        column: x => x.SportDiscipineId,
                        principalTable: "SportDiscipines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreItemInUse_StoreItems_StoreItemId",
                        column: x => x.StoreItemId,
                        principalTable: "StoreItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "Inter-University: Multiple disciplines" },
                    { new Guid("bfdedc6a-01d1-44f7-9e70-595b8091342a"), "Intra-University: Multiple disciplines" },
                    { new Guid("cb8f202b-549b-448d-a2e8-927ff944813e"), "Intra-University: Single discipline" },
                    { new Guid("43abbe95-fc36-4122-b974-6dac96fd8b61"), "Inter-University: Single discipline" }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "IsPassword", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("327d571a-1690-44e0-806d-65e0593364ad"), false, "EMAILADDRESS", "appsderick@gmail.com" },
                    { new Guid("bfdedc6a-01d1-44f7-9e70-595b8091342a"), true, "EMAILPASSWORD", "fjMlAlKNVkNQTNIm5790Ww==" },
                    { new Guid("cb8f202b-549b-448d-a2e8-927ff944813e"), false, "EMAILFROM", "SPORTS DEPARTMENT" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "Coordinator" },
                    { new Guid("bfdedc6a-01d1-44f7-9e70-595b8091342a"), "Patron" },
                    { new Guid("cb8f202b-549b-448d-a2e8-927ff944813e"), "StoreKeeper" },
                    { new Guid("43abbe95-fc36-4122-b974-6dac96fd8b61"), "Secretary" },
                    { new Guid("3dd74e55-64b8-4245-8cfe-b79ec6057a3d"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "SportDiscipines",
                columns: new[] { "Id", "DateAdded", "Deleted", "Name", "Status" },
                values: new object[] { new Guid("910ce653-c7f1-4429-9b95-19270767129d"), new DateTime(2020, 10, 25, 22, 48, 24, 84, DateTimeKind.Local).AddTicks(676), false, "Football", true });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Authorized", "DateRegistered", "Deleted", "Email", "Firstname", "Lastname", "Otp", "OtpDate", "Password", "Phone", "ProfileId", "RegistrationNumber", "Status" },
                values: new object[] { new Guid("327d571a-1690-44e0-806d-65e0593364ad"), true, new DateTime(2020, 10, 25, 22, 48, 24, 81, DateTimeKind.Local).AddTicks(1574), false, "oduorderick@gmail.com", "Derick", "Oduor", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTbfZW0odYQ9g2uyGrB+Rw==", "+254715812661", new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "ST001", false });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Authorized", "DateRegistered", "Deleted", "Email", "Firstname", "Lastname", "Otp", "OtpDate", "Password", "Phone", "ProfileId", "RegistrationNumber", "Status" },
                values: new object[] { new Guid("81019aa2-4056-41f9-b4b3-828d51fa7c51"), true, new DateTime(2020, 10, 25, 22, 48, 24, 83, DateTimeKind.Local).AddTicks(7295), false, "appsderick@gmail.com", "Derick", "Oduor", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTbfZW0odYQ9g2uyGrB+Rw==", "+254712345678", new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "ST001", false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Authorized", "DateRegistered", "Email", "Firstname", "Lastname", "Otp", "OtpDate", "Password", "Phone", "ProfileId", "RegistrationNumber", "SportDiscipineId", "Status" },
                values: new object[] { new Guid("910ce653-c7f1-4429-9b95-19270767129d"), true, new DateTime(2020, 10, 25, 22, 48, 24, 85, DateTimeKind.Local).AddTicks(11), "derick_oduor@yahoo.com", "Derick", "Oduor", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTbfZW0odYQ9g2uyGrB+Rw==", "+254756993396", new Guid("327d571a-1690-44e0-806d-65e0593364ad"), "S13/21416/14", new Guid("910ce653-c7f1-4429-9b95-19270767129d"), false });

            migrationBuilder.CreateIndex(
                name: "IX_AccessRights_MenuId",
                table: "AccessRights",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRights_ProfileId",
                table: "AccessRights",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_EventId",
                table: "EventSessions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_VenueId",
                table: "EventSessions",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_MakerCheckers_CheckerId",
                table: "MakerCheckers",
                column: "CheckerId");

            migrationBuilder.CreateIndex(
                name: "IX_MakerCheckers_MakerId",
                table: "MakerCheckers",
                column: "MakerId");

            migrationBuilder.CreateIndex(
                name: "IX_SportDisciplinesInEvents_EventId",
                table: "SportDisciplinesInEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SportDisciplinesInEvents_SportDiscipineId",
                table: "SportDisciplinesInEvents",
                column: "SportDiscipineId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ProfileId",
                table: "Staffs",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItemInUse_EventId",
                table: "StoreItemInUse",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItemInUse_SportDiscipineId",
                table: "StoreItemInUse",
                column: "SportDiscipineId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItemInUse_StoreItemId",
                table: "StoreItemInUse",
                column: "StoreItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_StoreId",
                table: "StoreItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreCategoryId",
                table: "Stores",
                column: "StoreCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfileId",
                table: "Students",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SportDiscipineId",
                table: "Students",
                column: "SportDiscipineId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsParticipatingInEvents_SportDisciplinesInEventId",
                table: "StudentsParticipatingInEvents",
                column: "SportDisciplinesInEventId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsParticipatingInEvents_StudentId",
                table: "StudentsParticipatingInEvents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EventId",
                table: "Teams",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportDiscipineId",
                table: "Teams",
                column: "SportDiscipineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRights");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "EventSessions");

            migrationBuilder.DropTable(
                name: "MakerCheckers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "StoreItemInUse");

            migrationBuilder.DropTable(
                name: "StudentsParticipatingInEvents");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "SportDisciplinesInEvents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SportDiscipines");

            migrationBuilder.DropTable(
                name: "StoreCategories");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
