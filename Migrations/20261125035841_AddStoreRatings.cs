using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations;

/// <inheritdoc />
public partial class _20261125035841_AddStoreRatings : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_StoreHours_Stores_StoreId",
            table: "StoreHours");

        migrationBuilder.DropPrimaryKey(
            name: "PK_StoreHours",
            table: "StoreHours");

        migrationBuilder.RenameTable(
            name: "StoreHours",
            newName: "StoreHour");

        migrationBuilder.AddPrimaryKey(
            name: "PK_StoreHour",
            table: "StoreHour",
            columns: new[] { "StoreId", "DayOfWeek" });

        migrationBuilder.CreateTable(
            name: "StoreRatings",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Score = table.Column<int>(type: "int", nullable: false),
                Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreRatings", x => x.Id);
                table.CheckConstraint("CK_StoreRatings_Score_Range", "[Score] >= 1 AND [Score] <= 5");
                table.ForeignKey(
                    name: "FK_StoreRatings_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "AccountId");
                table.ForeignKey(
                    name: "FK_StoreRatings_Stores_StoreId",
                    column: x => x.StoreId,
                    principalTable: "Stores",
                    principalColumn: "AccountId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_StoreRatings_CustomerId",
            table: "StoreRatings",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_StoreRatings_StoreId_CustomerId",
            table: "StoreRatings",
            columns: new[] { "StoreId", "CustomerId" },
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_StoreHour_Stores_StoreId",
            table: "StoreHour",
            column: "StoreId",
            principalTable: "Stores",
            principalColumn: "AccountId",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_StoreHour_Stores_StoreId",
            table: "StoreHour");

        migrationBuilder.DropTable(
            name: "StoreRatings");

        migrationBuilder.DropPrimaryKey(
            name: "PK_StoreHour",
            table: "StoreHour");

        migrationBuilder.RenameTable(
            name: "StoreHour",
            newName: "StoreHours");

        migrationBuilder.AddPrimaryKey(
            name: "PK_StoreHours",
            table: "StoreHours",
            columns: new[] { "StoreId", "DayOfWeek" });

        migrationBuilder.AddForeignKey(
            name: "FK_StoreHours_Stores_StoreId",
            table: "StoreHours",
            column: "StoreId",
            principalTable: "Stores",
            principalColumn: "AccountId",
            onDelete: ReferentialAction.Cascade);
    }
}
