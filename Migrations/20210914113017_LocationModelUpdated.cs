using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class LocationModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndLocationId",
                table: "PackageModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartLocationId",
                table: "PackageModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Voivodeship = table.Column<string>(type: "TEXT", nullable: true),
                    PostCode = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_EndLocationId",
                table: "PackageModel",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_StartLocationId",
                table: "PackageModel",
                column: "StartLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageModel_LocationModel_EndLocationId",
                table: "PackageModel",
                column: "EndLocationId",
                principalTable: "LocationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageModel_LocationModel_StartLocationId",
                table: "PackageModel",
                column: "StartLocationId",
                principalTable: "LocationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageModel_LocationModel_EndLocationId",
                table: "PackageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageModel_LocationModel_StartLocationId",
                table: "PackageModel");

            migrationBuilder.DropTable(
                name: "LocationModel");

            migrationBuilder.DropIndex(
                name: "IX_PackageModel_EndLocationId",
                table: "PackageModel");

            migrationBuilder.DropIndex(
                name: "IX_PackageModel_StartLocationId",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "EndLocationId",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "StartLocationId",
                table: "PackageModel");
        }
    }
}
