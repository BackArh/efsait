using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ovveride_schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Divisions_DivisionId",
                table: "Profiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "DivisionId",
                table: "Profiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "DivisionId",
                table: "Directions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Directions_DivisionId",
                table: "Directions",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_Divisions_DivisionId",
                table: "Directions",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Divisions_DivisionId",
                table: "Profiles",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Divisions_DivisionId",
                table: "Directions");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Divisions_DivisionId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Directions_DivisionId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Directions");

            migrationBuilder.AlterColumn<Guid>(
                name: "DivisionId",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Divisions_DivisionId",
                table: "Profiles",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
