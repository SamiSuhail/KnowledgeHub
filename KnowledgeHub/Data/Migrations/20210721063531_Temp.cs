using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeHub.Data.Migrations
{
    public partial class Temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Course_CourseId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Video_CourseId",
                table: "Videos",
                newName: "IX_Videos_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CategoryId",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Courses_CourseId",
                table: "Videos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Courses_CourseId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_CourseId",
                table: "Video",
                newName: "IX_Video_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "Course",
                newName: "IX_Course_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Course_CourseId",
                table: "Video",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
