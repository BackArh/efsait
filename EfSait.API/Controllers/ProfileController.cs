using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class ProfileController : BaseController<Profile,ProfileRequest, IProfileService>
{
    public ProfileController(IProfileService service) : base(service)
    {
    }
    
    [HttpGet("GetByDirection")]
    public async Task<Profile?> GetByDirection(Guid id) 
    {
        ArgumentNullException.ThrowIfNull(id);
        var entity = await _service.GetByDirectionAsync(id, new CancellationToken());
        return entity;
    }
}