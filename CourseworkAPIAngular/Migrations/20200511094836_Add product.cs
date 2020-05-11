using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseworkAPIAngular.Migrations
{
    public partial class Addproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Data = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    ProdctId = table.Column<int>(nullable: false),
                    Shooter = table.Column<bool>(nullable: false),
                    Fighting = table.Column<bool>(nullable: false),
                    Strategy = table.Column<bool>(nullable: false),
                    Simulator = table.Column<bool>(nullable: false),
                    Sports = table.Column<bool>(nullable: false),
                    Racing = table.Column<bool>(nullable: false),
                    RolePlaying = table.Column<bool>(nullable: false),
                    Action = table.Column<bool>(nullable: false),
                    Adventure = table.Column<bool>(nullable: false),
                    RPG = table.Column<bool>(nullable: false),
                    Stealth = table.Column<bool>(nullable: false),
                    Horror = table.Column<bool>(nullable: false),
                    Sandbox = table.Column<bool>(nullable: false),
                    Survival = table.Column<bool>(nullable: false),
                    Platformer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.ProdctId);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblProduct_ProdctId",
                        column: x => x.ProdctId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLanguages",
                columns: table => new
                {
                    ProdctId = table.Column<int>(nullable: false),
                    English = table.Column<bool>(nullable: false),
                    French = table.Column<bool>(nullable: false),
                    Italian = table.Column<bool>(nullable: false),
                    German = table.Column<bool>(nullable: false),
                    Spanish = table.Column<bool>(nullable: false),
                    Arabic = table.Column<bool>(nullable: false),
                    Czech = table.Column<bool>(nullable: false),
                    Japanese = table.Column<bool>(nullable: false),
                    Korean = table.Column<bool>(nullable: false),
                    Polish = table.Column<bool>(nullable: false),
                    Portuguese = table.Column<bool>(nullable: false),
                    Russian = table.Column<bool>(nullable: false),
                    Turkish = table.Column<bool>(nullable: false),
                    Chinese = table.Column<bool>(nullable: false),
                    Ukrainian = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLanguages", x => x.ProdctId);
                    table.ForeignKey(
                        name: "FK_tblLanguages_tblProduct_ProdctId",
                        column: x => x.ProdctId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSystemRequirements",
                columns: table => new
                {
                    ProdctId = table.Column<int>(nullable: false),
                    OS = table.Column<string>(nullable: false),
                    Processor = table.Column<string>(nullable: false),
                    Memory = table.Column<string>(nullable: false),
                    Graphics = table.Column<string>(nullable: false),
                    DirectX = table.Column<string>(nullable: false),
                    Storege = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSystemRequirements", x => x.ProdctId);
                    table.ForeignKey(
                        name: "FK_tblSystemRequirements_tblProduct_ProdctId",
                        column: x => x.ProdctId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCategories");

            migrationBuilder.DropTable(
                name: "tblLanguages");

            migrationBuilder.DropTable(
                name: "tblSystemRequirements");

            migrationBuilder.DropTable(
                name: "tblProduct");
        }
    }
}
