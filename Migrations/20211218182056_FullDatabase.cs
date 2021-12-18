using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace bAPI.Migrations
{
    public partial class FullDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSessions",
                newName: "FK_UserId");

            migrationBuilder.RenameIndex(
                name: "Unique_login",
                table: "Users",
                newName: "IX_Users_Login");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserSessions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactInfo",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_UserId1 = table.Column<int>(type: "integer", nullable: false),
                    FK_UserId2 = table.Column<int>(type: "integer", nullable: true),
                    StartVoivodeship = table.Column<string>(type: "text", nullable: true),
                    StartPostCode = table.Column<string>(type: "text", nullable: true),
                    StartCity = table.Column<string>(type: "text", nullable: true),
                    StartStreetAddress = table.Column<string>(type: "text", nullable: true),
                    EndVoivodeship = table.Column<string>(type: "text", nullable: true),
                    EndPostCode = table.Column<string>(type: "text", nullable: true),
                    EndCity = table.Column<string>(type: "text", nullable: true),
                    EndStreetAddress = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    FK_Lowest_BidId = table.Column<int>(type: "integer", nullable: true),
                    OfferState = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Users_FK_UserId1",
                        column: x => x.FK_UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Users_FK_UserId2",
                        column: x => x.FK_UserId2,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_PackageId = table.Column<int>(type: "integer", nullable: false),
                    FK_UserId = table.Column<int>(type: "integer", nullable: false),
                    BidValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Packages_FK_PackageId",
                        column: x => x.FK_PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FK_SenderId = table.Column<int>(type: "integer", nullable: false),
                    FK_PackageId = table.Column<int>(type: "integer", nullable: false),
                    FK_TransporterId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Packages_FK_PackageId",
                        column: x => x.FK_PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_FK_SenderId",
                        column: x => x.FK_SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_FK_TransporterId",
                        column: x => x.FK_TransporterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_FK_UserId",
                table: "UserSessions",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_Token",
                table: "UserSessions",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_FK_PackageId",
                table: "Bids",
                column: "FK_PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_FK_UserId",
                table: "Bids",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FK_Lowest_BidId",
                table: "Packages",
                column: "FK_Lowest_BidId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FK_UserId1",
                table: "Packages",
                column: "FK_UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FK_UserId2",
                table: "Packages",
                column: "FK_UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FK_PackageId",
                table: "Ratings",
                column: "FK_PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FK_SenderId",
                table: "Ratings",
                column: "FK_SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FK_TransporterId",
                table: "Ratings",
                column: "FK_TransporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_FK_UserId",
                table: "UserSessions",
                column: "FK_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Bids_FK_Lowest_BidId",
                table: "Packages",
                column: "FK_Lowest_BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_FK_UserId",
                table: "UserSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Packages_FK_PackageId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_UserSessions_FK_UserId",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserSessions_Token",
                table: "UserSessions");

            migrationBuilder.RenameColumn(
                name: "FK_UserId",
                table: "UserSessions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Login",
                table: "Users",
                newName: "Unique_login");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserSessions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ContactInfo",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
