using EfSait.Entity.EducationDirection;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class DirectionService: IDirectionService
{
    private readonly IGeneralDirectionProvider _generalDirectionProvider;
    private readonly IDirectionProvider _directionProvider;


    public DirectionService(IGeneralDirectionProvider generalDirectionProvider, IDirectionProvider directionProvider)
    {
        _generalDirectionProvider = generalDirectionProvider;
        _directionProvider = directionProvider;
    }

    public async Task<Guid> CreateAsync(DirectionRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _directionProvider.FindAsync(entityRequest.Name, cancellationToken).ConfigureAwait(false) != null)
            throw new ExistIsEntityException("Такое направление существует");
        
        if (entityRequest.GeneralDirectionId == null)
            throw new MissingDivisionException("Не указано вышестоящее направление");
        var generalDirection = await _generalDirectionProvider.FindAsync(entityRequest.GeneralDirectionId, cancellationToken);
        if (generalDirection == null)
            throw new MissingDivisionException("Такого вышестоящего направления не существует");
        var directionDb = new Direction(entityRequest.Name, generalDirection, entityRequest.PathImage);
        await _directionProvider.AddAsync(directionDb, cancellationToken);
        return directionDb.Id;
    }
    public async Task<Direction> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await _directionProvider.FindAsync(id, cancellationToken);
        if (direction == null)
            throw new NotExistException("Такого направления не существует");
        return direction;
    }
    public async Task<List<Direction>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _directionProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<List<Direction>> GetByGeneralDirectionAsync(Guid id, CancellationToken cancellationToken)
    {
        var directions = await _directionProvider.GetByGeneralDirectionAsync(id, cancellationToken);
        return directions;
    }

    public async Task<Direction> UpdateAsync(DirectionRequest entityRequest, CancellationToken cancellationToken)
    {
        var directionDb = await GetAsync(entityRequest.Id, cancellationToken);
        directionDb.Name = entityRequest.Name;
        directionDb.PathImage = entityRequest.PathImage;
        directionDb.UpdateChange = DateTime.Now;
        await _directionProvider.UpdateAsync(directionDb, cancellationToken);
        return directionDb;
    }
}