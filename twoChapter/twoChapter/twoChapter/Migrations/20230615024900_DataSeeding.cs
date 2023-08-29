using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twoChapter.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fess", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("7411f8ee-ef30-479a-b89b-0472a042c514"), new DateTime(2023, 6, 15, 2, 48, 59, 872, DateTimeKind.Utc).AddTicks(2662), null, "shuoming", null, null, null, null, 0m, "ceshititle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "id",
                keyValue: new Guid("7411f8ee-ef30-479a-b89b-0472a042c514"));
        }
    }
}
