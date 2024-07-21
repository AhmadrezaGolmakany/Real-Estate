using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace کارگزاری_املاک.Data.Migrations
{
    /// <inheritdoc />
    public partial class _456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estates_categories_categoryId",
                table: "estates");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "estates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_estates_categories_categoryId",
                table: "estates",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estates_categories_categoryId",
                table: "estates");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "estates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_estates_categories_categoryId",
                table: "estates",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
