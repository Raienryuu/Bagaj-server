using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class NewPackageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Packages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimensions",
                table: "Packages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SenderHelp",
                table: "Packages",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SenderHelp",
                table: "Packages");
        }
    }
}
