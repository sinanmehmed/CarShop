using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class EngineIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4076f12d-a2d9-4105-9434-7758bad90b1a", "AQAAAAEAACcQAAAAEKnHCGdk6Z/BCEQ7TlhwQQbRntfrQNueRu/fXfc4m0fzsBy1dfZFJiRH2BXVCNhekw==", "172fd9e5-0c3d-4257-97c0-3fe292e3e0aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12961fe4-5bcd-45fd-8bf8-e7e56f1652e3", "AQAAAAEAACcQAAAAEPiI7yiBjjgaD6QdtHtxmteEHSoW2QeeOI6qeYf7HK5hy1HU3EVV6iW257PW47B2Gw==", "5330fe1b-4dda-4a1a-8376-d37816ecad40" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngineId",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db0e1823-f687-4470-a8ff-b114ecce6c47", "AQAAAAEAACcQAAAAEG4jICpjF+z3kKO7xf1XyjTpHbtMFUqaXHSKR8bM8Ut9K9HyD+KcLzt05hWdCdCZrQ==", "42273a5a-aba2-4021-aaeb-76bf09320808" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ec1bc7-8551-4727-b5b9-bbd22a27a814", "AQAAAAEAACcQAAAAEK4800oe/swXtX/HH4+4Obuk9XfNzMjBwLxI8HfIg+eHOT9+aPOlUud9SplhUtXLwQ==", "af59de78-d726-4880-852c-3f0120a93cbb" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "EngineId",
                value: "MBWWXXVV8777");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "EngineId",
                value: "BMWWXXVV8777");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "EngineId",
                value: "CCWWXXVV8777");
        }
    }
}
