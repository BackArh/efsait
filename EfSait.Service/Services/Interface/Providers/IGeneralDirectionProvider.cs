using EfSait.Entity.EducationDirection;

namespace EfSait.Service.Services.Interface.Providers;

public interface IGeneralDirectionProvider
{
    Task<Guid> AddAsync(GeneralDirection entity, CancellationToken cancellationToken);
    Task<GeneralDirection?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<GeneralDirection?> FindAsync(string name, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<GeneralDirection> UpdateAsync(GeneralDirection entity, CancellationToken cancellationToken);
    Task<List<GeneralDirection>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<GeneralDirection>> GetByDivisionAsync(Guid id, CancellationToken cancellationToken);
}