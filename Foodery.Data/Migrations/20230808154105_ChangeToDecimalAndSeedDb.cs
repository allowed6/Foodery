using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodery.Data.Migrations
{
    public partial class ChangeToDecimalAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Vegetables" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Meat" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Dairy" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price" },
                values: new object[] { "8bf7912d-125f-4f24-b0e4-e769f516bb45", 2, "Tender beef raw stake.", "https://img.freepik.com/free-photo/raw-steak-white-paper_144627-10267.jpg?w=900&t=st=1691508215~exp=1691508815~hmac=b94fedbcc0b3a2318864761384985b3f7b7ea07415f9934276fe8a4f755a5c69", 16.29m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price" },
                values: new object[] { "a200cecb-303e-41a3-a0f0-dbac474a20c9", 1, "Freshly picked cucumbers from a home garden.", "https://www.freepik.com/free-photo/green-cucumber_7399053.htm#query=cucumbers&position=0&from_view=search&track=sph", 2.39m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price" },
                values: new object[] { "ca06e058-cbe2-47c9-afd8-aa1ca2e5a819", 3, "Delicious french blue cheese.", "https://img.freepik.com/free-photo/delicious-piece-blue-cheese_144627-43343.jpg?w=740&t=st=1691508345~exp=1691508945~hmac=e0362a0145d63688f350affe6295f39dd2aa68fb2c1f7d09e2aa92dec4ab8f3f", 34.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8bf7912d-125f-4f24-b0e4-e769f516bb45");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "a200cecb-303e-41a3-a0f0-dbac474a20c9");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "ca06e058-cbe2-47c9-afd8-aa1ca2e5a819");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2);
        }
    }
}
