using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Microservice.Migrations
{
    public partial class Initproductservicedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT_DETAILS_ENTITY",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_DETAILS_ENTITY", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_DETAILS_ENTITY",
                columns: new[] { "id", "ProductName", "ProductPrice", "ProductQuantity", "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { 1, "Product 1", "100", 10, "8/23/2023 10:31:58 PM", "User_1", "8/23/2023 10:31:58 PM", "User_1" });

            migrationBuilder.InsertData(
                table: "PRODUCT_DETAILS_ENTITY",
                columns: new[] { "id", "ProductName", "ProductPrice", "ProductQuantity", "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { 2, "Product 2", "200", 20, "8/23/2023 10:31:58 PM", "User_1", "8/23/2023 10:31:58 PM", "User_1" });

            migrationBuilder.InsertData(
                table: "PRODUCT_DETAILS_ENTITY",
                columns: new[] { "id", "ProductName", "ProductPrice", "ProductQuantity", "createdAt", "createdBy", "updatedAt", "updatedBy" },
                values: new object[] { 3, "Product 3", "300", 30, "8/23/2023 10:31:58 PM", "User_1", "8/23/2023 10:31:58 PM", "User_1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_DETAILS_ENTITY");
        }
    }
}
