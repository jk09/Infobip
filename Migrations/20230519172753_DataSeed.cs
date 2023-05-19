using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infobip.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarType", "Color", "Name", "NumberSeats", "Plate" },
                values: new object[,]
                {
                    { 1, "Toyota Corolla", "Red", "Toyota Corolla of Alice", 2, "ABC-123" },
                    { 2, "Ford F-150", "Orange", "Ford F-150 of Bob", 2, "DEF-456" },
                    { 3, "BMW 3 Series", "Yellow", "BMW 3 Series of Charlie", 6, "GHI-789" },
                    { 4, "Honda Civic", "Green", "Honda Civic of David", 4, "JKL-012" },
                    { 5, "Chevrolet Camaro", "Blue", "Chevrolet Camaro of Emma", 4, "MNO-345" },
                    { 6, "Hyundai Sonata", "Indigo", "Hyundai Sonata of Frank", 2, "PQR-678" },
                    { 7, "Nissan Altima", "Violet", "Nissan Altima of Grace", 4, "STU-901" },
                    { 8, "Audi A4", "Black", "Audi A4 of Henry", 3, "VWX-234" },
                    { 9, "Subaru Outback", "White", "Subaru Outback of Isabel", 5, "YZA-567" },
                    { 10, "Tesla Model 3", "Gray", "Tesla Model 3 of Jack", 3, "BCD-890" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "IsDriver", "Name" },
                values: new object[,]
                {
                    { 1, true, "Anna Smith" },
                    { 2, true, "Brian Jones" },
                    { 3, true, "Chloe Wilson" },
                    { 4, true, "Daniel Lee" },
                    { 5, true, "Ella Brown" },
                    { 6, false, "Felix Garcia" },
                    { 7, true, "Grace Miller" },
                    { 8, false, "Harry Johnson" },
                    { 9, true, "Ivy Davis" },
                    { 10, true, "James Taylor" },
                    { 11, false, "Kayla Martin" },
                    { 12, false, "Leo Thompson" },
                    { 13, false, "Mia Williams" },
                    { 14, true, "Noah Rodriguez" },
                    { 15, false, "Olivia Anderson" },
                    { 16, false, "Ryan Clark" },
                    { 17, true, "Sophia Lopez" },
                    { 18, false, "Tyler Lewis" },
                    { 19, false, "Zoe Walker" },
                    { 20, true, "Adam White" },
                    { 21, false, "Bella Harris" },
                    { 22, true, "Connor Hall" },
                    { 23, true, "Emma Young" },
                    { 24, false, "Liam Allen" },
                    { 25, false, "Nora King" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
