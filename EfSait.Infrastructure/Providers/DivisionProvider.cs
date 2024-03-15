using EfSait.Entity.EmploeeDivision;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;
public class DivisionProvider : IDivisionProvider
{
    private readonly ApplicationContext _applicationContext;

    public DivisionProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Division?> FindAsync(int code, CancellationToken cancellationToken)
    {
        return await _applicationContext.Divisions
            .Include(d =>d.Profiles)
            .Include(d => d.Staves)
            .Include(d => d.Boss)
            .FirstOrDefaultAsync(d => d.Code == code, cancellationToken).ConfigureAwait(false);
    }
    public async Task<Division?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Divisions
            .Include(d =>d.Profiles)
            .Include(d => d.Staves)
            .Include(d => d.Boss)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken).ConfigureAwait(false);
    }
    public async Task<List<Division>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Divisions
            .Include(d =>d.Profiles)
            .Include(d => d.Staves)
            .Include(d => d.Boss)
            .ToListAsync(cancellationToken: cancellationToken);
    }
    public async Task<Guid> AddAsync(Division entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task DeleteAsync(int code, CancellationToken cancellationToken)
    {
        var division = await FindAsync(code, cancellationToken);
        ArgumentNullException.ThrowIfNull(division);
        _applicationContext.Remove(division);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<Division> UpdateAsync(Division division, CancellationToken cancellationToken)
    {
        _applicationContext.Update(division);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return division;
    }

    
}