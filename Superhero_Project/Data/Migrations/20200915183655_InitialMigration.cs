using Microsoft.EntityFrameworkCore.Migrations;

namespace Superhero_Project.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "superheroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    alterEgo = table.Column<string>(nullable: true),
                    primaryAbility = table.Column<string>(nullable: true),
                    secondaryAbility = table.Column<string>(nullable: true),
                    catchphrase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_superheroes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "superheroes");
        }
    }
}
