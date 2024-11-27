using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JempaTV.Migrations
{
    /// <inheritdoc />
    public partial class addwatchlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WatchListId",
                table: "AppSeries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppWatchLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWatchLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSeries_WatchListId",
                table: "AppSeries",
                column: "WatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSeries_AppWatchLists_WatchListId",
                table: "AppSeries",
                column: "WatchListId",
                principalTable: "AppWatchLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSeries_AppWatchLists_WatchListId",
                table: "AppSeries");

            migrationBuilder.DropTable(
                name: "AppWatchLists");

            migrationBuilder.DropIndex(
                name: "IX_AppSeries_WatchListId",
                table: "AppSeries");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "AppSeries");
        }
    }
}
