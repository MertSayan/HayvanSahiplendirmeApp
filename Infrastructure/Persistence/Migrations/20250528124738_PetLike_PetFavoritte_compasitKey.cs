using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PetLike_PetFavoritte_compasitKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetLikes",
                table: "PetLikes");

            migrationBuilder.DropIndex(
                name: "IX_PetLikes_PetId",
                table: "PetLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetFavorites",
                table: "PetFavorites");

            migrationBuilder.DropIndex(
                name: "IX_PetFavorites_PetId",
                table: "PetFavorites");

            migrationBuilder.DropColumn(
                name: "PetLikeId",
                table: "PetLikes");

            migrationBuilder.DropColumn(
                name: "PetFavoritteId",
                table: "PetFavorites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetLikes",
                table: "PetLikes",
                columns: new[] { "PetId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetFavorites",
                table: "PetFavorites",
                columns: new[] { "PetId", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetLikes",
                table: "PetLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetFavorites",
                table: "PetFavorites");

            migrationBuilder.AddColumn<int>(
                name: "PetLikeId",
                table: "PetLikes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PetFavoritteId",
                table: "PetFavorites",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetLikes",
                table: "PetLikes",
                column: "PetLikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetFavorites",
                table: "PetFavorites",
                column: "PetFavoritteId");

            migrationBuilder.CreateIndex(
                name: "IX_PetLikes_PetId",
                table: "PetLikes",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetFavorites_PetId",
                table: "PetFavorites",
                column: "PetId");
        }
    }
}
