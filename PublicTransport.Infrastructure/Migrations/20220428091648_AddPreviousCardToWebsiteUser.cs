using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddPreviousCardToWebsiteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PreviousActiveCardId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousCardActiveFrom",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousCardActiveTo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousCardOwnerFirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousCardOwnerLastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PreviousActiveCardId",
                table: "AspNetUsers",
                column: "PreviousActiveCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cards_PreviousActiveCardId",
                table: "AspNetUsers",
                column: "PreviousActiveCardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cards_PreviousActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PreviousActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousCardActiveFrom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousCardActiveTo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousCardOwnerFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousCardOwnerLastName",
                table: "AspNetUsers");
        }
    }
}
