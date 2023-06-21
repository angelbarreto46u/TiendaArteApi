using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaArteApi.Migrations
{
    /// <inheritdoc />
    public partial class PawArt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductUnit = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "RegistroComision",
                columns: table => new
                {
                    ComisionCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroComision", x => x.ComisionCode);
                });

            migrationBuilder.CreateTable(
                name: "RegistroVentas",
                columns: table => new
                {
                    VentasCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solicitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioVenta = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVentas", x => x.VentasCode);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductCode", "ProductDescription", "ProductName", "ProductPrice", "ProductUnit" },
                values: new object[] { "PROD-1", "", "Sticker de pepapig", 2500.0, 5 });

            migrationBuilder.InsertData(
                table: "RegistroVentas",
                columns: new[] { "VentasCode", "ClienteName", "Direccion", "FechaEntrega", "PrecioVenta", "Solicitud" },
                values: new object[] { 1, "Juanito", "Mi casa", new DateTime(2023, 6, 19, 14, 38, 53, 948, DateTimeKind.Local).AddTicks(1977), 300.0, "Librox3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RegistroComision");

            migrationBuilder.DropTable(
                name: "RegistroVentas");
        }
    }
}
