using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddNewTableVehicleCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleConditionId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VehicleConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleConditions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleConditionId",
                table: "Vehicles",
                column: "VehicleConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles",
                column: "VehicleConditionId",
                principalTable: "VehicleConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleConditions");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
