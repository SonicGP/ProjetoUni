using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capitulo01.Migrations
{
    public partial class FotoAcademico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoMimeType",
                table: "Academicos",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "foto",
                table: "Academicos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoMimeType",
                table: "Academicos");

            migrationBuilder.DropColumn(
                name: "foto",
                table: "Academicos");
        }
    }
}
