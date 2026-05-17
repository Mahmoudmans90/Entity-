using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanckManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedandupdatetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branched_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Branched_Mangers_managerId",
                table: "Branched");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branched",
                table: "Branched");

            migrationBuilder.RenameTable(
                name: "Branched",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_Branched_managerId",
                table: "Branches",
                newName: "IX_Branches_managerId");

            migrationBuilder.RenameIndex(
                name: "IX_Branched_BranchCode",
                table: "Branches",
                newName: "IX_Branches_BranchCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Mangers_managerId",
                table: "Branches",
                column: "managerId",
                principalTable: "Mangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Mangers_managerId",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branched");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_managerId",
                table: "Branched",
                newName: "IX_Branched_managerId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_BranchCode",
                table: "Branched",
                newName: "IX_Branched_BranchCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branched",
                table: "Branched",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branched_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branched",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branched_Mangers_managerId",
                table: "Branched",
                column: "managerId",
                principalTable: "Mangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
