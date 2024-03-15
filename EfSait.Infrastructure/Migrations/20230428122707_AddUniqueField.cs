using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Code",
                table: "Profiles",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_Code",
                table: "Divisions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Name",
                table: "Disciplines",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_Code",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_Code",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_Name",
                table: "Disciplines");
        }
    }
}
