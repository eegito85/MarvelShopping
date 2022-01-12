using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelShopping.ProductAPI.Migrations
{
    public partial class AddProductsToTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[] { 5L, "Vestuário", "Camiseta Capitão América Tamanho M 100% Algodão", "https://cdn.awsli.com.br/600x700/566/566157/produto/38860253/09596ef929.jpg", "Camiseta Capitão América", 59.90m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
