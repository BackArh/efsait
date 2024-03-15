using EfSait.Entity;
using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class DirectionController : BaseController<Direction, DirectionRequest, IDirectionService>
{
    public DirectionController(IDirectionService service) : base(service)
    {
    }
    [HttpGet("GetByGeneralDirection")]
    public async Task<List<Direction>> GetByGeneralDirection(Guid id) 
    {
        ArgumentNullException.ThrowIfNull(id);
        var entity = await _service.GetByGeneralDirectionAsync(id, new CancellationToken());
        return entity;
    }
}