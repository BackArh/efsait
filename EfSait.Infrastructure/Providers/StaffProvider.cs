using EfSait.Entity.EmploeeDivision;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class StaffProvider : IStaffProvider
{
    private readonly ApplicationContext _applicationContext;

    public StaffProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Staff?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Staves
            .Include(s => s.YearRecruitmentDisciplines)
            .Include(s => s.Division)
            .Include(s => s.Employee)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
    public async Task<List<Staff>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Staves
            .Include(s => s.YearRecruitmentDisciplines)
            .Include(s => s.Division)
            .Include(s => s.Employee)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Guid> AddAsync(Staff staff, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(await _applicationContext.Divisions.AsNoTracking().FirstOrDefaultAsync(
            d => d.Id == staff.Division.Id,
            cancellationToken));
        ArgumentNullException.ThrowIfNull(await _applicationContext.Employees.AsNoTracking().FirstOrDefaultAsync(
            e => e.Id == staff.Employee.Id,
            cancellationToken));
        
        _applicationContext.Entry(staff.Division).State = EntityState.Unchanged;
        _applicationContext.Entry(staff.Employee).State = EntityState.Unchanged;

        _applicationContext.Add(staff);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return staff.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var staff = await _applicationContext.Staves.FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
        ArgumentNullException.ThrowIfNull(staff);
        _applicationContext.Remove(staff);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Staff> UpdateAsync(Staff staff, CancellationToken cancellationToken)
    {
        _applicationContext.Update(staff);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return staff;
    }

    public async Task AttachAsync(Guid idStaff, Guid idYear, CancellationToken cancellationToken)
    {
        var yearRecruitmentDiscipline = await 
            _applicationContext.YearRecruitmentDisciplines
                .FirstOrDefaultAsync(y => y.Id == idYear,
                    cancellationToken);
        
        var staff = await _applicationContext.Staves
            .Include(s => s.YearRecruitmentDisciplines)
            .FirstOrDefaultAsync(s => s.Id == idStaff, cancellationToken);
        ArgumentNullException.ThrowIfNull(yearRecruitmentDiscipline);
        ArgumentNullException.ThrowIfNull(staff);
        yearRecruitmentDiscipline.Staves.Add(staff);
        staff.YearRecruitmentDisciplines.Add(yearRecruitmentDiscipline);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    
    }
}