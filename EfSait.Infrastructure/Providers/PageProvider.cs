using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using EfSait.Service.Services.Interface;
using EfSait.Service.Services.Interface.Providers;
using Microsoft.EntityFrameworkCore;

namespace EfSait.Infrastructure.Providers;

public class PageProvider: IPageProvider
{
    private readonly ApplicationContext _applicationContext;

    public PageProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Page?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Pages
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
    public async Task<Guid> AddAsync(Page page, CancellationToken cancellationToken)
    {
        _applicationContext.Add(page);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return page.Id;
    }
    public async Task<List<Page>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Pages.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var page = await _applicationContext.Pages.FirstOrDefaultAsync(p => p.Id == id,cancellationToken).ConfigureAwait(false);
        ArgumentNullException.ThrowIfNull(page);
        _applicationContext.Remove(page);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<Page> UpdateAsync(Page page, CancellationToken cancellationToken)
    {
        _applicationContext.Update(page);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return page;
    }
}