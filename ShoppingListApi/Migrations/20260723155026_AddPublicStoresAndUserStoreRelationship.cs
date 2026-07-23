using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicStoresAndUserStoreRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Stores_StoreId",
                table: "ShoppingLists");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "Stores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId_StoreName",
                table: "Stores",
                columns: new[] { "UserId", "StoreName" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Stores_StoreId",
                table: "ShoppingLists",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Stores_StoreId",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_UserId_StoreName",
                table: "Stores");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Stores_StoreId",
                table: "ShoppingLists",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
