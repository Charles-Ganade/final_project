using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations;

/// <inheritdoc />
public partial class _20261124103654_AddItems : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Items",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Items", x => x.Id);
                table.CheckConstraint("CK_Items_Price_NonNegative", "[Price] >= 0");
                table.ForeignKey(
                    name: "FK_Items_Stores_StoreId",
                    column: x => x.StoreId,
                    principalTable: "Stores",
                    principalColumn: "AccountId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Items_StoreId",
            table: "Items",
            column: "StoreId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Items");
    }
}
