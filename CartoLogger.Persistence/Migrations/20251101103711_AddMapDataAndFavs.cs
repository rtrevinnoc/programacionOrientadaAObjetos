using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartoLogger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMapDataAndFavs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ViewCenterLongitude",
                table: "Maps",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ViewLatitude",
                table: "Maps",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "UserFavoriteMaps",
                columns: table => new
                {
                    FavoriteMapsId = table.Column<int>(type: "int", nullable: false),
                    FavoritedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteMaps", x => new { x.FavoriteMapsId, x.FavoritedById });
                    table.ForeignKey(
                        name: "FK_UserFavoriteMaps_Maps_FavoriteMapsId",
                        column: x => x.FavoriteMapsId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMaps_Users_FavoritedById",
                        column: x => x.FavoritedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMaps_FavoritedById",
                table: "UserFavoriteMaps",
                column: "FavoritedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteMaps");

            migrationBuilder.DropColumn(
                name: "ViewCenterLongitude",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "ViewLatitude",
                table: "Maps");
        }
    }
}
