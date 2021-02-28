using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class AddTestSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "Street" },
                values: new object[] { new Guid("88d642bd-6d3e-403c-aa15-8552deddfa8a"), "Monaco", "Monaco", "Monaco", "Some street" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("346a21a2-3c1f-43a6-a6a0-dc57613afe19"), "C# programming", "ICS" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Name", "Section" },
                values: new object[] { new Guid("a464eaa4-867e-45f4-81f1-48465e2c236f"), "Best class", "The best" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "GradeId", "Name" },
                values: new object[] { new Guid("0a7ee49a-c6ac-41af-97d0-9f91b9faf966"), new Guid("88d642bd-6d3e-403c-aa15-8552deddfa8a"), new Guid("a464eaa4-867e-45f4-81f1-48465e2c236f"), "Jane" });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[] { new Guid("5a459757-0c73-414e-83e4-8b24e998e3ce"), new Guid("346a21a2-3c1f-43a6-a6a0-dc57613afe19"), new Guid("0a7ee49a-c6ac-41af-97d0-9f91b9faf966") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: new Guid("5a459757-0c73-414e-83e4-8b24e998e3ce"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("346a21a2-3c1f-43a6-a6a0-dc57613afe19"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0a7ee49a-c6ac-41af-97d0-9f91b9faf966"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("88d642bd-6d3e-403c-aa15-8552deddfa8a"));

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("a464eaa4-867e-45f4-81f1-48465e2c236f"));
        }
    }
}
