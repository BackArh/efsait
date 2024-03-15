using EfSait.Entity;
using EfSait.Service.ModelsRequest;

namespace EfSait.Service.Services.Interface.Services;

public interface IBaseService<TEntityDb, TEntityRequest>
    where TEntityDb: IBaseModel
    where TEntityRequest: BaseModelRequest
{
    Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken);
}