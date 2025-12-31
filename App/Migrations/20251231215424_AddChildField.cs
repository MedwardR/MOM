using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class AddChildField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Child",
                table: "Individuals",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Child",
                table: "Individuals");
        }
    }
}
