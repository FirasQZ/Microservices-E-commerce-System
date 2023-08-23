using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Microservice.Migrations
{
    public partial class initorderdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDER_ENTITYE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ENTITYE", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_ENTITYE");
        }
    }
}
