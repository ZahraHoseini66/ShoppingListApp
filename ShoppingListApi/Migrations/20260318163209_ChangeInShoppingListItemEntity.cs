using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInShoppingListItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "ShoppingListItems",
                newName: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "ShoppingListItems",
                newName: "Unit");
        }
    }
}
