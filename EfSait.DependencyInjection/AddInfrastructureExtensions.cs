using EfSait.Infrastructure;
using EfSait.Infrastructure.Providers;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace EfSait.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<ApplicationContext>();
        service.AddScoped<IGeneralDirectionProvider, GeneralDirectionProvider>();
        service.AddScoped<IDirectionProvider, DirectionProvider>();
        service.AddScoped<IYearRecruitmentsProvider, YearRecruitmentsProvider>();
        service.AddScoped<IDisciplineProvider, DisciplineProvider>();
        service.AddScoped<IDivisionProvider, DivisionProvider>();
        service.AddScoped<IEmployeeProvider, EmployeeProvider>();
        service.AddScoped<IPageProvider, PageProvider>();
        service.AddScoped<IProfileProvider, ProfileProvider>();
        service.AddScoped<IStaffProvider, StaffProvider>();
        service.AddScoped<IUserProvider, UserProvider>();
        service.AddScoped<IYearRecruitmentsDisciplineProvider, YearRecruitmentsDisciplineProvider>();

        return service;
    }
}