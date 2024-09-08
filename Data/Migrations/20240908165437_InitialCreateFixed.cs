using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Data.Migrations
{
    public partial class InitialCreateFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCarTrim_CarTrims_CarTrimId",
                table: "CarCarTrim");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCarTrim_CarTrims_CarTrimId",
                table: "CarCarTrim",
                column: "CarTrimId",
                principalTable: "CarTrims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCarTrim_CarTrims_CarTrimId",
                table: "CarCarTrim");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCarTrim_CarTrims_CarTrimId",
                table: "CarCarTrim",
                column: "CarTrimId",
                principalTable: "CarTrims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
