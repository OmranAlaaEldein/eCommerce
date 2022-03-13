using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class correctProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantValues_Variants_VariantId",
                table: "VariantValues");

            migrationBuilder.DropTable(
                name: "Variantproduct");

            migrationBuilder.DropIndex(
                name: "IX_VariantValues_VariantId",
                table: "VariantValues");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "VariantValues");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Variants",
                newName: "size");

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantproductId",
                table: "Variants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Variants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "matrial",
                table: "Variants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Variants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductVariantproductId",
                table: "Variants",
                column: "ProductVariantproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_ProductVariantproductId",
                table: "Variants",
                column: "ProductVariantproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_ProductVariantproductId",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Variants_ProductVariantproductId",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "ProductVariantproductId",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "matrial",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Variants");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Variants",
                newName: "name");

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "VariantValues",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_VariantValues_VariantId",
                table: "VariantValues",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variantproduct_productVariantproductId",
                table: "Variantproduct",
                column: "productVariantproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValues_Variants_VariantId",
                table: "VariantValues",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "VariantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
