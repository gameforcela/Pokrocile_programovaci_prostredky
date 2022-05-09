using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokrocile_programovaci_prostredky.Api.Migrations
{
    public partial class AddUkony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ukons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PriceCzk = table.Column<double>(type: "REAL", nullable: false),
                    OutPutGood = table.Column<bool>(type: "INTEGER", nullable: false),
                    VybaveniId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ukons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ukons_Vybavenis_VybaveniId",
                        column: x => x.VybaveniId,
                        principalTable: "Vybavenis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "DateTime", "Name", "OutPutGood", "PriceCzk", "VybaveniId" },
                values: new object[] { new Guid("01e35d41-f75a-49b6-974b-1f1c85117ecf"), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EEG", true, 22222.0, new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "DateTime", "Name", "OutPutGood", "PriceCzk", "VybaveniId" },
                values: new object[] { new Guid("37306475-6e31-41d4-96e7-88810012bfd8"), new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozáření", false, 555555555555.0, new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "DateTime", "Name", "OutPutGood", "PriceCzk", "VybaveniId" },
                values: new object[] { new Guid("46ea0db9-bfaf-4bda-b9fc-d8f11359730c"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opalování", false, 100.0, new Guid("7ec0f0ce-45ee-43a9-87c2-0e234c874f06") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "DateTime", "Name", "OutPutGood", "PriceCzk", "VybaveniId" },
                values: new object[] { new Guid("6bd0a8a9-4e86-4db1-b22c-fcaa746fc6b7"), new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Depilace", true, 124577.0, new Guid("442a4ca6-e703-427e-a07b-a70619d5d3bd") });

            migrationBuilder.InsertData(
                table: "Ukons",
                columns: new[] { "Id", "DateTime", "Name", "OutPutGood", "PriceCzk", "VybaveniId" },
                values: new object[] { new Guid("b5f9d6be-6fec-4286-a66f-60aefbb92ee6"), new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Centerifuga", true, 10000000.0, new Guid("4d2fb71e-658a-4cda-b279-88ad33d6057a") });

            migrationBuilder.CreateIndex(
                name: "IX_Ukons_VybaveniId",
                table: "Ukons",
                column: "VybaveniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ukons");
        }
    }
}
