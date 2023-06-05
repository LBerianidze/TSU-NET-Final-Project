using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorationMarket.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class Addedcodevalueforcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Category",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Category");
        }
    }
}
