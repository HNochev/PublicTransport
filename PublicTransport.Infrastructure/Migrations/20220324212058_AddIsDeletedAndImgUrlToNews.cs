using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class AddIsDeletedAndImgUrlToNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_AspNetUsers_AuthorId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Vehicle_VehicleId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoComment_AspNetUsers_UserId",
                table: "PhotoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoComment_Photo_PhotoId",
                table: "PhotoComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoComment",
                table: "PhotoComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "PhotoComment",
                newName: "PhotoComments");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoComment_UserId",
                table: "PhotoComments",
                newName: "IX_PhotoComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoComment_PhotoId",
                table: "PhotoComments",
                newName: "IX_PhotoComments_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_VehicleId",
                table: "Photos",
                newName: "IX_Photos_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_AuthorId",
                table: "Photos",
                newName: "IX_Photos_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoComments",
                table: "PhotoComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoComments_AspNetUsers_UserId",
                table: "PhotoComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoComments_Photos_PhotoId",
                table: "PhotoComments",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AuthorId",
                table: "Photos",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoComments_AspNetUsers_UserId",
                table: "PhotoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoComments_Photos_PhotoId",
                table: "PhotoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AuthorId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Vehicles_VehicleId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoComments",
                table: "PhotoComments");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "News");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "PhotoComments",
                newName: "PhotoComment");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_VehicleId",
                table: "Photo",
                newName: "IX_Photo_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AuthorId",
                table: "Photo",
                newName: "IX_Photo_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoComments_UserId",
                table: "PhotoComment",
                newName: "IX_PhotoComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoComments_PhotoId",
                table: "PhotoComment",
                newName: "IX_PhotoComment_PhotoId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoComment",
                table: "PhotoComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_AspNetUsers_AuthorId",
                table: "Photo",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Vehicle_VehicleId",
                table: "Photo",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoComment_AspNetUsers_UserId",
                table: "PhotoComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoComment_Photo_PhotoId",
                table: "PhotoComment",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
