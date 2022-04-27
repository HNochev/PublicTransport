using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddedRequestedAndActiveCardInWebsiteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cards_CardId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "AspNetUsers",
                newName: "RequestedCardId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CardId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RequestedCardId");

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveCardId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActiveCardId",
                table: "AspNetUsers",
                column: "ActiveCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cards_ActiveCardId",
                table: "AspNetUsers",
                column: "ActiveCardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cards_RequestedCardId",
                table: "AspNetUsers",
                column: "RequestedCardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cards_ActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cards_RequestedCardId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ActiveCardId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RequestedCardId",
                table: "AspNetUsers",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RequestedCardId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cards_CardId",
                table: "AspNetUsers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }
    }
}
