using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ovveraidConcept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffYearRecruitment_Discipline_YearRecruitment_Discipline_~",
                table: "StaffYearRecruitment_Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_YearRecruitment_Discipline_Discipline_DisciplineId",
                table: "YearRecruitment_Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_YearRecruitment_Discipline_YearRecruitments_YearRecruitment~",
                table: "YearRecruitment_Discipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearRecruitment_Discipline",
                table: "YearRecruitment_Discipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline");

            migrationBuilder.RenameTable(
                name: "YearRecruitment_Discipline",
                newName: "YearRecruitmentDisciplines");

            migrationBuilder.RenameTable(
                name: "Discipline",
                newName: "Disciplines");

            migrationBuilder.RenameIndex(
                name: "IX_YearRecruitment_Discipline_YearRecruitmentId",
                table: "YearRecruitmentDisciplines",
                newName: "IX_YearRecruitmentDisciplines_YearRecruitmentId");

            migrationBuilder.RenameIndex(
                name: "IX_YearRecruitment_Discipline_DisciplineId",
                table: "YearRecruitmentDisciplines",
                newName: "IX_YearRecruitmentDisciplines_DisciplineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearRecruitmentDisciplines",
                table: "YearRecruitmentDisciplines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffYearRecruitment_Discipline_YearRecruitmentDisciplines_~",
                table: "StaffYearRecruitment_Discipline",
                column: "YearRecruitmentDisciplinesId",
                principalTable: "YearRecruitmentDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearRecruitmentDisciplines_Disciplines_DisciplineId",
                table: "YearRecruitmentDisciplines",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearRecruitmentDisciplines_YearRecruitments_YearRecruitment~",
                table: "YearRecruitmentDisciplines",
                column: "YearRecruitmentId",
                principalTable: "YearRecruitments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffYearRecruitment_Discipline_YearRecruitmentDisciplines_~",
                table: "StaffYearRecruitment_Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_YearRecruitmentDisciplines_Disciplines_DisciplineId",
                table: "YearRecruitmentDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_YearRecruitmentDisciplines_YearRecruitments_YearRecruitment~",
                table: "YearRecruitmentDisciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearRecruitmentDisciplines",
                table: "YearRecruitmentDisciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.RenameTable(
                name: "YearRecruitmentDisciplines",
                newName: "YearRecruitment_Discipline");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "Discipline");

            migrationBuilder.RenameIndex(
                name: "IX_YearRecruitmentDisciplines_YearRecruitmentId",
                table: "YearRecruitment_Discipline",
                newName: "IX_YearRecruitment_Discipline_YearRecruitmentId");

            migrationBuilder.RenameIndex(
                name: "IX_YearRecruitmentDisciplines_DisciplineId",
                table: "YearRecruitment_Discipline",
                newName: "IX_YearRecruitment_Discipline_DisciplineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearRecruitment_Discipline",
                table: "YearRecruitment_Discipline",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffYearRecruitment_Discipline_YearRecruitment_Discipline_~",
                table: "StaffYearRecruitment_Discipline",
                column: "YearRecruitmentDisciplinesId",
                principalTable: "YearRecruitment_Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearRecruitment_Discipline_Discipline_DisciplineId",
                table: "YearRecruitment_Discipline",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearRecruitment_Discipline_YearRecruitments_YearRecruitment~",
                table: "YearRecruitment_Discipline",
                column: "YearRecruitmentId",
                principalTable: "YearRecruitments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
