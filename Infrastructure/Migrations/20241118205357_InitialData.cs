using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrdBooks",
                columns: new[] { "Id", "BookId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "OrderDate",
                value: new DateTime(2024, 11, 18, 23, 53, 57, 584, DateTimeKind.Local).AddTicks(4677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrdBooks",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "OrdBooks",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "OrderDate",
                value: new DateTime(2024, 11, 18, 23, 51, 46, 133, DateTimeKind.Local).AddTicks(4917));
        }
    }
}
