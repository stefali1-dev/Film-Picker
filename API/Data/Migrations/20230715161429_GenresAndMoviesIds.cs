using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenresAndMoviesIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_IdObject_FavoriteGenresIdsId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_Users_AppUserId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMovies_IdObject_FavoriteMoviesIdsId",
                table: "UserFavoriteMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMovies_Users_AppUser1Id",
                table: "UserFavoriteMovies");

            migrationBuilder.DropTable(
                name: "IdObject");

            migrationBuilder.RenameColumn(
                name: "FavoriteMoviesIdsId",
                table: "UserFavoriteMovies",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AppUser1Id",
                table: "UserFavoriteMovies",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMovies_FavoriteMoviesIdsId",
                table: "UserFavoriteMovies",
                newName: "IX_UserFavoriteMovies_UserId");

            migrationBuilder.RenameColumn(
                name: "FavoriteGenresIdsId",
                table: "UserFavoriteGenres",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "UserFavoriteGenres",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_FavoriteGenresIdsId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_UserId");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_Genres_GenreId",
                table: "UserFavoriteGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_Users_UserId",
                table: "UserFavoriteGenres",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMovies_Movies_MovieId",
                table: "UserFavoriteMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMovies_Users_UserId",
                table: "UserFavoriteMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_Genres_GenreId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_Users_UserId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMovies_Movies_MovieId",
                table: "UserFavoriteMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMovies_Users_UserId",
                table: "UserFavoriteMovies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFavoriteMovies",
                newName: "FavoriteMoviesIdsId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "UserFavoriteMovies",
                newName: "AppUser1Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMovies_UserId",
                table: "UserFavoriteMovies",
                newName: "IX_UserFavoriteMovies_FavoriteMoviesIdsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFavoriteGenres",
                newName: "FavoriteGenresIdsId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "UserFavoriteGenres",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_UserId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_FavoriteGenresIdsId");

            migrationBuilder.CreateTable(
                name: "IdObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdObject", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_IdObject_FavoriteGenresIdsId",
                table: "UserFavoriteGenres",
                column: "FavoriteGenresIdsId",
                principalTable: "IdObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_Users_AppUserId",
                table: "UserFavoriteGenres",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMovies_IdObject_FavoriteMoviesIdsId",
                table: "UserFavoriteMovies",
                column: "FavoriteMoviesIdsId",
                principalTable: "IdObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMovies_Users_AppUser1Id",
                table: "UserFavoriteMovies",
                column: "AppUser1Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
