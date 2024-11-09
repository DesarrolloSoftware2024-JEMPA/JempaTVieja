using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JempaTV.Migrations
{
    /// <inheritdoc />
    public partial class addcalification5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calification_AppSeries_SerieId",
                table: "Calification");

            migrationBuilder.DropIndex(
                name: "IX_Calification_SerieId",
                table: "Calification");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Calification");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Calification");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Calification");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Calification");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "AppWatchLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CalificationId",
                table: "AppSeries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSeries_CalificationId",
                table: "AppSeries",
                column: "CalificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSeries_Calification_CalificationId",
                table: "AppSeries",
                column: "CalificationId",
                principalTable: "Calification",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSeries_Calification_CalificationId",
                table: "AppSeries");

            migrationBuilder.DropIndex(
                name: "IX_AppSeries_CalificationId",
                table: "AppSeries");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "AppWatchLists");

            migrationBuilder.DropColumn(
                name: "CalificationId",
                table: "AppSeries");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Calification",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Calification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Calification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Calification",
                type: "int",
                nullable: true);

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
    }
}
