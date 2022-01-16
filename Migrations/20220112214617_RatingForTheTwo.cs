using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class RatingForTheTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Ratings",
                newName: "RatedByTransporter");

            migrationBuilder.AddColumn<float>(
                name: "RatedBySender",
                table: "Ratings",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatedBySender",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "RatedByTransporter",
                table: "Ratings",
                newName: "Rating");
        }
    }
}
