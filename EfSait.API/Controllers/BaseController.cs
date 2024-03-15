using EfSait.Entity;
using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;

public abstract class BaseController<TypeEntityBd, TypeRequest, TypeService> : ApiBaseController
    where TypeRequest : BaseModelRequest
    where TypeEntityBd : IBaseModel
    where TypeService : IBaseService<TypeEntityBd, TypeRequest>
{
    protected readonly TypeService _service;

    public BaseController(TypeService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(TypeRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        var id = await _service.CreateAsync(request, new CancellationToken());
        return Ok(id);
    }

    [HttpGet("GetAll")]
    public async Task<List<TypeEntityBd>> GetAll()
    {
        var list = await _service.GetAllAsync(new CancellationToken());
        return list;
    }

    [HttpGet("GetById")]
    public async Task<TypeEntityBd> GetById(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        var entity = await _service.GetAsync(id, new CancellationToken());
        return entity;
    }

    [HttpPost("Update")]
    public async Task<TypeEntityBd> Update(TypeRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return await _service.UpdateAsync(request, new CancellationToken());
    }
}