using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NullablePrefect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Llave_Classroom_ClassroomId",
                table: "Llave");

            migrationBuilder.DropForeignKey(
                name: "FK_Llave_Prefect_PrefectId",
                table: "Llave");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classroom_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Course_CourseId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Llave",
                table: "Llave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom");

            migrationBuilder.RenameTable(
                name: "Llave",
                newName: "Llaves");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Classroom",
                newName: "Classrooms");

            migrationBuilder.RenameIndex(
                name: "IX_Llave_PrefectId",
                table: "Llaves",
                newName: "IX_Llaves_PrefectId");

            migrationBuilder.RenameIndex(
                name: "IX_Llave_ClassroomId",
                table: "Llaves",
                newName: "IX_Llaves_ClassroomId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrefectId",
                table: "Llaves",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Llaves",
                table: "Llaves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Llaves_Classrooms_ClassroomId",
                table: "Llaves",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Llaves_Prefect_PrefectId",
                table: "Llaves",
                column: "PrefectId",
                principalTable: "Prefect",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classrooms_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Courses_CourseId",
                table: "Schedule",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Llaves_Classrooms_ClassroomId",
                table: "Llaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Llaves_Prefect_PrefectId",
                table: "Llaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classrooms_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Courses_CourseId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Llaves",
                table: "Llaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms");

            migrationBuilder.RenameTable(
                name: "Llaves",
                newName: "Llave");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Classrooms",
                newName: "Classroom");

            migrationBuilder.RenameIndex(
                name: "IX_Llaves_PrefectId",
                table: "Llave",
                newName: "IX_Llave_PrefectId");

            migrationBuilder.RenameIndex(
                name: "IX_Llaves_ClassroomId",
                table: "Llave",
                newName: "IX_Llave_ClassroomId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrefectId",
                table: "Llave",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Llave",
                table: "Llave",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classroom",
                table: "Classroom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Llave_Classroom_ClassroomId",
                table: "Llave",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Llave_Prefect_PrefectId",
                table: "Llave",
                column: "PrefectId",
                principalTable: "Prefect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classroom_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Course_CourseId",
                table: "Schedule",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
