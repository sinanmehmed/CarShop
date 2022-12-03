using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Infrastructure.Migrations
{
    public partial class SeedsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "Mechanic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RegNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineSize = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    TransmissionType = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "60f33a53-14dc-4ab1-b03f-751b817c7087", "guest@mail.com", false, null, true, null, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEB7mxUDU8mFcwaUfe3Q3nZ6PevGLj3mxIxlmCZ/7qxEa5DBvN0bUAIBMgiWBVlUOqg==", null, false, null, false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b0f26eab-5fb0-40bd-95f9-527671d62bd5", "dealer@mail.com", false, null, true, null, false, null, "dealer@mail.com", "dealer@mail.com", "AQAAAAEAACcQAAAAEFKcnVzMMRgTU1XMIDYNR4w99f/DgIxdHY93kfr1vWTnR+CkXZfcsgPIjtjZ6pry0g==", null, false, null, false, "dealer@mail.com" }
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
                table: "Mechanic",
                columns: new[] { "Id", "FirstName", "LastName", "Rating" },
                values: new object[,]
                {
                    { 1, "Pesho", "Petrov", 10.00m },
                    { 2, "Gosho", "Petkov", 8.25m },
                    { 3, "Ivelin", "Radev", 9.60m }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 180.00m, "Engine Oil and Filters" },
                    { 2, 600.00m, "Tyres" },
                    { 3, 50.00m, "MOT" },
                    { 4, 250.00m, "Windcreen" },
                    { 5, 750.00m, "Timming Belt" },
                    { 6, 1300.00m, "Clutch" },
                    { 7, 300.00m, "Cooling System" },
                    { 8, 1000.00m, "Fuel Pump and Turbo" },
                    { 9, 200.00m, "Battery" },
                    { 10, 400.00m, "Suspension" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "EngineId", "EngineSize", "FuelType", "HorsePower", "ImageUrl", "IsActive", "Make", "Model", "Price", "RegNumber", "TransmissionType", "Year" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 4, "Silver", 1, "MBWWXXVV8777", 2200, 1, 231, "https://www.gcs-germancarspecialist.co.uk/photos/10790/22713893-471d-41d8-b47a-9069e1d15840_i800x600.jpg", true, "Mercedes-Benz", "E220 AMG Sport", 24000.00m, "EF14XAE", 1, 2014 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "EngineId", "EngineSize", "FuelType", "HorsePower", "ImageUrl", "IsActive", "Make", "Model", "Price", "RegNumber", "TransmissionType", "Year" },
                values: new object[] { 2, null, 2, "Black", 1, "BMWWXXVV8777", 3000, 1, 250, "https://vcache.arnoldclark.com/imageserver/ACRFNV0147DA-S-/800/f", true, "BMW", "530d XDrive", 40000.00m, "SA71VFC", 1, 2021 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Colour", "DealerId", "EngineId", "EngineSize", "FuelType", "HorsePower", "ImageUrl", "IsActive", "Make", "Model", "Price", "RegNumber", "TransmissionType", "Year" },
                values: new object[] { 3, null, 3, "White", 1, "CCWWXXVV8777", 2000, 0, 160, "https://images.clickdealer.co.uk/vehicles/4556/4556096/large2/102784640.jpg", true, "Chevrolet", "Captiva LT", 13000.00m, "WF12GZC", 0, 2021 });

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
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
