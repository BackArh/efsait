using EfSait.Entity.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class GeneralDirectionProvider : IGeneralDirectionProvider
{
    private readonly ApplicationContext _applicationContext;

    public GeneralDirectionProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<GeneralDirection?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.GeneralDirections
            .Include(d => d.Directions)
            .Include(d => d.Division)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }
    public async Task<GeneralDirection?> FindAsync(string name, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.GeneralDirections
            .Include(d => d.Directions)
            .Include(d => d.Division)
            .FirstOrDefaultAsync(d => d.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }
    public async Task<List<GeneralDirection>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.GeneralDirections
            .Include(d => d.Directions)
            .Include(d => d.Division)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GeneralDirection>> GetByDivisionAsync(Guid id, CancellationToken cancellationToken)
    {
        var directions = await _applicationContext.GeneralDirections
            .Include(d => d.Directions)
            .Include(d=> d.Division)
            .Where(d=>d.Division.Id == id).ToListAsync(cancellationToken).ConfigureAwait(false);
        return directions;
    }

    public async Task<Guid> AddAsync(GeneralDirection generalDirection, CancellationToken cancellationToken)
    {
        //_applicationContext.Entry(direction.Direction).State = EntityState.Unchanged;
        _applicationContext.Add(generalDirection);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return generalDirection.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(direction);
        _applicationContext.Remove(direction);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<GeneralDirection> UpdateAsync(GeneralDirection generalDirection, CancellationToken cancellationToken)
    {
        _applicationContext.Update(generalDirection);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return generalDirection;
    }
}