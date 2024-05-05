using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalShelter.Migrations
{
    /// <inheritdoc />
    public partial class AddTableShelter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "rol",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id_user");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telephone",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "users",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_user",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "id_cataloge",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_shelter",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "users_pkey",
                table: "users",
                column: "id_user");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<char>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rol_pkey", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    id_shelter = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    cif = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Shelter_pkey", x => x.id_shelter);
                });

            migrationBuilder.CreateTable(
                name: "user_cataloge",
                columns: table => new
                {
                    id_cataloge = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    type = table.Column<char>(type: "char", nullable: false),
                    description = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_cataloge_pkey", x => x.id_cataloge);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id_permission = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_user = table.Column<int>(type: "integer", nullable: true),
                    id_rol = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("permissions_pkey", x => x.id_permission);
                    table.ForeignKey(
                        name: "permissions_id_rol_fkey",
                        column: x => x.id_rol,
                        principalTable: "rol",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "permissions_id_user_fkey",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donation",
                columns: table => new
                {
                    id_donation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    type_donation = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    quantity = table.Column<decimal>(type: "money", nullable: true),
                    donor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    date_donation = table.Column<DateOnly>(type: "date", nullable: false),
                    id_shelter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("donation_pkey", x => x.id_donation);
                    table.ForeignKey(
                        name: "donation_id_shelter_fkey",
                        column: x => x.id_shelter,
                        principalTable: "Shelter",
                        principalColumn: "id_shelter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id_item = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    stock = table.Column<int>(type: "integer", nullable: true),
                    type_item = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    animal_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    id_shelter = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<char>(type: "char", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("items_pkey", x => x.id_item);
                    table.ForeignKey(
                        name: "items_id_shelter_fkey",
                        column: x => x.id_shelter,
                        principalTable: "Shelter",
                        principalColumn: "id_shelter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    id_pet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    race = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    genre = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true),
                    date_entry = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    medical_history = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<char>(type: "char", nullable: true),
                    id_shelter = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pet_pkey", x => x.id_pet);
                    table.ForeignKey(
                        name: "pet_id_shelter_fkey",
                        column: x => x.id_shelter,
                        principalTable: "Shelter",
                        principalColumn: "id_shelter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adoption",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "integer", nullable: false),
                    id_adoption = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    pet_id = table.Column<int>(type: "integer", nullable: false),
                    date_adoption = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("adoption_pkey", x => x.id_user);
                    table.ForeignKey(
                        name: "adoption_id_user_fkey",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "pet_id",
                        column: x => x.pet_id,
                        principalTable: "pet",
                        principalColumn: "id_pet");
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id_appoitment = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    date = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    id_pet = table.Column<int>(type: "integer", nullable: false),
                    veterinary = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointment_pkey", x => x.id_appoitment);
                    table.ForeignKey(
                        name: "appointment_id_pet_fkey",
                        column: x => x.id_pet,
                        principalTable: "pet",
                        principalColumn: "id_pet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_id_cataloge",
                table: "users",
                column: "id_cataloge");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_shelter",
                table: "users",
                column: "id_shelter");

            migrationBuilder.CreateIndex(
                name: "IX_adoption_pet_id",
                table: "adoption",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_id_pet",
                table: "appointment",
                column: "id_pet");

            migrationBuilder.CreateIndex(
                name: "IX_donation_id_shelter",
                table: "donation",
                column: "id_shelter");

            migrationBuilder.CreateIndex(
                name: "IX_items_id_shelter",
                table: "items",
                column: "id_shelter");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_id_rol",
                table: "permissions",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_id_user",
                table: "permissions",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_pet_id_shelter",
                table: "pet",
                column: "id_shelter");

            migrationBuilder.AddForeignKey(
                name: "id_cataloge",
                table: "users",
                column: "id_cataloge",
                principalTable: "user_cataloge",
                principalColumn: "id_cataloge",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "users_id_shelter_fkey",
                table: "users",
                column: "id_shelter",
                principalTable: "Shelter",
                principalColumn: "id_shelter",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "id_cataloge",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "users_id_shelter_fkey",
                table: "users");

            migrationBuilder.DropTable(
                name: "adoption");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "donation");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "user_cataloge");

            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "Shelter");

            migrationBuilder.DropPrimaryKey(
                name: "users_pkey",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_id_cataloge",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_id_shelter",
                table: "users");

            migrationBuilder.DropColumn(
                name: "id_cataloge",
                table: "users");

            migrationBuilder.DropColumn(
                name: "id_shelter",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telephone",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddColumn<char>(
                name: "rol",
                table: "Users",
                type: "character(1)",
                nullable: false,
                defaultValue: '\0');

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
