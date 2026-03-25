using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class MemberStatusIncludeInDirectory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberStatus",
                table: "Individuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInDirectory",
                table: "Households",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberStatus",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "IncludeInDirectory",
                table: "Households");
        }
    }
}
