using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class CarIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Bookings");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "db0e1823-f687-4470-a8ff-b114ecce6c47", "AQAAAAEAACcQAAAAEG4jICpjF+z3kKO7xf1XyjTpHbtMFUqaXHSKR8bM8Ut9K9HyD+KcLzt05hWdCdCZrQ==", "42273a5a-aba2-4021-aaeb-76bf09320808" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "27ec1bc7-8551-4727-b5b9-bbd22a27a814", "AQAAAAEAACcQAAAAEK4800oe/swXtX/HH4+4Obuk9XfNzMjBwLxI8HfIg+eHOT9+aPOlUud9SplhUtXLwQ==", "af59de78-d726-4880-852c-3f0120a93cbb" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

            //migrationBuilder.CreateTable(
            //    name: "Bookings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CarId = table.Column<int>(type: "int", nullable: false),
            //        DealerId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bookings", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Bookings_Cars_CarId",
            //            column: x => x.CarId,
            //            principalTable: "Cars",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Bookings_Dealers_DealerId",
            //            column: x => x.DealerId,
            //            principalTable: "Dealers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfdf857d-e553-4c89-bc48-b5f31621e740", "AQAAAAEAACcQAAAAENNr1+EFsWSChazWLpwOVRK90Ci5vXGf6gT/vMt/lBvMm2+uhP11Glg4VtFLTfYd0A==", "dcb29c3f-b970-4e16-a1c5-a790fe59898b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12bb040f-75a0-4404-bf2d-6927a2ddb8ee", "AQAAAAEAACcQAAAAEKLzy6TxiCtEOQ+OkbM5uRDPuT4G4RyaWwWXAfjtr8hWEHAJVQG5K+kJR7H/4Sey+g==", "4f7bc2f2-e977-450c-9d9d-8c76c147f13f" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookings_CarId",
            //    table: "Bookings",
            //    column: "CarId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookings_DealerId",
            //    table: "Bookings",
            //    column: "DealerId");
        }
    }
}
