using EfSait.Entity.EducationDirection;

namespace EfSait.Service.Services.Interface.Providers;

public interface IProfileProvider
{
    Task<Guid> AddAsync(Profile entity, CancellationToken cancellationToken);
    Task<Profile?> FindAsync(string code, CancellationToken cancellationToken);
    Task<Profile?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(string name, CancellationToken cancellationToken);
    Task<Profile> UpdateAsync(Profile entity, CancellationToken cancellationToken);
    Task<List<Profile>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Profile?> GetByDirectionAsync(Guid id, CancellationToken cancellationToken);
}