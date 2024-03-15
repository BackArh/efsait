using EfSait.Infrastructure.Providers;
using EfSait.Service.Services;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EfSait.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IGeneralDirectionService, GeneralDirectionService>();
        service.AddScoped<IDirectionService, DirectionService>();
        service.AddScoped<IDisciplineService, DisciplineService>();
        service.AddScoped<IDivisionService, DivisionService>();
        service.AddScoped<IEmployeeService, EmployeeService>();
        service.AddScoped<IPageService, PageService>();
        service.AddScoped<IProfileService, ProfileService>();
        service.AddScoped<IStaffService, StaffService>();
        service.AddScoped<IUserService, UserService>();
        
        service.AddScoped<IYearRecruitmentsDisciplineService, YearRecruitmentsDisciplineService>();
        return service;
    }
}