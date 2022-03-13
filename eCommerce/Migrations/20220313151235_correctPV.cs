using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class correctPV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_ProductVariantproductId",
                table: "Variants");

            migrationBuilder.RenameColumn(
                name: "ProductVariantproductId",
                table: "Variants",
                newName: "myProductproductId");

            migrationBuilder.RenameIndex(
                name: "IX_Variants_ProductVariantproductId",
                table: "Variants",
                newName: "IX_Variants_myProductproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_myProductproductId",
                table: "Variants",
                column: "myProductproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_myProductproductId",
                table: "Variants");

            migrationBuilder.RenameColumn(
                name: "myProductproductId",
                table: "Variants",
                newName: "ProductVariantproductId");

            migrationBuilder.RenameIndex(
                name: "IX_Variants_myProductproductId",
                table: "Variants",
                newName: "IX_Variants_ProductVariantproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_ProductVariantproductId",
                table: "Variants",
                column: "ProductVariantproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
