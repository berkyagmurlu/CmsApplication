using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsApplication.Data.Migrations
{
    public partial class AddSliderTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Slider",
                maxLength: 512,
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title", 
                table: "Slider"
            );
        }
    }
}
