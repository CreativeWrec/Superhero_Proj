using Microsoft.EntityFrameworkCore.Migrations;

namespace Superhero_Project.Data.Migrations
{
    public partial class UpdatedPascalCasing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "secondaryAbility",
                table: "superheroes",
                newName: "SecondaryAbility");

            migrationBuilder.RenameColumn(
                name: "primaryAbility",
                table: "superheroes",
                newName: "PrimaryAbility");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "superheroes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "catchphrase",
                table: "superheroes",
                newName: "Catchphrase");

            migrationBuilder.RenameColumn(
                name: "alterEgo",
                table: "superheroes",
                newName: "AlterEgo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondaryAbility",
                table: "superheroes",
                newName: "secondaryAbility");

            migrationBuilder.RenameColumn(
                name: "PrimaryAbility",
                table: "superheroes",
                newName: "primaryAbility");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "superheroes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Catchphrase",
                table: "superheroes",
                newName: "catchphrase");

            migrationBuilder.RenameColumn(
                name: "AlterEgo",
                table: "superheroes",
                newName: "alterEgo");
        }
    }
}
