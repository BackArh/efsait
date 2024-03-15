using EfSait.Entity.UserActivity;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.UserActivity;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class PageService : IPageService
{
    private IPageProvider _pageProvider;

    public PageService(IPageProvider pageProvider)
    {
        _pageProvider = pageProvider;
    }

    public async Task<Guid> CreateAsync(PageRequest entityRequest, CancellationToken cancellationToken)
    {
        //todo реализовать работу с картинкой, сохранение и запись пути
        if (await _pageProvider.FindAsync(entityRequest.Id, cancellationToken) != null)
            throw new ExistIsEntityException("Такая страница существует");
        var pageDb = new Page(entityRequest.Text, entityRequest.Header, entityRequest.PathImage);
        await _pageProvider.AddAsync(pageDb, cancellationToken);
        return pageDb.Id;
    }

    public async Task<Page> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var page = await _pageProvider.FindAsync(id, cancellationToken);
        if (page == null)
            throw new NotExistException("Такого сотрудника не существует");
        return page;
    }

    public async Task<List<Page>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _pageProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<Page> UpdateAsync(PageRequest entityRequest, CancellationToken cancellationToken)
    {
        var pageDb = await GetAsync(entityRequest.Id, cancellationToken);
        pageDb.Header = entityRequest.Header;
        pageDb.Text = entityRequest.Text;
        pageDb.PathImage = entityRequest.PathImage;
        pageDb.UpdateChange = DateTime.Now;
        await _pageProvider.UpdateAsync(pageDb, cancellationToken);
        return pageDb;
    }
}