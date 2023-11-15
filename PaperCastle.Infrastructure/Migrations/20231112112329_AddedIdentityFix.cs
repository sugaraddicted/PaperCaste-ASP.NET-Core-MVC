using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaperCastle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookshelves_Users_ApplicationUserId",
                table: "Bookshelves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_ApplicationUserId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendsId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "IdentityUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_IdentityUser_Id",
                        column: x => x.Id,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CountryId",
                table: "ApplicationUser",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookshelves_ApplicationUser_ApplicationUserId",
                table: "Bookshelves",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUser_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_ApplicationUser_ApplicationUserId",
                table: "UserFriends",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_ApplicationUser_FriendsId",
                table: "UserFriends",
                column: "FriendsId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookshelves_ApplicationUser_ApplicationUserId",
                table: "Bookshelves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUser_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_ApplicationUser_ApplicationUserId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_ApplicationUser_FriendsId",
                table: "UserFriends");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookshelves_Users_ApplicationUserId",
                table: "Bookshelves",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_ApplicationUserId",
                table: "UserFriends",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendsId",
                table: "UserFriends",
                column: "FriendsId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
