using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceController.Domain.Api.Migrations
{
    /// <inheritdoc />
    public partial class PrivilegeUserNN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersPrivileges",
                columns: table => new
                {
                    PrivilegeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPrivileges", x => new { x.PrivilegeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersPrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPrivileges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPrivileges_UserId",
                table: "UsersPrivileges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPrivileges");
        }
    }
}
