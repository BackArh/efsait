using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntity_GeneralDirection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Divisions_DivisionId",
                table: "Directions");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Directions",
                newName: "GeneralDirectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Directions_DivisionId",
                table: "Directions",
                newName: "IX_Directions_GeneralDirectionId");

            migrationBuilder.CreateTable(
                name: "GeneralDirections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateChange = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralDirections_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDirections_DivisionId",
                table: "GeneralDirections",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_GeneralDirections_GeneralDirectionId",
                table: "Directions",
                column: "GeneralDirectionId",
                principalTable: "GeneralDirections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_GeneralDirections_GeneralDirectionId",
                table: "Directions");

            migrationBuilder.DropTable(
                name: "GeneralDirections");

            migrationBuilder.RenameColumn(
                name: "GeneralDirectionId",
                table: "Directions",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Directions_GeneralDirectionId",
                table: "Directions",
                newName: "IX_Directions_DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_Divisions_DivisionId",
                table: "Directions",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
