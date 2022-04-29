using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class novedata3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(2019, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "dsdfegfg" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "fffff" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(2017, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "defdgdvdce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("1754100a-54e7-4f14-a6aa-e23e09629ec1"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("b21ec945-0b43-42b7-b900-900a95b1556b"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("c1287015-5d0c-4d87-bc3c-2170d64f1538"),
                columns: new[] { "DateTime", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });
        }
    }
}
