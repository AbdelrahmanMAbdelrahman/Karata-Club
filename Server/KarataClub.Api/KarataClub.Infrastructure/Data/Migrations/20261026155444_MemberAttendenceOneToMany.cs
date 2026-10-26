using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemberAttendenceOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberAttendencies_MemberId",
                table: "MemberAttendencies");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAttendencies_MemberId",
                table: "MemberAttendencies",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberAttendencies_MemberId",
                table: "MemberAttendencies");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAttendencies_MemberId",
                table: "MemberAttendencies",
                column: "MemberId",
                unique: true);
        }
    }
}
