using Microsoft.EntityFrameworkCore.Migrations;

namespace bAPI.Migrations
{
    public partial class UpdatedUserDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: -1f);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactInfo",
                value: "berries11@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContactInfo",
                value: "mousepaul@yahoo.com");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name_Lastname",
                table: "Users",
                columns: new[] { "Name", "Lastname" });

            migrationBuilder.CreateIndex(
                name: "Unique_login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Name_Lastname",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "Unique_login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");
        }
    }
}
