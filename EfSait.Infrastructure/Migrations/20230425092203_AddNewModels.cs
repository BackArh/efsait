using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Divisions_DivisionId",
                table: "Directions");

            migrationBuilder.DropTable(
                name: "DirectionYearRecruitment");

            migrationBuilder.DropIndex(
                name: "IX_Directions_DivisionId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "FormEducation",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "LanguageEducation",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "PeriodEducation",
                table: "Directions");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateChange = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileYearRecruitment",
                columns: table => new
                {
                    DirectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    YearRecruitmentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileYearRecruitment", x => new { x.DirectionsId, x.YearRecruitmentsId });
                    table.ForeignKey(
                        name: "FK_ProfileYearRecruitment_Profiles_DirectionsId",
                        column: x => x.DirectionsId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileYearRecruitment_YearRecruitments_YearRecruitmentsId",
                        column: x => x.YearRecruitmentsId,
                        principalTable: "YearRecruitments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormEducation = table.Column<int>(type: "integer", nullable: false),
                    PeriodEducation = table.Column<int>(type: "integer", nullable: false),
                    LanguageEducation = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateChange = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DirectionId",
                table: "Profiles",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DivisionId",
                table: "Profiles",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileYearRecruitment_YearRecruitmentsId",
                table: "ProfileYearRecruitment",
                column: "YearRecruitmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProfileId",
                table: "Specifications",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileYearRecruitment");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Directions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Directions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DivisionId",
                table: "Directions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "FormEducation",
                table: "Directions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageEducation",
                table: "Directions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodEducation",
                table: "Directions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DirectionYearRecruitment",
                columns: table => new
                {
                    DirectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    YearRecruitmentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectionYearRecruitment", x => new { x.DirectionsId, x.YearRecruitmentsId });
                    table.ForeignKey(
                        name: "FK_DirectionYearRecruitment_Directions_DirectionsId",
                        column: x => x.DirectionsId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectionYearRecruitment_YearRecruitments_YearRecruitmentsId",
                        column: x => x.YearRecruitmentsId,
                        principalTable: "YearRecruitments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directions_DivisionId",
                table: "Directions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectionYearRecruitment_YearRecruitmentsId",
                table: "DirectionYearRecruitment",
                column: "YearRecruitmentsId");

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
