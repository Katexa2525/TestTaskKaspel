using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "OrderDate",
                value: new DateTime(2024, 11, 18, 14, 33, 21, 961, DateTimeKind.Local).AddTicks(2347));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "OrderDate",
                value: new DateTime(2024, 11, 18, 14, 25, 54, 853, DateTimeKind.Local).AddTicks(8016));
        }
    }
}
