using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddPhotoStatusAndEditPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AuthorId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Photos",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AuthorId",
                table: "Photos",
                newName: "IX_Photos_UserId");

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Photos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoStatusId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PhotoStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoStatusId",
                table: "Photos",
                column: "PhotoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PhotoStatuses_PhotoStatusId",
                table: "Photos",
                column: "PhotoStatusId",
                principalTable: "PhotoStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_PhotoStatuses_PhotoStatusId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "PhotoStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotoStatusId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoStatusId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Photos",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                newName: "IX_Photos_AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AuthorId",
                table: "Photos",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
