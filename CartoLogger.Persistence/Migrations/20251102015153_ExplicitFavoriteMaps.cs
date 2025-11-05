using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartoLogger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitFavoriteMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMaps_Maps_FavoriteMapsId",
                table: "UserFavoriteMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMaps_Users_FavoritedById",
                table: "UserFavoriteMaps");

            migrationBuilder.RenameColumn(
                name: "FavoritedById",
                table: "UserFavoriteMaps",
                newName: "MapId");

            migrationBuilder.RenameColumn(
                name: "FavoriteMapsId",
                table: "UserFavoriteMaps",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMaps_FavoritedById",
                table: "UserFavoriteMaps",
                newName: "IX_UserFavoriteMaps_MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMaps_Maps_MapId",
                table: "UserFavoriteMaps",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMaps_Users_UserId",
                table: "UserFavoriteMaps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMaps_Maps_MapId",
                table: "UserFavoriteMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMaps_Users_UserId",
                table: "UserFavoriteMaps");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "UserFavoriteMaps",
                newName: "FavoritedById");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFavoriteMaps",
                newName: "FavoriteMapsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMaps_MapId",
                table: "UserFavoriteMaps",
                newName: "IX_UserFavoriteMaps_FavoritedById");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMaps_Maps_FavoriteMapsId",
                table: "UserFavoriteMaps",
                column: "FavoriteMapsId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMaps_Users_FavoritedById",
                table: "UserFavoriteMaps",
                column: "FavoritedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
