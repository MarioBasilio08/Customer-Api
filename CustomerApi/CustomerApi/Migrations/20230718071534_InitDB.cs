using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PuntoDeVenta");

            //migrationBuilder.CreateTable(
            //    name: "Customer",
            //    schema: "PuntoDeVenta",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Age = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customer", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employees",
            //    schema: "PuntoDeVenta",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Age = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employees", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "PuntoDeVenta",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deseripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProducto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Customer",
            //    schema: "PuntoDeVenta");

            //migrationBuilder.DropTable(
            //    name: "Employees",
            //    schema: "PuntoDeVenta");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "PuntoDeVenta");
        }
    }
}
