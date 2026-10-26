using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMemberAttendenceRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendencies_MemberId",
                table: "Attendencies");

            migrationBuilder.RenameColumn(
                name: "IsExist",
                table: "Attendencies",
                newName: "Exist");

            migrationBuilder.AddColumn<Guid>(
                name: "AttendanceId",
                table: "Attendencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendenceId",
                table: "Attendencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Attendancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendancies_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendencies_AttendanceId",
                table: "Attendencies",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendencies_MemberId",
                table: "Attendencies",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendancies_SessionId",
                table: "Attendancies",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendencies_Attendancies_AttendanceId",
                table: "Attendencies",
                column: "AttendanceId",
                principalTable: "Attendancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendencies_Attendancies_AttendanceId",
                table: "Attendencies");

            migrationBuilder.DropTable(
                name: "Attendancies");

            migrationBuilder.DropIndex(
                name: "IX_Attendencies_AttendanceId",
                table: "Attendencies");

            migrationBuilder.DropIndex(
                name: "IX_Attendencies_MemberId",
                table: "Attendencies");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Attendencies");

            migrationBuilder.DropColumn(
                name: "AttendenceId",
                table: "Attendencies");

            migrationBuilder.RenameColumn(
                name: "Exist",
                table: "Attendencies",
                newName: "IsExist");

            migrationBuilder.CreateIndex(
                name: "IX_Attendencies_MemberId",
                table: "Attendencies",
                column: "MemberId");
        }
    }
}
