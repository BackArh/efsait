using EfSait.Entity.EducationDirection;
using EfSait.Entity.EmploeeDivision;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class YearRecruitmentsDisciplineProvider : IYearRecruitmentsDisciplineProvider
{
    private readonly ApplicationContext _applicationContext;

    public YearRecruitmentsDisciplineProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<YearRecruitment_Discipline?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.YearRecruitmentDisciplines
            .Include(ya=> ya.Discipline)
            .Include(ya=> ya.YearRecruitment)
            .Include(ya=> ya.Staves)
            .FirstOrDefaultAsync(y => y.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    public async Task<Guid> AddAsync(YearRecruitment_Discipline yearRecruitmentDiscipline,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(await _applicationContext.Disciplines.AsNoTracking().FirstOrDefaultAsync(
            d => d.Id == yearRecruitmentDiscipline.Discipline.Id,
            cancellationToken) != null);
        ArgumentNullException.ThrowIfNull(await _applicationContext.YearRecruitments.AsNoTracking().FirstOrDefaultAsync(
            y => y.Id == yearRecruitmentDiscipline.YearRecruitment.Id,
            cancellationToken) != null);
        _applicationContext.Entry(yearRecruitmentDiscipline.Discipline).State = EntityState.Unchanged;
        _applicationContext.Entry(yearRecruitmentDiscipline.YearRecruitment).State = EntityState.Unchanged;

        _applicationContext.Add(yearRecruitmentDiscipline);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return yearRecruitmentDiscipline.Id;
    }
    public async Task<List<YearRecruitment_Discipline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.YearRecruitmentDisciplines
            .Include(ya=> ya.Discipline)
            .Include(ya=> ya.YearRecruitment)
            .Include(ya=> ya.Staves)
            .Select(y => y).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var yearRecruitmentDiscipline = await _applicationContext.YearRecruitmentDisciplines
            .FirstOrDefaultAsync(y => y.Id == id, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        ArgumentNullException.ThrowIfNull(yearRecruitmentDiscipline);
        _applicationContext.Remove(yearRecruitmentDiscipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<YearRecruitment_Discipline> UpdateAsync(YearRecruitment_Discipline yearRecruitmentDiscipline,
        CancellationToken cancellationToken)
    {
        _applicationContext.Update(yearRecruitmentDiscipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return yearRecruitmentDiscipline;
    }

    public async Task AttachAsync(Guid yearRecruitmentDisciplineGuid, Guid staffGuid,
        CancellationToken cancellationToken)
    {
        var yearRecruitmentDiscipline = await 
            _applicationContext.YearRecruitmentDisciplines
                .FirstOrDefaultAsync(y => y.Id == yearRecruitmentDisciplineGuid,
                cancellationToken);
        
        var staff = await _applicationContext.Staves
            .Include(s => s.YearRecruitmentDisciplines)
            .FirstOrDefaultAsync(s => s.Id == staffGuid, cancellationToken);
        ArgumentNullException.ThrowIfNull(yearRecruitmentDiscipline);
        ArgumentNullException.ThrowIfNull(staff);
        yearRecruitmentDiscipline.Staves.Add(staff);
        staff.YearRecruitmentDisciplines.Add(yearRecruitmentDiscipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
}