using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileYearRecruitment_Profiles_DirectionsId",
                table: "ProfileYearRecruitment");

            migrationBuilder.RenameColumn(
                name: "DirectionsId",
                table: "ProfileYearRecruitment",
                newName: "ProfilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileYearRecruitment_Profiles_ProfilesId",
                table: "ProfileYearRecruitment",
                column: "ProfilesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileYearRecruitment_Profiles_ProfilesId",
                table: "ProfileYearRecruitment");

            migrationBuilder.RenameColumn(
                name: "ProfilesId",
                table: "ProfileYearRecruitment",
                newName: "DirectionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileYearRecruitment_Profiles_DirectionsId",
                table: "ProfileYearRecruitment",
                column: "DirectionsId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
