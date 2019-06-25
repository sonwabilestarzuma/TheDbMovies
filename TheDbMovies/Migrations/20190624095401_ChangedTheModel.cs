using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDbMovies.Migrations
{
    public partial class ChangedTheModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Movies",
                newName: "DirectorBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectorBy",
                table: "Movies",
                newName: "Image");
        }
    }
}
