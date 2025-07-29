using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web1.Migrations
{
    /// <inheritdoc />
    public partial class tareaMigracionSegunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "tareaModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tareaModels_UserId",
                table: "tareaModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels");

            migrationBuilder.DropIndex(
                name: "IX_tareaModels_UserId",
                table: "tareaModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "tareaModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
