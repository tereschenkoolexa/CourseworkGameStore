using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseworkAPIAngular.Migrations
{
    public partial class Addimageproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblProduct",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblProduct");
        }
    }
}
