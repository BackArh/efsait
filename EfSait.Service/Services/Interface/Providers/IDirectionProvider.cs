using EfSait.Entity.EducationDirection;

namespace EfSait.Service.Services.Interface.Providers;

public interface IDirectionProvider
{
    Task<Guid> AddAsync(Direction direction, CancellationToken cancellationToken);
    Task<Direction?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<Direction?> FindAsync(string name, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Direction> UpdateAsync(Direction direction, CancellationToken cancellationToken);
    Task<List<Direction>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Direction>> GetByGeneralDirectionAsync(Guid id, CancellationToken cancellationToken);
}