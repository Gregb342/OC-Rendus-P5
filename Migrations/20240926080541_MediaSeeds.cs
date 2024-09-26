using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Migrations
{
    public partial class MediaSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Label", "Path", "TypeOfMediaId" },
                values: new object[,]
                {
                    { 1, "Car 1 Image", "medias/pictures/Car (1).jpg", 1 },
                    { 2, "Car 2 Image", "medias/pictures/Car (2).jpg", 1 },
                    { 3, "Car 3 Image", "medias/pictures/Car (3).jpg", 1 },
                    { 4, "Car 4 Image", "medias/pictures/Car (4).jpg", 1 },
                    { 5, "Car 5 Image", "medias/pictures/Car (5).jpg", 1 },
                    { 6, "Car 6 Image", "medias/pictures/Car (6).jpg", 1 },
                    { 7, "Car 7 Image", "medias/pictures/Car (7).jpg", 1 },
                    { 8, "Car 8 Image", "medias/pictures/Car (8).jpg", 1 },
                    { 9, "Car 9 Image", "medias/pictures/Car (9).jpg", 1 },
                    { 10, "Car 10 Image", "medias/pictures/Car (10).jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "CarMedias",
                columns: new[] { "CarId", "MediaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "CarMedias",
                keyColumns: new[] { "CarId", "MediaId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
