using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_Users_UserId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMovies_Users_UserId",
                table: "UserFavoriteMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteMovies",
                table: "UserFavoriteMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteGenres",
                table: "UserFavoriteGenres");

            migrationBuilder.RenameTable(
                name: "UserFavoriteMovies",
                newName: "FavoriteMovie");

            migrationBuilder.RenameTable(
                name: "UserFavoriteGenres",
                newName: "FavoriteGenre");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMovies_UserId",
                table: "FavoriteMovie",
                newName: "IX_FavoriteMovie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMovies_MovieId",
                table: "FavoriteMovie",
                newName: "IX_FavoriteMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_UserId",
                table: "FavoriteGenre",
                newName: "IX_FavoriteGenre_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_GenreId",
                table: "FavoriteGenre",
                newName: "IX_FavoriteGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteMovie",
                table: "FavoriteMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteGenre",
                table: "FavoriteGenre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteGenre_Users_UserId",
                table: "FavoriteGenre",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteMovie_Users_UserId",
                table: "FavoriteMovie",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteGenre_Users_UserId",
                table: "FavoriteGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteMovie_Users_UserId",
                table: "FavoriteMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteMovie",
                table: "FavoriteMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteGenre",
                table: "FavoriteGenre");

            migrationBuilder.RenameTable(
                name: "FavoriteMovie",
                newName: "UserFavoriteMovies");

            migrationBuilder.RenameTable(
                name: "FavoriteGenre",
                newName: "UserFavoriteGenres");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteMovie_UserId",
                table: "UserFavoriteMovies",
                newName: "IX_UserFavoriteMovies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteMovie_MovieId",
                table: "UserFavoriteMovies",
                newName: "IX_UserFavoriteMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteGenre_UserId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteGenre_GenreId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteMovies",
                table: "UserFavoriteMovies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteGenres",
                table: "UserFavoriteGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_Users_UserId",
                table: "UserFavoriteGenres",
                column: "UserId",
                principalTable: "Users",
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
    }
}
