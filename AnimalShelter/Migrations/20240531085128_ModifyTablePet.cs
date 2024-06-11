using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelter.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTablePet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<char>(
                name: "Esterilization",
                table: "pet",
                type: "character(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hair",
                table: "pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgItem",
                table: "pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumChip",
                table: "pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "pet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "pet",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "Esterilization",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "ImgItem",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "NumChip",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "pet");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "pet");
        }
    }
}
