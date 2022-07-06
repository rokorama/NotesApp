using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesApp.DataAccess.Migrations
{
    public partial class RemoveredundantcolumnfromNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteCategoryId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
