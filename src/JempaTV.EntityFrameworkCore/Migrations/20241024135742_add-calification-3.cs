using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JempaTV.Migrations
{
    /// <inheritdoc />
    public partial class addcalification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCalification",
                table: "AppCalification");

            migrationBuilder.RenameTable(
                name: "AppCalification",
                newName: "AppCalifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCalifications",
                table: "AppCalifications",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCalifications",
                table: "AppCalifications");

            migrationBuilder.RenameTable(
                name: "AppCalifications",
                newName: "AppCalification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCalification",
                table: "AppCalification",
                column: "Id");
        }
    }
}
