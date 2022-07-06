using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesApp.DataAccess.Migrations
{
    public partial class Replace1to1childobjectswithguids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Notes_NoteId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Images_NoteId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_NoteCategoryId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_NoteCategoryId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteCategoryId",
                table: "Notes");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NoteId",
                table: "Images",
                column: "NoteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Notes_NoteId",
                table: "Images",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
