using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_4_AddShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseReceiptItems_WarehouseReceipts_WarehouseReceiptId",
                table: "WarehouseReceiptItems");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseReceiptId",
                table: "WarehouseReceiptItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "WarehouseReceiptItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryNoteNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    HasIrregularProducts = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReceiptItems_ShipmentId",
                table: "WarehouseReceiptItems",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseReceiptItems_Shipments_ShipmentId",
                table: "WarehouseReceiptItems",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseReceiptItems_WarehouseReceipts_WarehouseReceiptId",
                table: "WarehouseReceiptItems",
                column: "WarehouseReceiptId",
                principalTable: "WarehouseReceipts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseReceiptItems_Shipments_ShipmentId",
                table: "WarehouseReceiptItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseReceiptItems_WarehouseReceipts_WarehouseReceiptId",
                table: "WarehouseReceiptItems");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseReceiptItems_ShipmentId",
                table: "WarehouseReceiptItems");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "WarehouseReceiptItems");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseReceiptId",
                table: "WarehouseReceiptItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseReceiptItems_WarehouseReceipts_WarehouseReceiptId",
                table: "WarehouseReceiptItems",
                column: "WarehouseReceiptId",
                principalTable: "WarehouseReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
