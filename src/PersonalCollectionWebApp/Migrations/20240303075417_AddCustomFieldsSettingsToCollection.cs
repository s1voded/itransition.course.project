using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalCollectionWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomFieldsSettingsToCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomFieldsSettings",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomFieldsSettings",
                table: "Collections");
        }
    }
}
