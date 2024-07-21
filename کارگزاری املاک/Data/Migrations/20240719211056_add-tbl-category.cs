using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace کارگزاری_املاک.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtblcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "estates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estates_categoryId",
                table: "estates",
                column: "categoryId");

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

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_estates_categoryId",
                table: "estates");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "estates");
        }
    }
}
