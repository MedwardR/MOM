using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressFromIndividual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "Address_Zip",
                table: "Individuals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Individuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Individuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Individuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Individuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Zip",
                table: "Individuals",
                type: "text",
                nullable: true);
        }
    }
}
