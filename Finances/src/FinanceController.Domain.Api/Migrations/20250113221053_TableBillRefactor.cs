using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceController.Domain.Api.Migrations
{
    /// <inheritdoc />
    public partial class TableBillRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Bills",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Bills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "Bills",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Bills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecurrencePattern",
                table: "Bills",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "RecurrencePattern",
                table: "Bills");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Bills",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
