using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOM.Migrations
{
    /// <inheritdoc />
    public partial class RefactorAddIndividual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Households",
                newName: "Address_Zip");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Households",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Households",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Households",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Households",
                newName: "Address_City");

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CommunicationPreference = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Occupation = table.Column<string>(type: "text", nullable: true),
                    Employer = table.Column<string>(type: "text", nullable: true),
                    JoinedMethod = table.Column<string>(type: "text", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BaptizedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BaptizedLocation = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    MarriedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_State = table.Column<string>(type: "text", nullable: true),
                    Address_Zip = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_HouseholdId",
                table: "Individuals",
                column: "HouseholdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.RenameColumn(
                name: "Address_Zip",
                table: "Households",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Households",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Households",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Households",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Households",
                newName: "City");
        }
    }
}
