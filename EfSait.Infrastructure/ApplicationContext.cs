using EfSait.Entity.EducationDirection;
using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure;

public class ApplicationContext:DbContext
{
    public DbSet<Division> Divisions { get; private set; }
    public DbSet<GeneralDirection> GeneralDirections { get; private set; }
    public DbSet<Direction> Directions { get; private set; }
    public DbSet<Employee> Employees { get; private set; }
    public DbSet<Profile> Profiles { get; private set; }
    public DbSet<YearRecruitment> YearRecruitments { get; private set; }
    public DbSet<Staff> Staves { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Page> Pages { get; private set; }
    public DbSet<Discipline> Disciplines { get; private set; }
    public DbSet<YearRecruitment_Discipline> YearRecruitmentDisciplines { get; private set; }
    public ApplicationContext()
    {
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;" +
                                 "Port=5432;" +
                                 "Database=test;" +
                                 "Username=postgres;" +
                                 "Password=1");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>()
            .HasIndex(p => p.Code)
            .IsUnique(true);
        modelBuilder.Entity<Division>()
            .HasIndex(d => d.Code)
            .IsUnique(true);
        modelBuilder.Entity<Discipline>()
            .HasIndex(d => d.Name)
            .IsUnique(true);
    }
}