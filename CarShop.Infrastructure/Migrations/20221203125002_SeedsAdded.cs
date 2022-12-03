using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class SeedsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_IdentityUser_UserId",
                table: "Dealers");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19dcb041-e57a-43cb-8410-a36bdc30cfa9", "AQAAAAEAACcQAAAAED9VhnkarcsZ8ApunxZssIW4gt4iDeBLLgvaEcwMvpLZhzhLRHIJwjPg+XiDgtSQNg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4f85ffd-6321-41ff-9c8b-55669c394635", "AQAAAAEAACcQAAAAEAnqJ90nNzpXhzVgAP+Wm38kQZH1kPdiTPnZ3Qg20e9mrmxfUoGTwp+TrVgkLJ5fig==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId",
                table: "Dealers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId",
                table: "Dealers");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae12045f-bdce-4404-ba75-8de7a1e37cce", "AQAAAAEAACcQAAAAELjcnF82JA6kGr2krGJen73+yIlmZeNyn/QmhmUhWxrV5EXhH7/F561Z+pr3K/fmNw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f8f102c-2fe4-463f-b84f-88afe8f86ccd", "AQAAAAEAACcQAAAAEKgxdgFarP7sQRBzIf8aNHJyqrY+na6ymdKFkKm6zeRq2ObynFrR2NoXSDklZKBeHA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_IdentityUser_UserId",
                table: "Dealers",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
