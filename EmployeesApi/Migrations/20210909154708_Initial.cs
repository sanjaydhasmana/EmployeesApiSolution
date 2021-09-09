using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "FirstName", "HireDate", "IsActive", "LastName", "Salary" },
                values: new object[] { 1, "QA", "Bob", new DateTime(2020, 11, 13, 11, 47, 7, 813, DateTimeKind.Local).AddTicks(8397), true, "Smith", 180000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "FirstName", "HireDate", "IsActive", "LastName", "Salary" },
                values: new object[] { 2, "CEO", "Sue", new DateTime(2016, 9, 10, 11, 47, 7, 818, DateTimeKind.Local).AddTicks(2609), true, "Jones", 250000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "FirstName", "HireDate", "IsActive", "LastName", "Salary" },
                values: new object[] { 3, null, "Ray", new DateTime(2021, 2, 21, 11, 47, 7, 818, DateTimeKind.Local).AddTicks(2663), false, "Palmer", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
