using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddDescriptionToLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lines");
        }
    }
}
