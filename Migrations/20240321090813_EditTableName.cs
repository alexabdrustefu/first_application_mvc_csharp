using Microsoft.EntityFrameworkCore.Migrations;

namespace first_mvc_pattern_c_.Migrations
{
    public partial class EditTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Failms_Cinemas_CinemaId",
                table: "Failms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Failms",
                table: "Failms");

            migrationBuilder.RenameTable(
                name: "Failms",
                newName: "Films");

            migrationBuilder.RenameIndex(
                name: "IX_Failms_CinemaId",
                table: "Films",
                newName: "IX_Films_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Films",
                table: "Films",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Films",
                table: "Films");

            migrationBuilder.RenameTable(
                name: "Films",
                newName: "Failms");

            migrationBuilder.RenameIndex(
                name: "IX_Films_CinemaId",
                table: "Failms",
                newName: "IX_Failms_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Failms",
                table: "Failms",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Failms_Cinemas_CinemaId",
                table: "Failms",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
