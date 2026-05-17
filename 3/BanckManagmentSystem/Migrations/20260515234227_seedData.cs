using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BanckManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mangers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed.ali@example.com", "Ahmed Ali", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789" },
                    { 2, "mohamed.hassan@example.com", "Mohamed Hassan", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Branched",
                columns: new[] { "Id", "Address", "BranchCode", "Name", "PhoneNumber", "managerId" },
                values: new object[,]
                {
                    { 1, "123 Main St, City", "BR001", "Main Branch", "0123456789", 1 },
                    { 2, "456 Second St, City", "BR002", "Second Branch", "0987654321", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branched",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branched",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mangers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mangers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
