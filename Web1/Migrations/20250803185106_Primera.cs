using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web1.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "tareaModels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "tareaModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tareaModels_AspNetUsers_UserId",
                table: "tareaModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
