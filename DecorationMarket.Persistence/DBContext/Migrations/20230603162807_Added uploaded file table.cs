using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorationMarket.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class Addeduploadedfiletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 6, 3, 20, 28, 7, 29, DateTimeKind.Local).AddTicks(5962))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImageId",
                table: "Product",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UploadedFile_ImageId",
                table: "Product",
                column: "ImageId",
                principalTable: "UploadedFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_UploadedFile_ImageId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "UploadedFile");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImageId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");
        }
    }
}
