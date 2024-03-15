using EfSait.Entity.EducationDirection;
using EfSait.Entity.UserActivity;

namespace EfSait.Service.Services.Interface.Providers;

public interface IYearRecruitmentsProvider
{
    Task<YearRecruitment?> FindAsync(Guid id, CancellationToken cancellationToken);
}