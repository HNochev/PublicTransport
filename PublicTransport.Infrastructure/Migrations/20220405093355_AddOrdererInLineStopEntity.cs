using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddOrdererInLineStopEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orderer",
                table: "LineStops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orderer",
                table: "LineStops");
        }
    }
}
