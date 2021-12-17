using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class RemovedLocationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "EndCity",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndPostCode",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndStreetAddress",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndVoivodeship",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartCity",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartPostCode",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartStreetAddress",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartVoivodeship",
                table: "PackageModel",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndCity",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "EndPostCode",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "EndStreetAddress",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "EndVoivodeship",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "StartCity",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "StartPostCode",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "StartStreetAddress",
                table: "PackageModel");

            migrationBuilder.DropColumn(
                name: "StartVoivodeship",
                table: "PackageModel");

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
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostCode = table.Column<string>(type: "TEXT", nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Voivodeship = table.Column<string>(type: "TEXT", nullable: true)
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
    }
}
