using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_PathImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathImage",
                table: "GeneralDirections",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathImage",
                table: "GeneralDirections");
        }
    }
}
