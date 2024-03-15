using EfSait.Entity.EducationDirection;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class DisciplineProvider: IDisciplineProvider
{
    private readonly ApplicationContext _applicationContext;

    public DisciplineProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Discipline?> FindAsync(string name, CancellationToken cancellationToken)
    {
        return await _applicationContext.Disciplines
            .Include(d=> d.YearRecruitment_Disciplines)
            .ThenInclude(y=> y.YearRecruitment)
            .Include(d=> d.YearRecruitment_Disciplines)
            .ThenInclude(y=> y.Staves)
            .ThenInclude(s => s.Employee)
            .FirstOrDefaultAsync(d => d.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
    public async Task<Discipline?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Disciplines
            .Include(d=> d.YearRecruitment_Disciplines)
            .ThenInclude(y=> y.YearRecruitment)
            .Include(d=> d.YearRecruitment_Disciplines)
            .ThenInclude(y=> y.Staves)
            .ThenInclude(s => s.Employee)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
    public async Task<List<Discipline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Disciplines.ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<Guid> AddAsync(Discipline discipline, CancellationToken cancellationToken)
    {
        _applicationContext.Add(discipline);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return discipline.Id;
    }

    public async Task DeleteAsync(string name, CancellationToken cancellationToken)
    {
        var discipline = await FindAsync(name, cancellationToken);
        ArgumentNullException.ThrowIfNull(discipline);
        _applicationContext.Remove(discipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<Discipline> UpdateAsync(Discipline discipline, CancellationToken cancellationToken)
    {
        _applicationContext.Update(discipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return discipline;
    }
}