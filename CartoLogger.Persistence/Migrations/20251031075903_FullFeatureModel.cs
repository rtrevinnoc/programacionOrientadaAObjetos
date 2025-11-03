using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartoLogger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FullFeatureModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Features",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Features",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Geometry",
                table: "Features",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Geometry",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Features",
                newName: "Data");
        }
    }
}
