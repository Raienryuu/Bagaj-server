using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class Update2PackageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PackageModel",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LowestBidId",
                table: "PackageModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferState",
                table: "PackageModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BidModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    BidderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BidValue = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_LowestBidId",
                table: "PackageModel",
                column: "LowestBidId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageModel_BidModel_LowestBidId",
                table: "PackageModel",
                column: "LowestBidId",
                principalTable: "BidModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageModel_BidModel_LowestBidId",
                table: "PackageModel");

            migrationBuilder.DropTable(
                name: "BidModel");

            migrationBuilder.DropIndex(
                name: "IX_PackageModel_LowestBidId",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LowestBidId",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "OfferState",
                table: "PackageModel");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "PackageModel",
                newName: "Price");

        }
    }
}
