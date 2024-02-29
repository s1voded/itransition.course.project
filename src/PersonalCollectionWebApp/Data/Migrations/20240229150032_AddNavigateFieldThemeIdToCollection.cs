using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalCollectionWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigateFieldThemeIdToCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Themes_ThemeId",
                table: "Collections");

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Themes_ThemeId",
                table: "Collections",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Themes_ThemeId",
                table: "Collections");

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "Collections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Themes_ThemeId",
                table: "Collections",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id");
        }
    }
}
