using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class novedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Revizes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a"), new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "XXX", 500.0 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("555242cb-c93a-4f71-9350-eeb58c681e13"), new DateTime(2017, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "yyyyy", 20.0 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37"), new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZZZZ", 100.0 });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniDataID" },
                values: new object[] { new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniDataID" },
                values: new object[] { new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniDataID" },
                values: new object[] { new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("555242cb-c93a-4f71-9350-eeb58c681e13") });

            migrationBuilder.AddForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniDataID",
                table: "Revizes",
                column: "VybaveniDataID",
                principalTable: "Vybavenis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revizes_Vybavenis_VybaveniDataID",
                table: "Revizes");

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("555242cb-c93a-4f71-9350-eeb58c681e13"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("bc541f54-965f-45b2-a18b-aacf68e81c37"));

            migrationBuilder.DropColumn(
                name: "DateTime",
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
    }
}
