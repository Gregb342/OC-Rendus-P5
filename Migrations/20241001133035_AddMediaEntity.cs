using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Migrations
{
    public partial class AddMediaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarMedias_Media_MediaId",
                table: "CarMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_TypeOfMedias_TypeOfMediaId",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Media_TypeOfMediaId",
                table: "Medias",
                newName: "IX_Medias_TypeOfMediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarMedias_Medias_MediaId",
                table: "CarMedias",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TypeOfMedias_TypeOfMediaId",
                table: "Medias",
                column: "TypeOfMediaId",
                principalTable: "TypeOfMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarMedias_Medias_MediaId",
                table: "CarMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TypeOfMedias_TypeOfMediaId",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_TypeOfMediaId",
                table: "Media",
                newName: "IX_Media_TypeOfMediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarMedias_Media_MediaId",
                table: "CarMedias",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_TypeOfMedias_TypeOfMediaId",
                table: "Media",
                column: "TypeOfMediaId",
                principalTable: "TypeOfMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
