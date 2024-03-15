using EfSait.Entity;
using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class GeneralDirectionController : BaseController<GeneralDirection,GeneralDirectionRequest, IGeneralDirectionService>
{
    public GeneralDirectionController(IGeneralDirectionService service) : base(service)
    {
    }
    [HttpGet("GetByDivision")]
    public async Task<List<GeneralDirection>> GetByDivision(Guid id) 
    {
        ArgumentNullException.ThrowIfNull(id);
        var entity = await _service.GetByDivisionAsync(id, new CancellationToken());
        return entity;
    }
}