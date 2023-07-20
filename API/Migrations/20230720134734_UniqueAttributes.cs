using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UniqueAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMovies_MovieId",
                table: "UserFavoriteMovies",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteGenres_GenreId",
                table: "UserFavoriteGenres",
                column: "GenreId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFavoriteMovies_MovieId",
                table: "UserFavoriteMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserFavoriteGenres_GenreId",
                table: "UserFavoriteGenres");
        }
    }
}
