using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class AddUkon4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukons_Vybavenis_VybaveniId",
                table: "Ukons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ukons",
                table: "Ukons");

            migrationBuilder.RenameTable(
                name: "Ukons",
                newName: "Ukonis");

            migrationBuilder.RenameIndex(
                name: "IX_Ukons_VybaveniId",
                table: "Ukonis",
                newName: "IX_Ukonis_VybaveniId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ukonis",
                table: "Ukonis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukonis_Vybavenis_VybaveniId",
                table: "Ukonis",
                column: "VybaveniId",
                principalTable: "Vybavenis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukonis_Vybavenis_VybaveniId",
                table: "Ukonis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ukonis",
                table: "Ukonis");

            migrationBuilder.RenameTable(
                name: "Ukonis",
                newName: "Ukons");

            migrationBuilder.RenameIndex(
                name: "IX_Ukonis_VybaveniId",
                table: "Ukons",
                newName: "IX_Ukons_VybaveniId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ukons",
                table: "Ukons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukons_Vybavenis_VybaveniId",
                table: "Ukons",
                column: "VybaveniId",
                principalTable: "Vybavenis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
