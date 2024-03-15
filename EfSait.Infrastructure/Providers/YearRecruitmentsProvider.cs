using EfSait.Entity.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class YearRecruitmentsProvider : IYearRecruitmentsProvider
{
    private readonly ApplicationContext _applicationContext;

    public YearRecruitmentsProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<YearRecruitment?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.YearRecruitments
            .Include(y=>y.Profiles)
            .Include(y=>y.YearRecruitment_Disciplines)
            .Include(y=>y.NumberSeatsList)
            .FirstOrDefaultAsync(y => y.Id == id,cancellationToken).ConfigureAwait(false);
    }
}