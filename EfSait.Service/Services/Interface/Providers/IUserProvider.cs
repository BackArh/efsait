using EfSait.Entity.UserActivity;

namespace EfSait.Service.Services.Interface.Providers;

public interface IUserProvider
{
    Task<Guid> AddAsync(User entity, CancellationToken cancellationToken);
    Task<User?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<User?> FindAsync(string surname, string name, string patronymic, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User entity, CancellationToken cancellationToken);
    
}