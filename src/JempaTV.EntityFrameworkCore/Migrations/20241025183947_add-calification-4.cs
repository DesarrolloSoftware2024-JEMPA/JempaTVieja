using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JempaTV.Migrations
{
    /// <inheritdoc />
    public partial class addcalification4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCalifications",
                table: "AppCalifications");

            migrationBuilder.RenameTable(
                name: "AppCalifications",
                newName: "Calification");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Calification",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Calification",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "idSerie",
                table: "Calification",
                newName: "IdSerie");

            migrationBuilder.RenameColumn(
                name: "comentario",
                table: "Calification",
                newName: "Comentario");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Calification",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Calification",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calification",
                table: "Calification",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Calification_SerieId",
                table: "Calification",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calification_AppSeries_SerieId",
                table: "Calification",
                column: "SerieId",
                principalTable: "AppSeries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calification_AppSeries_SerieId",
                table: "Calification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calification",
                table: "Calification");

            migrationBuilder.DropIndex(
                name: "IX_Calification_SerieId",
                table: "Calification");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Calification");

            migrationBuilder.RenameTable(
                name: "Calification",
                newName: "AppCalifications");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "AppCalifications",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "AppCalifications",
                newName: "idUsuario");

            migrationBuilder.RenameColumn(
                name: "IdSerie",
                table: "AppCalifications",
                newName: "idSerie");

            migrationBuilder.RenameColumn(
                name: "Comentario",
                table: "AppCalifications",
                newName: "comentario");

            migrationBuilder.AlterColumn<string>(
                name: "comentario",
                table: "AppCalifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCalifications",
                table: "AppCalifications",
                column: "Id");
        }
    }
}
