using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarataClub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BultRankRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BeltRankFiles_BeltRankId",
                table: "BeltRankFiles",
                column: "BeltRankId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BeltRankFiles_BeltRanks_BeltRankId",
                table: "BeltRankFiles",
                column: "BeltRankId",
                principalTable: "BeltRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeltRankFiles_BeltRanks_BeltRankId",
                table: "BeltRankFiles");

            migrationBuilder.DropIndex(
                name: "IX_BeltRankFiles_BeltRankId",
                table: "BeltRankFiles");
        }
    }
}
