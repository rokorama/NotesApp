using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesApp.DataAccess.Migrations
{
    public partial class Renameandcleanupcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_NoteCategoryId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_NoteCategoryId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteCategoryId",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes");

            migrationBuilder.AddColumn<Guid>(
                name: "NoteCategoryId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteCategoryId",
                table: "Notes",
                column: "NoteCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_NoteCategoryId",
                table: "Notes",
                column: "NoteCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
