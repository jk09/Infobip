using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infobip.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CarType = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Plate = table.Column<string>(type: "TEXT", nullable: false),
                    NumberSeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsDriver = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartLocation = table.Column<string>(type: "TEXT", nullable: false),
                    EndLocation = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarType", "Color", "Name", "NumberSeats", "Plate" },
                values: new object[,]
                {
                    { 1, "Toyota Corolla", "Red", "Toyota Corolla of Alice", 3, "ABC-123" },
                    { 2, "Ford F-150", "Orange", "Ford F-150 of Bob", 3, "DEF-456" },
                    { 3, "BMW 3 Series", "Yellow", "BMW 3 Series of Charlie", 5, "GHI-789" },
                    { 4, "Honda Civic", "Green", "Honda Civic of David", 4, "JKL-012" },
                    { 5, "Chevrolet Camaro", "Blue", "Chevrolet Camaro of Emma", 5, "MNO-345" },
                    { 6, "Hyundai Sonata", "Indigo", "Hyundai Sonata of Frank", 5, "PQR-678" },
                    { 7, "Nissan Altima", "Violet", "Nissan Altima of Grace", 6, "STU-901" },
                    { 8, "Audi A4", "Black", "Audi A4 of Henry", 2, "VWX-234" },
                    { 9, "Subaru Outback", "White", "Subaru Outback of Isabel", 5, "YZA-567" },
                    { 10, "Tesla Model 3", "Gray", "Tesla Model 3 of Jack", 4, "BCD-890" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "IsDriver", "Name" },
                values: new object[,]
                {
                    { 1, true, "Anna Smith" },
                    { 2, false, "Brian Jones" },
                    { 3, false, "Chloe Wilson" },
                    { 4, true, "Daniel Lee" },
                    { 5, true, "Ella Brown" },
                    { 6, false, "Felix Garcia" },
                    { 7, false, "Grace Miller" },
                    { 8, true, "Harry Johnson" },
                    { 9, false, "Ivy Davis" },
                    { 10, false, "James Taylor" },
                    { 11, true, "Kayla Martin" },
                    { 12, true, "Leo Thompson" },
                    { 13, false, "Mia Williams" },
                    { 14, false, "Noah Rodriguez" },
                    { 15, false, "Olivia Anderson" },
                    { 16, true, "Ryan Clark" },
                    { 17, true, "Sophia Lopez" },
                    { 18, true, "Tyler Lewis" },
                    { 19, false, "Zoe Walker" },
                    { 20, false, "Adam White" },
                    { 21, false, "Bella Harris" },
                    { 22, false, "Connor Hall" },
                    { 23, true, "Emma Young" },
                    { 24, false, "Liam Allen" },
                    { 25, false, "Nora King" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TravelPlans");
        }
    }
}
