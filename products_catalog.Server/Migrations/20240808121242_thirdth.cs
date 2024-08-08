using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace products_catalog.Server.Migrations
{
    /// <inheritdoc />
    public partial class thirdth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Вода" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryItemId", "Description", "Name", "Note", "NoteSpec", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Селедка соленая", "Селедка соленая", "Акция", "Пересоленая", "10000" },
                    { 2, 1, "Тушенка говяжья", "Тушенка говяжья", "Вкусная", "Жилы", "20000" },
                    { 3, 2, "В банках", "Сгущенка", "С ключом", "Вкусная", "30000" },
                    { 4, 3, "В бутылках", "Вода", "Вятский", "Теплый", "15000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
