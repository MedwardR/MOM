using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhoneEmailFromHousehold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Households");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Households",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Households",
                type: "text",
                nullable: true);
        }
    }
}
