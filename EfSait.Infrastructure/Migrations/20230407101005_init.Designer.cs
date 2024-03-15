﻿// <auto-generated />
using System;
using System.Collections.Generic;
using EfSait.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfSait.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230407101005_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DirectionYearRecruitment", b =>
                {
                    b.Property<Guid>("DirectionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("YearRecruitmentsId")
                        .HasColumnType("uuid");

                    b.HasKey("DirectionsId", "YearRecruitmentsId");

                    b.HasIndex("YearRecruitmentsId");

                    b.ToTable("DirectionYearRecruitment");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.Direction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<int>("FormEducation")
                        .HasColumnType("integer");

                    b.Property<int>("LanguageEducation")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PeriodEducation")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.NumberSeats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BudgetPlaces")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaidPlaces")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("YearRecruitmentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("YearRecruitmentId");

                    b.ToTable("NumberSeats");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.YearRecruitment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("YearRecruitments");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.YearRecruitment_Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("YearRecruitmentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("YearRecruitmentId");

                    b.ToTable("YearRecruitment_Discipline");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Achievements", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Articles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("CoAuthors")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("LinkOnLibrary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberPrintedSheets")
                        .HasColumnType("integer");

                    b.Property<bool>("PrintedOrElectronic")
                        .HasColumnType("boolean");

                    b.Property<bool>("ScientificOrEducationMethodical")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Division", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BossId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Post")
                        .HasColumnType("integer");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Staves");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PageId")
                        .HasColumnType("uuid");

                    b.Property<string>("PathToFile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeFile")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateChange")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StaffYearRecruitment_Discipline", b =>
                {
                    b.Property<Guid>("StavesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("YearRecruitmentDisciplinesId")
                        .HasColumnType("uuid");

                    b.HasKey("StavesId", "YearRecruitmentDisciplinesId");

                    b.HasIndex("YearRecruitmentDisciplinesId");

                    b.ToTable("StaffYearRecruitment_Discipline");
                });

            modelBuilder.Entity("DirectionYearRecruitment", b =>
                {
                    b.HasOne("EfSait.Entity.EducationDirection.Direction", null)
                        .WithMany()
                        .HasForeignKey("DirectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSait.Entity.EducationDirection.YearRecruitment", null)
                        .WithMany()
                        .HasForeignKey("YearRecruitmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.Direction", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Division", "Division")
                        .WithMany("Directions")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.NumberSeats", b =>
                {
                    b.HasOne("EfSait.Entity.EducationDirection.YearRecruitment", "YearRecruitment")
                        .WithMany("NumberSeatsList")
                        .HasForeignKey("YearRecruitmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YearRecruitment");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.YearRecruitment_Discipline", b =>
                {
                    b.HasOne("EfSait.Entity.EducationDirection.Discipline", "Discipline")
                        .WithMany("YearRecruitment_Disciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSait.Entity.EducationDirection.YearRecruitment", "YearRecruitment")
                        .WithMany("YearRecruitment_Disciplines")
                        .HasForeignKey("YearRecruitmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("YearRecruitment");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Achievements", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Employee", "Employee")
                        .WithMany("Achievements")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Articles", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Employee", "Employee")
                        .WithMany("Articles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Division", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Employee", "Boss")
                        .WithMany()
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Staff", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Division", "Division")
                        .WithMany("Staves")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSait.Entity.EmploeeDivision.Employee", "Employee")
                        .WithMany("Staves")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Comment", b =>
                {
                    b.HasOne("EfSait.Entity.UserActivity.Page", "Page")
                        .WithMany("Comments")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSait.Entity.UserActivity.Comment", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("EfSait.Entity.UserActivity.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Material", b =>
                {
                    b.HasOne("EfSait.Entity.UserActivity.Page", "Page")
                        .WithMany("Materials")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.User", b =>
                {
                    b.HasOne("EfSait.Entity.UserActivity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StaffYearRecruitment_Discipline", b =>
                {
                    b.HasOne("EfSait.Entity.EmploeeDivision.Staff", null)
                        .WithMany()
                        .HasForeignKey("StavesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfSait.Entity.EducationDirection.YearRecruitment_Discipline", null)
                        .WithMany()
                        .HasForeignKey("YearRecruitmentDisciplinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.Discipline", b =>
                {
                    b.Navigation("YearRecruitment_Disciplines");
                });

            modelBuilder.Entity("EfSait.Entity.EducationDirection.YearRecruitment", b =>
                {
                    b.Navigation("NumberSeatsList");

                    b.Navigation("YearRecruitment_Disciplines");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Division", b =>
                {
                    b.Navigation("Directions");

                    b.Navigation("Staves");
                });

            modelBuilder.Entity("EfSait.Entity.EmploeeDivision.Employee", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Articles");

                    b.Navigation("Staves");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.Page", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("EfSait.Entity.UserActivity.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}