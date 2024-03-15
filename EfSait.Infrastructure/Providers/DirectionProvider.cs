using EfSait.Entity.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class DirectionProvider : IDirectionProvider
{
    private readonly ApplicationContext _applicationContext;

    public DirectionProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Direction?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.Directions
            .Include(d => d.GeneralDirection)
            .Include(d => d.Profiles)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }
    public async Task<Direction?> FindAsync(string name, CancellationToken cancellationToken)
    {
        var direction = await _applicationContext.Directions
            .Include(d => d.GeneralDirection)
            .Include(d => d.Profiles)
            .FirstOrDefaultAsync(d => d.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
        return direction;
    }

    public async Task<List<Direction>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Directions
            .Include(d => d.GeneralDirection)
            .Include(d => d.Profiles)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Direction>> GetByGeneralDirectionAsync(Guid id, CancellationToken cancellationToken)
    {
        var directions = await _applicationContext.Directions
            .Include(d => d.GeneralDirection)
            .Include(d => d.Profiles)
            .ThenInclude(p=> p.SpecificationsList)
            .Where(d=>d.GeneralDirection.Id == id).ToListAsync(cancellationToken).ConfigureAwait(false);
        return directions;
    }

    public async Task<Guid> AddAsync(Direction direction, CancellationToken cancellationToken)
    {
        //_applicationContext.Entry(direction.Direction).State = EntityState.Unchanged;
        _applicationContext.Add(direction);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return direction.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(direction);
        _applicationContext.Remove(direction);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Direction> UpdateAsync(Direction direction, CancellationToken cancellationToken)
    {
        _applicationContext.Update(direction);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return direction;
    }
}