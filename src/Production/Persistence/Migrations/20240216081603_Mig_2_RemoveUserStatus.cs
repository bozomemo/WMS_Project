using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_2_RemoveUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PalletMovements_Users_PerformedById",
                table: "PalletMovements");

            migrationBuilder.DropIndex(
                name: "IX_PalletMovements_PerformedById",
                table: "PalletMovements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PerformedById",
                table: "PalletMovements",
                newName: "PerformedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerformedByUserId",
                table: "PalletMovements",
                newName: "PerformedById");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PalletMovements_PerformedById",
                table: "PalletMovements",
                column: "PerformedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PalletMovements_Users_PerformedById",
                table: "PalletMovements",
                column: "PerformedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
