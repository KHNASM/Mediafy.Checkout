using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediafy.Checkout.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class V0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 2, "Sveriges största veckotidning ger dig glädje och inspiration, varje vecka.", "https://bilder.tidningskungen.se/upl/normal500/allers-16-2023.jpg", "Allers" },
                    { 4, "Donald Duck er Norges mest kjente tegneserieutgivelse som kommer ut en gang i uken.", "https://bilder.bladkongen.no/upl/normal500/donald-duck--co-9-2022.jpg", "Donald Duck & Co" },
                    { 6, "Kotiliesi on rakastettu naistenlehti, joka tuo iloa ja väriä arkeen.", "https://kuvat.lehtiapaja.fi/upl/normal500/kotiliesi-10-2023.jpg", "Kotiliesi" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Country", "Name", "Price", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "10 nr 169 kr, spara 57%", 169m, 2 },
                    { 3, 2, "13 nr 399 kr, spar 53%", 99m, 4 },
                    { 5, 3, "24 nro 39 €, säästä 46%", 39m, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProductId",
                table: "Offers",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
