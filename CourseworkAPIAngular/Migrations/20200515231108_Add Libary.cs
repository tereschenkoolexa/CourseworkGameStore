using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseworkAPIAngular.Migrations
{
    public partial class AddLibary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblLibrary",
                columns: table => new
                {
                    ProdctId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLibrary", x => new { x.UserId, x.ProdctId });
                    table.ForeignKey(
                        name: "FK_tblLibrary_tblProduct_ProdctId",
                        column: x => x.ProdctId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblLibrary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblLibrary_ProdctId",
                table: "tblLibrary",
                column: "ProdctId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblLibrary");
        }
    }
}
