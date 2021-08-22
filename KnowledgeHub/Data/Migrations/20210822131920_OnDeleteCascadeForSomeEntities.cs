using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeHub.Data.Migrations
{
    public partial class OnDeleteCascadeForSomeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectors_LectorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectors_AspNetUsers_UserId",
                table: "Lectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsVideos_Students_StudentId",
                table: "StudentsVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Topics_TopicId",
                table: "Videos");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectors_LectorId",
                table: "Courses",
                column: "LectorId",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectors_AspNetUsers_UserId",
                table: "Lectors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsVideos_Students_StudentId",
                table: "StudentsVideos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Topics_TopicId",
                table: "Videos",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectors_LectorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectors_AspNetUsers_UserId",
                table: "Lectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsVideos_Students_StudentId",
                table: "StudentsVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Topics_TopicId",
                table: "Videos");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectors_LectorId",
                table: "Courses",
                column: "LectorId",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectors_AspNetUsers_UserId",
                table: "Lectors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsVideos_Students_StudentId",
                table: "StudentsVideos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Topics_TopicId",
                table: "Videos",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
