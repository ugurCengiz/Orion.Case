using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orion.Case.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTelephoneDirectoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TelephoneDirectories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TelephoneDirectories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TelephoneDirectories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TelephoneDirectories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TelephoneDirectories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TelephoneDirectories");
        }
    }
}
