using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class SeedsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mechanics_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RegNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineSize = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_FuelTypes_FuelId",
                        column: x => x.FuelId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_TransmissionTypes_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "cfdf857d-e553-4c89-bc48-b5f31621e740", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAENNr1+EFsWSChazWLpwOVRK90Ci5vXGf6gT/vMt/lBvMm2+uhP11Glg4VtFLTfYd0A==", null, false, "dcb29c3f-b970-4e16-a1c5-a790fe59898b", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "12bb040f-75a0-4404-bf2d-6927a2ddb8ee", "dealer@mail.com", false, false, null, "dealer@mail.com", "dealer@mail.com", "AQAAAAEAACcQAAAAEKLzy6TxiCtEOQ+OkbM5uRDPuT4G4RyaWwWXAfjtr8hWEHAJVQG5K+kJR7H/4Sey+g==", null, false, "4f7bc2f2-e977-450c-9d9d-8c76c147f13f", false, "dealer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hatchback" },
                    { 2, "Estate" },
                    { 3, "SUV" },
                    { 4, "Saloon" },
                    { 5, "Coupe" },
                    { 6, "Convertible" },
                    { 7, "Pickup" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Petrol" },
                    { 2, "Diesel" },
                    { 3, "Electric" },
                    { 4, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "GarageName" },
                values: new object[] { 1, "AutoGarage" });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "FirstName", "GarageId", "LastName", "Rating" },
                values: new object[,]
                {
                    { 1, "Pesho", null, "Petrov", 10.00m },
                    { 2, "Gosho", null, "Petkov", 8.25m },
                    { 3, "Ivelin", null, "Radev", 9.60m }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "GarageId", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, null, 180.00m, "Engine Oil and Filters" },
                    { 2, null, 600.00m, "Tyres" },
                    { 3, null, 50.00m, "MOT" },
                    { 4, null, 250.00m, "Windscreen" },
                    { 5, null, 750.00m, "Timming Belt" },
                    { 6, null, 1300.00m, "Clutch" },
                    { 7, null, 300.00m, "Cooling System" },
                    { 8, null, 1000.00m, "Fuel Pump and Turbo" },
                    { 9, null, 200.00m, "Battery" },
                    { 10, null, 400.00m, "Suspension" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "Description", "EngineId", "EngineSize", "FuelId", "HorsePower", "ImageUrl", "Make", "Model", "Price", "RegNumber", "TransmissionId", "Year" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 4, "Silver", 1, "The car is in perfect condition!", "MBWWXXVV8777", 2200, 2, 231, "https://www.gcs-germancarspecialist.co.uk/photos/10790/22713893-471d-41d8-b47a-9069e1d15840_i800x600.jpg", "Mercedes-Benz", "E220 AMG Sport", 24000.00m, "EF14XAE", 2, 2014 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "Description", "EngineId", "EngineSize", "FuelId", "HorsePower", "ImageUrl", "Make", "Model", "Price", "RegNumber", "TransmissionId", "Year" },
                values: new object[] { 2, null, 2, "Black", 1, "There is a scratch on rear bumper but overall the car is a great runner", "BMWWXXVV8777", 3000, 2, 250, "https://vcache.arnoldclark.com/imageserver/ACRFNV0147DA-S-/800/f", "BMW", "530d XDrive", 40000.00m, "SA71VFC", 2, 2021 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "Description", "EngineId", "EngineSize", "FuelId", "HorsePower", "ImageUrl", "Make", "Model", "Price", "RegNumber", "TransmissionId", "Year" },
                values: new object[] { 3, null, 3, "White", 1, "Very good and reliable SUV with 7 seats. This is a perfect family car!", "CCWWXXVV8777", 2000, 1, 160, "https://images.clickdealer.co.uk/vehicles/4556/4556096/large2/102784640.jpg", "Chevrolet", "Captiva LT", 13000.00m, "WF12GZC", 1, 2021 });

            

            

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BuyerId",
                table: "Cars",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DealerId",
                table: "Cars",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId",
                table: "Cars",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanics_GarageId",
                table: "Mechanics",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_GarageId",
                table: "Services",
                column: "GarageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
