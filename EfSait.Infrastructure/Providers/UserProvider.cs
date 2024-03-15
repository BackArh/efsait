using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    private readonly ApplicationContext _applicationContext;

    public UserProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<User?> FindAsync(Guid id,
        CancellationToken cancellationToken)
    {
        return await _applicationContext.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken).ConfigureAwait(false);
    }public async Task<User?> FindAsync(string surname, string name, string patronymic,
        CancellationToken cancellationToken)
    {
        return await _applicationContext.Users
            .FirstOrDefaultAsync(u => u.Name == name &&
                                      u.Surname == surname &&
                                      u.Patronymic == patronymic,
                cancellationToken).ConfigureAwait(false);
    }

    public async Task<Guid> AddAsync(User user, CancellationToken cancellationToken)
    {
        _applicationContext.Add(user);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return user.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(user);
        _applicationContext.Remove(user);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _applicationContext.Update(user);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return user;
    }
}