using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Revizes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniDataID" },
                values: new object[] { new Guid("23457a2a-2570-41e6-85cb-41a2dff0ea74"), new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "dvojice", new Guid("555242cb-c93a-4f71-9350-eeb58c681e13") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniDataID" },
                values: new object[] { new Guid("9161e045-df3b-4e7e-a067-ddfc2c6dd083"), new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahojjjjdvdce", new Guid("555242cb-c93a-4f71-9350-eeb58c681e13") });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd"), new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "yyfddgdsgdsfdsyy", 222220.0 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06"), new DateTime(2015, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "yyyyfdfdsfdfdsfy", 66666.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("23457a2a-2570-41e6-85cb-41a2dff0ea74"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("9161e045-df3b-4e7e-a067-ddfc2c6dd083"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Revizes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
