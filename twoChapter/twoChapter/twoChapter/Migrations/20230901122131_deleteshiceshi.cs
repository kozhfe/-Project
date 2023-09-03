using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twoChapter.Migrations
{
    public partial class deleteshiceshi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheShi");

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "id",
                keyValue: new Guid("00fe4c98-d4e0-4454-80d3-9a438bbc19dc"));

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fess", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("aded5717-6a83-4965-945d-033135ccc43c"), new DateTime(2023, 9, 1, 12, 21, 30, 682, DateTimeKind.Utc).AddTicks(890), null, "shuoming", null, null, null, null, 0m, "ceshititle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "id",
                keyValue: new Guid("aded5717-6a83-4965-945d-033135ccc43c"));

            migrationBuilder.CreateTable(
                name: "CheShi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stirngggg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheShi", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fess", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("00fe4c98-d4e0-4454-80d3-9a438bbc19dc"), new DateTime(2023, 9, 1, 12, 19, 6, 489, DateTimeKind.Utc).AddTicks(5446), null, "shuoming", null, null, null, null, 0m, "ceshititle", null });
        }
    }
}
