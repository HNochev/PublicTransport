using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    public partial class RenameFilePropertyInDownload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoFile",
                table: "Downloads",
                newName: "FilePDF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePDF",
                table: "Downloads",
                newName: "PhotoFile");
        }
    }
}
