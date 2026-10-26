using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTepoIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendanceId",
                table: "MemberAttendencies");

            migrationBuilder.DropIndex(
                name: "IX_MemberAttendencies_AttendanceId",
                table: "MemberAttendencies");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "MemberAttendencies");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAttendencies_AttendenceId",
                table: "MemberAttendencies",
                column: "AttendenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendenceId",
                table: "MemberAttendencies",
                column: "AttendenceId",
                principalTable: "Attendancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendenceId",
                table: "MemberAttendencies");

            migrationBuilder.DropIndex(
                name: "IX_MemberAttendencies_AttendenceId",
                table: "MemberAttendencies");

            migrationBuilder.AddColumn<Guid>(
                name: "AttendanceId",
                table: "MemberAttendencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MemberAttendencies_AttendanceId",
                table: "MemberAttendencies",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendanceId",
                table: "MemberAttendencies",
                column: "AttendanceId",
                principalTable: "Attendancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
