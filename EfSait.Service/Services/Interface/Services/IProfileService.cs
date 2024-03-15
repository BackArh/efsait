using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Providers;

namespace EfSait.Service.Services.Interface.Services;

public interface IProfileService: IBaseService<Profile, ProfileRequest>
{
    Task<Profile> GetAsync(string code, CancellationToken cancellationToken);
    Task<Profile?> GetByDirectionAsync(Guid id, CancellationToken cancellationToken);
    
}