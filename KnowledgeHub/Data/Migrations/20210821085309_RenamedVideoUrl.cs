using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeHub.Data.Migrations
{
    public partial class RenamedVideoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Videos",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Videos",
                newName: "URL");
        }
    }
}
