using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemberAttendencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendencies_Attendancies_AttendanceId",
                table: "Attendencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendencies_Members_MemberId",
                table: "Attendencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendencies_Sessions_SessionId",
                table: "Attendencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendencies",
                table: "Attendencies");

            migrationBuilder.RenameTable(
                name: "Attendencies",
                newName: "MemberAttendencies");

            migrationBuilder.RenameIndex(
                name: "IX_Attendencies_SessionId",
                table: "MemberAttendencies",
                newName: "IX_MemberAttendencies_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendencies_MemberId",
                table: "MemberAttendencies",
                newName: "IX_MemberAttendencies_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendencies_AttendanceId",
                table: "MemberAttendencies",
                newName: "IX_MemberAttendencies_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberAttendencies",
                table: "MemberAttendencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendanceId",
                table: "MemberAttendencies",
                column: "AttendanceId",
                principalTable: "Attendancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAttendencies_Members_MemberId",
                table: "MemberAttendencies",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAttendencies_Sessions_SessionId",
                table: "MemberAttendencies",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberAttendencies_Attendancies_AttendanceId",
                table: "MemberAttendencies");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberAttendencies_Members_MemberId",
                table: "MemberAttendencies");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberAttendencies_Sessions_SessionId",
                table: "MemberAttendencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberAttendencies",
                table: "MemberAttendencies");

            migrationBuilder.RenameTable(
                name: "MemberAttendencies",
                newName: "Attendencies");

            migrationBuilder.RenameIndex(
                name: "IX_MemberAttendencies_SessionId",
                table: "Attendencies",
                newName: "IX_Attendencies_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberAttendencies_MemberId",
                table: "Attendencies",
                newName: "IX_Attendencies_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberAttendencies_AttendanceId",
                table: "Attendencies",
                newName: "IX_Attendencies_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendencies",
                table: "Attendencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendencies_Attendancies_AttendanceId",
                table: "Attendencies",
                column: "AttendanceId",
                principalTable: "Attendancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendencies_Members_MemberId",
                table: "Attendencies",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendencies_Sessions_SessionId",
                table: "Attendencies",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
