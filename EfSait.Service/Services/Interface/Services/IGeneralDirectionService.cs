using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;

namespace EfSait.Service.Services.Interface.Services;

public interface IGeneralDirectionService : IBaseService<GeneralDirection, GeneralDirectionRequest>
{
    Task<List<GeneralDirection>> GetByDivisionAsync(Guid id, CancellationToken cancellationToken);
}