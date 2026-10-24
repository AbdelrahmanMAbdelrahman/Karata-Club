using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStartDateEndDatePriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                table: "Enrollments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EnrollmentDate",
                table: "Enrollments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndAt",
                table: "Courses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartAt",
                table: "Courses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "Courses");
        }
    }
}
