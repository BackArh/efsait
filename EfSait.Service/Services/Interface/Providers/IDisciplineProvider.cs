using EfSait.Entity.EducationDirection;

namespace EfSait.Service.Services.Interface.Providers;

public interface IDisciplineProvider
{
    Task<Guid> AddAsync(Discipline entity, CancellationToken cancellationToken);
    Task<Discipline?> FindAsync(string name, CancellationToken cancellationToken);
    Task<Discipline?> FindAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAsync(string name, CancellationToken cancellationToken);
    Task<Discipline> UpdateAsync(Discipline entity, CancellationToken cancellationToken);
    Task<List<Discipline>> GetAllAsync(CancellationToken cancellationToken);
}