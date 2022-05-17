using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class pracovnici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PracovniciId",
                table: "Ukonis",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pracovnicis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracovnicis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ukonis_PracovniciId",
                table: "Ukonis",
                column: "PracovniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukonis_Pracovnicis_PracovniciId",
                table: "Ukonis",
                column: "PracovniciId",
                principalTable: "Pracovnicis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukonis_Pracovnicis_PracovniciId",
                table: "Ukonis");

            migrationBuilder.DropTable(
                name: "Pracovnicis");

            migrationBuilder.DropIndex(
                name: "IX_Ukonis_PracovniciId",
                table: "Ukonis");

            migrationBuilder.DropColumn(
                name: "PracovniciId",
                table: "Ukonis");
        }
    }
}
