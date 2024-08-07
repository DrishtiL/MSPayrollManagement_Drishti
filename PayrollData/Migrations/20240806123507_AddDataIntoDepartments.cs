using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PayrollData.Migrations
{
    /// <inheritdoc />
    public partial class AddDataIntoDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Depatments",
                columns: new[] { "Id", "dName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "Finance" },
                    { 3, "Tech" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Depatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Depatments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Depatments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
