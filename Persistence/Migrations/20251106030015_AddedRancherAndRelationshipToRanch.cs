using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedRancherAndRelationshipToRanch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RancherId",
                table: "Ranches",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Ranches_RancherId",
                table: "Ranches",
                column: "RancherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranches_Ranchers_RancherId",
                table: "Ranches",
                column: "RancherId",
                principalTable: "Ranchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranches_Ranchers_RancherId",
                table: "Ranches");

            migrationBuilder.DropIndex(
                name: "IX_Ranches_RancherId",
                table: "Ranches");

            migrationBuilder.DropColumn(
                name: "RancherId",
                table: "Ranches");
        }
    }
}
