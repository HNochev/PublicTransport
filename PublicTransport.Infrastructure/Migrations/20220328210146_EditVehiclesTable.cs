using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class EditVehiclesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsScrapped",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrappedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsScrapped",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ScrappedOn",
                table: "Vehicles");
        }
    }
}
