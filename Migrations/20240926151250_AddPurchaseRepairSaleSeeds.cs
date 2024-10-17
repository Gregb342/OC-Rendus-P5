using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Migrations
{
    public partial class AddPurchaseRepairSaleSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CarId", "PurchaseDate", "PurchasePrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.00m },
                    { 2, 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000.00m },
                    { 3, 3, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000.00m },
                    { 4, 4, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17000.00m },
                    { 5, 5, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000.00m },
                    { 6, 6, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19000.00m },
                    { 7, 7, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000.00m },
                    { 8, 8, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 21000.00m },
                    { 9, 9, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 23000.00m },
                    { 10, 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000.00m }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Description", "RepairCost", "RepairDate" },
                values: new object[,]
                {
                    { 1, 1, "Repair description 1", 500.00m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "Repair description 2", 700.00m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, "Repair description 3", 600.00m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, "Repair description 4", 800.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 6, "Repair description 5", 900.00m, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 7, "Repair description 6", 1000.00m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 8, "Repair description 7", 1100.00m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 10, "Repair description 8", 1200.00m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CarId", "SaleDate", "SalePrice" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000.00m },
                    { 2, 8, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23000.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
