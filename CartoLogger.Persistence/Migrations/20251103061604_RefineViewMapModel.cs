using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartoLogger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefineViewMapModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewLatitude",
                table: "Maps",
                newName: "ViewCenterLat");

            migrationBuilder.RenameColumn(
                name: "ViewCenterLongitude",
                table: "Maps",
                newName: "ViewCenterLng");

            migrationBuilder.AddColumn<double>(
                name: "ViewZoom",
                table: "Maps",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewZoom",
                table: "Maps");

            migrationBuilder.RenameColumn(
                name: "ViewCenterLng",
                table: "Maps",
                newName: "ViewCenterLongitude");

            migrationBuilder.RenameColumn(
                name: "ViewCenterLat",
                table: "Maps",
                newName: "ViewLatitude");
        }
    }
}
