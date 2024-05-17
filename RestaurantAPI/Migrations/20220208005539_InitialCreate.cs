using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CTM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTM_Name = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CTM_ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FDI_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FDI_Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FDI_Price = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FDI_ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderMasters",
                columns: table => new
                {
                    OMT_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OMT_OrderNumber = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    CTM_ID = table.Column<int>(type: "int", nullable: false),
                    CustomerCTM_ID = table.Column<int>(type: "int", nullable: true),
                    OMT_PMethod = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    OMT_GTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMasters", x => x.OMT_ID);
                    table.ForeignKey(
                        name: "FK_OrderMasters_Customers_CustomerCTM_ID",
                        column: x => x.CustomerCTM_ID,
                        principalTable: "Customers",
                        principalColumn: "CTM_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ODT_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OMT_ID = table.Column<long>(type: "bigint", nullable: false),
                    FDI_ID = table.Column<int>(type: "int", nullable: false),
                    FoodItemFDI_ID = table.Column<int>(type: "int", nullable: true),
                    ODT_FoodItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderMasterOMT_ID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ODT_ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_FoodItems_FoodItemFDI_ID",
                        column: x => x.FoodItemFDI_ID,
                        principalTable: "FoodItems",
                        principalColumn: "FDI_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderMasters_OrderMasterOMT_ID",
                        column: x => x.OrderMasterOMT_ID,
                        principalTable: "OrderMasters",
                        principalColumn: "OMT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodItemFDI_ID",
                table: "OrderDetails",
                column: "FoodItemFDI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderMasterOMT_ID",
                table: "OrderDetails",
                column: "OrderMasterOMT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CustomerCTM_ID",
                table: "OrderMasters",
                column: "CustomerCTM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "OrderMasters");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
