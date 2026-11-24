using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations;

/// <inheritdoc />
public partial class _20261124074929_AddCustomerAndStoreProfiles : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "EmailIndex",
            table: "AspNetUsers");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CreatedAt",
            table: "AspNetUsers",
            type: "datetime2",
            nullable: false,
            defaultValueSql: "SYSUTCDATETIME()",
            oldClrType: typeof(DateTime),
            oldType: "datetime2");

        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.AccountId);
                table.ForeignKey(
                    name: "FK_Customers_AspNetUsers_AccountId",
                    column: x => x.AccountId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Stores",
            columns: table => new
            {
                AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                StallNumber = table.Column<int>(type: "int", nullable: true),
                ApprovalStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                ReviewedByAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stores", x => x.AccountId);
                table.ForeignKey(
                    name: "FK_Stores_AspNetUsers_AccountId",
                    column: x => x.AccountId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Stores_AspNetUsers_ReviewedByAccountId",
                    column: x => x.ReviewedByAccountId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUsers_NormalizedEmail",
            table: "AspNetUsers",
            column: "NormalizedEmail",
            unique: true,
            filter: "[NormalizedEmail] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Stores_ReviewedByAccountId",
            table: "Stores",
            column: "ReviewedByAccountId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "Stores");

        migrationBuilder.DropIndex(
            name: "IX_AspNetUsers_NormalizedEmail",
            table: "AspNetUsers");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CreatedAt",
            table: "AspNetUsers",
            type: "datetime2",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime2",
            oldDefaultValueSql: "SYSUTCDATETIME()");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "AspNetUsers",
            column: "NormalizedEmail");
    }
}
