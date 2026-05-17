using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanckManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedandupdatetablenameAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerShipRole",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerShipRole",
                table: "Accounts");
        }
    }
}
