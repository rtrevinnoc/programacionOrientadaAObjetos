using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLlave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrefectId",
                table: "Llave",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Prefect",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefect", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Llave_PrefectId",
                table: "Llave",
                column: "PrefectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Llave_Prefect_PrefectId",
                table: "Llave",
                column: "PrefectId",
                principalTable: "Prefect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Llave_Prefect_PrefectId",
                table: "Llave");

            migrationBuilder.DropTable(
                name: "Prefect");

            migrationBuilder.DropIndex(
                name: "IX_Llave_PrefectId",
                table: "Llave");

            migrationBuilder.DropColumn(
                name: "PrefectId",
                table: "Llave");
        }
    }
}
