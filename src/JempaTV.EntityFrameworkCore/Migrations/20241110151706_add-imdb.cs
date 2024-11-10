using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JempaTV.Migrations
{
    /// <inheritdoc />
    public partial class addimdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ImdbRating",
                table: "AppSeries",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "AppSeries");
        }
    }
}
