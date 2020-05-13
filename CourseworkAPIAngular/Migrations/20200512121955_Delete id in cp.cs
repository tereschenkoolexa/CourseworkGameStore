using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseworkAPIAngular.Migrations
{
    public partial class Deleteidincp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblProductCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
