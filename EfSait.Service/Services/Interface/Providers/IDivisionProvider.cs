using EfSait.Entity.EmploeeDivision;

namespace EfSait.Service.Services.Interface.Providers;

public interface IDivisionProvider
{
    Task<Guid> AddAsync(Division entity, CancellationToken cancellationToken);
    Task<Division?> FindAsync(int code, CancellationToken cancellationToken);
    Task<Division?> FindAsync(Guid id, CancellationToken cancellationToken);

    
    Task DeleteAsync(int code, CancellationToken cancellationToken);
    Task<Division> UpdateAsync(Division entity, CancellationToken cancellationToken);
    Task<List<Division>> GetAllAsync(CancellationToken cancellationToken);
}