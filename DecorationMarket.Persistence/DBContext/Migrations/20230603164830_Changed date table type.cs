using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecorationMarket.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class Changeddatetabletype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UploadedFile",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 6, 3, 20, 46, 12, 661, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 6, 3, 20, 46, 12, 664, DateTimeKind.Local).AddTicks(3381));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UploadedFile",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 20, 46, 12, 661, DateTimeKind.Local).AddTicks(231),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 20, 46, 12, 664, DateTimeKind.Local).AddTicks(3381),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
