using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class BuildDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    languageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.languageId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "LanguageWords",
                columns: table => new
                {
                    languageWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Defaultword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageWords", x => x.languageWordId);
                    table.ForeignKey(
                        name: "FK_LanguageWords_Languages_languageId",
                        column: x => x.languageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variantproduct",
                columns: table => new
                {
                    productVariantVariantId = table.Column<int>(type: "int", nullable: false),
                    productVariantproductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variantproduct", x => new { x.productVariantVariantId, x.productVariantproductId });
                    table.ForeignKey(
                        name: "FK_Variantproduct_Products_productVariantproductId",
                        column: x => x.productVariantproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variantproduct_Variants_productVariantVariantId",
                        column: x => x.productVariantVariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantValues",
                columns: table => new
                {
                    variantValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantValues", x => x.variantValueId);
                    table.ForeignKey(
                        name: "FK_VariantValues_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageWords_languageId",
                table: "LanguageWords",
                column: "languageId");

            migrationBuilder.CreateIndex(
                name: "IX_Variantproduct_productVariantproductId",
                table: "Variantproduct",
                column: "productVariantproductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantValues_VariantId",
                table: "VariantValues",
                column: "VariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageWords");

            migrationBuilder.DropTable(
                name: "Variantproduct");

            migrationBuilder.DropTable(
                name: "VariantValues");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
