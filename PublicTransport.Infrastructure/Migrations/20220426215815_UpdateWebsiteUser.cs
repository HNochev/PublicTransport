using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class UpdateWebsiteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardOwnerFirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardOwnerLastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardOwnerFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardOwnerLastName",
                table: "AspNetUsers");
        }
    }
}
