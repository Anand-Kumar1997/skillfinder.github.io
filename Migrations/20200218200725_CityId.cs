using Microsoft.EntityFrameworkCore.Migrations;

namespace Skill4.Migrations
{
    public partial class CityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitiesClasss",
                columns: table => new
                {
                    CityCode = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesClasss", x => x.CityCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesClasss");
        }
    }
}
