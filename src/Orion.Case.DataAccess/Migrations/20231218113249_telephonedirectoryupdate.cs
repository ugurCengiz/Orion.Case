using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orion.Case.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class telephonedirectoryupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUser",
                table: "TelephoneDirectories",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedUser",
                table: "TelephoneDirectories",
                newName: "CreatedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "TelephoneDirectories",
                newName: "UpdatedUser");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "TelephoneDirectories",
                newName: "CreatedUser");
        }
    }
}
