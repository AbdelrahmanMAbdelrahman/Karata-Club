using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableUploadedFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeltRankFiles_UploadedFiles_UploadedFileId",
                table: "BeltRankFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFiles_UploadedFiles_UploadedFileId",
                table: "CourseFiles");

            migrationBuilder.DropIndex(
                name: "IX_CourseFiles_UploadedFileId",
                table: "CourseFiles");

            migrationBuilder.DropIndex(
                name: "IX_BeltRankFiles_UploadedFileId",
                table: "BeltRankFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "CourseFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "BeltRankFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFiles_UploadedFileId",
                table: "CourseFiles",
                column: "UploadedFileId",
                unique: true,
                filter: "[UploadedFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeltRankFiles_UploadedFileId",
                table: "BeltRankFiles",
                column: "UploadedFileId",
                unique: true,
                filter: "[UploadedFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BeltRankFiles_UploadedFiles_UploadedFileId",
                table: "BeltRankFiles",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFiles_UploadedFiles_UploadedFileId",
                table: "CourseFiles",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeltRankFiles_UploadedFiles_UploadedFileId",
                table: "BeltRankFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFiles_UploadedFiles_UploadedFileId",
                table: "CourseFiles");

            migrationBuilder.DropIndex(
                name: "IX_CourseFiles_UploadedFileId",
                table: "CourseFiles");

            migrationBuilder.DropIndex(
                name: "IX_BeltRankFiles_UploadedFileId",
                table: "BeltRankFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "CourseFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UploadedFileId",
                table: "BeltRankFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseFiles_UploadedFileId",
                table: "CourseFiles",
                column: "UploadedFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeltRankFiles_UploadedFileId",
                table: "BeltRankFiles",
                column: "UploadedFileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BeltRankFiles_UploadedFiles_UploadedFileId",
                table: "BeltRankFiles",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFiles_UploadedFiles_UploadedFileId",
                table: "CourseFiles",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
