using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileMekaniko_Invoice.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCarMake",
                columns: table => new
                {
                    CarMakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMakeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarMake", x => x.CarMakeId);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "tblCar",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarRego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCar", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_tblCar_tblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCarManufacturer",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CarMakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarManufacturer", x => new { x.CarId, x.CarMakeId });
                    table.ForeignKey(
                        name: "FK_tblCarManufacturer_tblCarMake_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "tblCarMake",
                        principalColumn: "CarMakeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCarManufacturer_tblCar_CarId",
                        column: x => x.CarId,
                        principalTable: "tblCar",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCar_CustomerId",
                table: "tblCar",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarManufacturer_CarMakeId",
                table: "tblCarManufacturer",
                column: "CarMakeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCarManufacturer");

            migrationBuilder.DropTable(
                name: "tblCarMake");

            migrationBuilder.DropTable(
                name: "tblCar");

            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
