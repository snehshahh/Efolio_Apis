using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efolio_Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInLinkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Links",
                newName: "GLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GLink",
                table: "Links",
                newName: "Password");
        }
    }
}
