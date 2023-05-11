using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efolio_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Projectss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Logins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Links",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Experiences",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Projectss");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Experiences");
        }
    }
}
