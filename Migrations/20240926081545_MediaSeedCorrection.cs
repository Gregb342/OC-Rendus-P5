using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Migrations
{
    public partial class MediaSeedCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "/medias/pictures/Car (1).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "/medias/pictures/Car (2).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "/medias/pictures/Car (3).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "/medias/pictures/Car (4).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "/medias/pictures/Car (5).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "/medias/pictures/Car (6).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 7,
                column: "Path",
                value: "/medias/pictures/Car (7).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 8,
                column: "Path",
                value: "/medias/pictures/Car (8).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 9,
                column: "Path",
                value: "/medias/pictures/Car (9).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 10,
                column: "Path",
                value: "/medias/pictures/Car (10).jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "medias/pictures/Car (1).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "medias/pictures/Car (2).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "medias/pictures/Car (3).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "medias/pictures/Car (4).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "medias/pictures/Car (5).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "medias/pictures/Car (6).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 7,
                column: "Path",
                value: "medias/pictures/Car (7).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 8,
                column: "Path",
                value: "medias/pictures/Car (8).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 9,
                column: "Path",
                value: "medias/pictures/Car (9).jpg");

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "Id",
                keyValue: 10,
                column: "Path",
                value: "medias/pictures/Car (10).jpg");
        }
    }
}
