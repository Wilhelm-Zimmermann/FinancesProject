using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceController.Domain.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdentityColumFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
