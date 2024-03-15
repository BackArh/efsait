using EfSait.Entity.EducationDirection;
using EfSait.Service.CustomException;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;
using EfSait.Service.Services.Interface.Services;

namespace EfSait.Service.Services;

public class GeneralDirectionService: IGeneralDirectionService
{
    private readonly IGeneralDirectionProvider _generalDirectionProvider;
    private readonly IDivisionProvider _divisionProvider;


    public GeneralDirectionService(IGeneralDirectionProvider generalDirectionProvider, IDivisionProvider divisionProvider)
    {
        _generalDirectionProvider = generalDirectionProvider;
        _divisionProvider = divisionProvider;
    }

    public async Task<Guid> CreateAsync(GeneralDirectionRequest direction, CancellationToken cancellationToken)
    {
        if (await _generalDirectionProvider.FindAsync(direction.Name, cancellationToken).ConfigureAwait(false) != null)
            throw new ExistIsEntityException("Такое направление существует");
        
        if (direction.DivisionId == null)
            throw new MissingDivisionException("Не указанно подраздедение");
        var division = await _divisionProvider.FindAsync(direction.DivisionId, cancellationToken);
        if (division == null)
            throw new MissingDivisionException("Такого подразделения не существует");
        var directionDb = new GeneralDirection(direction.Name, division, direction.PathImage);
        await _generalDirectionProvider.AddAsync(directionDb, cancellationToken);
        return direction.Id;
    }
    public async Task<GeneralDirection> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var direction = await _generalDirectionProvider.FindAsync(id, cancellationToken);
        if (direction == null)
            throw new NotExistException("Такого направления не существует");
        return direction;
    }
    public async Task<List<GeneralDirection>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _generalDirectionProvider.GetAllAsync(new CancellationToken());
    }

    public async Task<List<GeneralDirection>> GetByDivisionAsync(Guid id, CancellationToken cancellationToken)
    {
        var directions = await _generalDirectionProvider.GetByDivisionAsync(id, cancellationToken);
        return directions;
    }

    public async Task<GeneralDirection> UpdateAsync(GeneralDirectionRequest direction, CancellationToken cancellationToken)
    {
        var directionDb = await GetAsync(direction.Id, cancellationToken);
        directionDb.Name = direction.Name;
        directionDb.PathImage = direction.PathImage;
        directionDb.UpdateChange = DateTime.Now;
        await _generalDirectionProvider.UpdateAsync(directionDb, cancellationToken);
        return directionDb;
    }
}