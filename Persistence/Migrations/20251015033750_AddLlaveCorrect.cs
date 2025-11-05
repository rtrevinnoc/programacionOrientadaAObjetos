using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLlaveCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Llave_LlaveId",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_LlaveId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "LlaveId",
                table: "Classroom");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassroomId",
                table: "Llave",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Llave_ClassroomId",
                table: "Llave",
                column: "ClassroomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Llave_Classroom_ClassroomId",
                table: "Llave",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Llave_Classroom_ClassroomId",
                table: "Llave");

            migrationBuilder.DropIndex(
                name: "IX_Llave_ClassroomId",
                table: "Llave");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Llave");

            migrationBuilder.AddColumn<Guid>(
                name: "LlaveId",
                table: "Classroom",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_LlaveId",
                table: "Classroom",
                column: "LlaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Llave_LlaveId",
                table: "Classroom",
                column: "LlaveId",
                principalTable: "Llave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
