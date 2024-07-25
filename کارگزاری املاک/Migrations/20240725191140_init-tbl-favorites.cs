using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace کارگزاری_املاک.Migrations
{
    /// <inheritdoc />
    public partial class inittblfavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_favorites_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_favorites_estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_favorites_EstateId",
                table: "favorites",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_userId",
                table: "favorites",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorites");
        }
    }
}
