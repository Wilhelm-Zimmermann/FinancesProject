using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceController.Domain.Api.Migrations
{
    /// <inheritdoc />
    public partial class TransactionTypeColumnOnBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "Bills",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Bills");
        }
    }
}
