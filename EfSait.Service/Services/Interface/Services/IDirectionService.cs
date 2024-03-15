using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;

namespace EfSait.Service.Services.Interface.Services;

public interface IDirectionService : IBaseService<Direction, DirectionRequest>
{
    Task<List<Direction>> GetByGeneralDirectionAsync(Guid id, CancellationToken cancellationToken);
}