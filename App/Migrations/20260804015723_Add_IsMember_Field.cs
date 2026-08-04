using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsMember_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMember",
                table: "Individuals",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMember",
                table: "Individuals");
        }
    }
}
