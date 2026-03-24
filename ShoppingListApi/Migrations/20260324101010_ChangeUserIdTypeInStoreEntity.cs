using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdTypeInStoreEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
