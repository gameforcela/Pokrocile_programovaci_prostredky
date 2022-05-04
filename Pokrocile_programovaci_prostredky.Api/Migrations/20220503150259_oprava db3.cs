using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class opravadb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniDataID",
                table: "Revizes");

            migrationBuilder.RenameColumn(
                name: "VybaveniDataID",
                table: "Revizes",
                newName: "VybaveniId");

            migrationBuilder.RenameIndex(
                name: "IX_Revizes_VybaveniDataID",
                table: "Revizes",
                newName: "IX_Revizes_VybaveniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniId",
                table: "Revizes",
                column: "VybaveniId",
                principalTable: "Vybavenis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniId",
                table: "Revizes");

            migrationBuilder.RenameColumn(
                name: "VybaveniId",
                table: "Revizes",
                newName: "VybaveniDataID");

            migrationBuilder.RenameIndex(
                name: "IX_Revizes_VybaveniId",
                table: "Revizes",
                newName: "IX_Revizes_VybaveniDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniDataID",
                table: "Revizes",
                column: "VybaveniDataID",
                principalTable: "Vybavenis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
