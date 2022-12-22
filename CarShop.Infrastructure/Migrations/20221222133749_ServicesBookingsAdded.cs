using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class ServicesBookingsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceBookings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "566317ea-3d59-4921-8fc5-e6eeaac5ce3e", "AQAAAAEAACcQAAAAEFRmpaek3p7oRuMqLwjoeY7xIB9QANL8L5WecXnNBiNZFifpJMsdXtOr2l7baREVhQ==", "4671a74a-406b-4ac5-a0e5-3848ea50fba9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d9b3926-1736-4567-9022-1979e2f7af02", "AQAAAAEAACcQAAAAEMx410gpGTtUiRahscK9hUUiaBkWq20bWLwtgnCWfUAeXld/HyMZtvYF8rB/eFQOkQ==", "92f47824-81a1-4175-b3fd-b9921ab4f94e" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_CarId",
                table: "ServiceBookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_GarageId",
                table: "ServiceBookings",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_MechanicId",
                table: "ServiceBookings",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_ServiceId",
                table: "ServiceBookings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookings_UserId",
                table: "ServiceBookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceBookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f6c07f8-f1d7-45e3-876f-1b1603f317d6", "AQAAAAEAACcQAAAAEDwElZ3GQIuisox7qkXcX4K5cWlfCGIlEhZXU74w9KG5TaJZSrX/yJJA1bDVgxYVQg==", "c546abee-72f6-4d3e-89a5-0d0f3c349b27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "311a8239-c829-4e06-9b2a-e36fc4357861", "AQAAAAEAACcQAAAAECqkLtBDSjpsiKvZ6T3hb0SMwya83mPJmEh7LHRrnzCCWRGlDPoiiXnaga+vKjNf/A==", "d1a0814c-e507-430e-be9e-cbaeaa808129" });
        }
    }
}
