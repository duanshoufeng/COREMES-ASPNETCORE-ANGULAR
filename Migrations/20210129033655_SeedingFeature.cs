using Microsoft.EntityFrameworkCore.Migrations;

namespace COREMES.Migrations
{
    public partial class SeedingFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Feature (Name) VALUES ('Feature1');");
            migrationBuilder.Sql("INSERT INTO dbo.Feature (Name) VALUES ('Feature2');");
            migrationBuilder.Sql("INSERT INTO dbo.Feature (Name) VALUES ('Feature3');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Feature WHERE Name IN ('Feature1', 'Feature2', 'Feature3');");

        }
    }
}
