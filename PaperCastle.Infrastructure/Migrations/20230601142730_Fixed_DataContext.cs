using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaperCastle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_DataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookshelf_ApplicationUsers_ApplicationUserId",
                table: "Bookshelf");

            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBooks_Bookshelf_BookshelfId",
                table: "BookshelfBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ApplicationUsers_ApplicationUserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookshelf",
                table: "Bookshelf");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Bookshelf",
                newName: "Bookshelves");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookId",
                table: "Reviews",
                newName: "IX_Reviews_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ApplicationUserId",
                table: "Reviews",
                newName: "IX_Reviews_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookshelf_ApplicationUserId",
                table: "Bookshelves",
                newName: "IX_Bookshelves_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookshelves",
                table: "Bookshelves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBooks_Bookshelves_BookshelfId",
                table: "BookshelfBooks",
                column: "BookshelfId",
                principalTable: "Bookshelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookshelves_ApplicationUsers_ApplicationUserId",
                table: "Bookshelves",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBooks_Bookshelves_BookshelfId",
                table: "BookshelfBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookshelves_ApplicationUsers_ApplicationUserId",
                table: "Bookshelves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookshelves",
                table: "Bookshelves");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Bookshelves",
                newName: "Bookshelf");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookId",
                table: "Review",
                newName: "IX_Review_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Review",
                newName: "IX_Review_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookshelves_ApplicationUserId",
                table: "Bookshelf",
                newName: "IX_Bookshelf_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookshelf",
                table: "Bookshelf",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookshelf_ApplicationUsers_ApplicationUserId",
                table: "Bookshelf",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBooks_Bookshelf_BookshelfId",
                table: "BookshelfBooks",
                column: "BookshelfId",
                principalTable: "Bookshelf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ApplicationUsers_ApplicationUserId",
                table: "Review",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
