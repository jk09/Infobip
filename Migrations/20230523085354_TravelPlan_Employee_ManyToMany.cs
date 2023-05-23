using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infobip.Migrations
{
    /// <inheritdoc />
    public partial class TravelPlan_Employee_ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TravelPlans_TravelPlanId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TravelPlanId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TravelPlanId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeTravelPlan",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelPlansId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTravelPlan", x => new { x.EmployeesId, x.TravelPlansId });
                    table.ForeignKey(
                        name: "FK_EmployeeTravelPlan_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTravelPlan_TravelPlans_TravelPlansId",
                        column: x => x.TravelPlansId,
                        principalTable: "TravelPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberSeats",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "NumberSeats",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "NumberSeats",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "NumberSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "NumberSeats",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "NumberSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDriver",
                value: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsDriver",
                value: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsDriver",
                value: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsDriver",
                value: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsDriver",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTravelPlan_TravelPlansId",
                table: "EmployeeTravelPlan",
                column: "TravelPlansId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTravelPlan");

            migrationBuilder.AddColumn<int>(
                name: "TravelPlanId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberSeats",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "NumberSeats",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "NumberSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "NumberSeats",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22,
                column: "TravelPlanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "IsDriver", "TravelPlanId" },
                values: new object[] { false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TravelPlanId",
                table: "Employees",
                column: "TravelPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TravelPlans_TravelPlanId",
                table: "Employees",
                column: "TravelPlanId",
                principalTable: "TravelPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
