using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations;

/// <inheritdoc />
public partial class _20261125021352_AddStoreHours : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "StoreHours",
            columns: table => new
            {
                StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DayOfWeek = table.Column<int>(type: "int", nullable: false),
                OpenTime = table.Column<TimeOnly>(type: "time", nullable: true),
                CloseTime = table.Column<TimeOnly>(type: "time", nullable: true),
                IsClosed = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreHours", x => new { x.StoreId, x.DayOfWeek });
                table.CheckConstraint("CK_StoreHours_DayOfWeek", "[DayOfWeek] >= 0 AND [DayOfWeek] <= 6");
                table.CheckConstraint("CK_StoreHours_ValidHours", "(\n    [IsClosed] = 1\n    AND [OpenTime] IS NULL\n    AND [CloseTime] IS NULL\n)\nOR\n(\n    [IsClosed] = 0\n    AND [OpenTime] IS NOT NULL\n    AND [CloseTime] IS NOT NULL\n    AND [CloseTime] > [OpenTime]\n)");
                table.ForeignKey(
                    name: "FK_StoreHours_Stores_StoreId",
                    column: x => x.StoreId,
                    principalTable: "Stores",
                    principalColumn: "AccountId",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "StoreHours");
    }
}
