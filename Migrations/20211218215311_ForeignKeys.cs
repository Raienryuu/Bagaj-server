using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Packages_FK_PackageId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_FK_UserId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Bids_FK_Lowest_BidId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_FK_UserId1",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_FK_UserId2",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Packages_FK_PackageId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_FK_SenderId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_FK_TransporterId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_FK_UserId",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_Packages_FK_Lowest_BidId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_FK_UserId1",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_FK_UserId2",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "FK_Lowest_BidId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "FK_UserId2",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "FK_UserId",
                table: "UserSessions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSessions_FK_UserId",
                table: "UserSessions",
                newName: "IX_UserSessions_UserId");

            migrationBuilder.RenameColumn(
                name: "FK_TransporterId",
                table: "Ratings",
                newName: "TransporterId");

            migrationBuilder.RenameColumn(
                name: "FK_SenderId",
                table: "Ratings",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "FK_PackageId",
                table: "Ratings",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_FK_TransporterId",
                table: "Ratings",
                newName: "IX_Ratings_TransporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_FK_SenderId",
                table: "Ratings",
                newName: "IX_Ratings_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_FK_PackageId",
                table: "Ratings",
                newName: "IX_Ratings_PackageId");

            migrationBuilder.RenameColumn(
                name: "FK_UserId1",
                table: "Packages",
                newName: "TransporterId");

            migrationBuilder.RenameColumn(
                name: "FK_UserId",
                table: "Bids",
                newName: "PackageId");

            migrationBuilder.RenameColumn(
                name: "FK_PackageId",
                table: "Bids",
                newName: "BidderId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_FK_UserId",
                table: "Bids",
                newName: "IX_Bids_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_FK_PackageId",
                table: "Bids",
                newName: "IX_Bids_BidderId");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserSessions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "LowestBidId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "OYQ+xy+ILeo9tXmeT+/vNhDxnlNAl5KWXp25yeIE70/dWqjfSyRo/Xrtkoi8HEOm9WrTDXYhdxONT5CLOmJLcg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "R7WDCLmMmLg71VR+F1S4CNCc2OCOhuxxs5RHcxOO5gtInrMrVTwyI68SGNk1eZleRQckSe7oKsSgyNi26XQ0VA==");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SenderId",
                table: "Packages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Packages_PackageId",
                table: "Bids",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_BidderId",
                table: "Bids",
                column: "BidderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_SenderId",
                table: "Packages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Packages_PackageId",
                table: "Ratings",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_SenderId",
                table: "Ratings",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_TransporterId",
                table: "Ratings",
                column: "TransporterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_UserId",
                table: "UserSessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Packages_PackageId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_BidderId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_SenderId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Packages_PackageId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_SenderId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_TransporterId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_UserId",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SenderId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "LowestBidId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSessions",
                newName: "FK_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                newName: "IX_UserSessions_FK_UserId");

            migrationBuilder.RenameColumn(
                name: "TransporterId",
                table: "Ratings",
                newName: "FK_TransporterId");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Ratings",
                newName: "FK_SenderId");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Ratings",
                newName: "FK_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TransporterId",
                table: "Ratings",
                newName: "IX_Ratings_FK_TransporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_SenderId",
                table: "Ratings",
                newName: "IX_Ratings_FK_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_PackageId",
                table: "Ratings",
                newName: "IX_Ratings_FK_PackageId");

            migrationBuilder.RenameColumn(
                name: "TransporterId",
                table: "Packages",
                newName: "FK_UserId1");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Bids",
                newName: "FK_UserId");

            migrationBuilder.RenameColumn(
                name: "BidderId",
                table: "Bids",
                newName: "FK_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_PackageId",
                table: "Bids",
                newName: "IX_Bids_FK_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_BidderId",
                table: "Bids",
                newName: "IX_Bids_FK_PackageId");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserSessions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_Lowest_BidId",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_UserId2",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "haslo1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "haslo2");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Packages_FK_PackageId",
                table: "Bids",
                column: "FK_PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_FK_UserId",
                table: "Bids",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_FK_UserId1",
                table: "Packages",
                column: "FK_UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_FK_UserId2",
                table: "Packages",
                column: "FK_UserId2",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Packages_FK_PackageId",
                table: "Ratings",
                column: "FK_PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_FK_SenderId",
                table: "Ratings",
                column: "FK_SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_FK_TransporterId",
                table: "Ratings",
                column: "FK_TransporterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_FK_UserId",
                table: "UserSessions",
                column: "FK_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
