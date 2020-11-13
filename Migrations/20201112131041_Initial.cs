using Microsoft.EntityFrameworkCore.Migrations;

namespace IGSService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "Name", "Price" },
                values: new object[] { 1, "Lavender heart", 9.25 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "Name", "Price" },
                values: new object[] { 2, "Personalised cufflinks", 45.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "Name", "Price" },
                values: new object[] { 3, "Kids T-shirt", 19.949999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
