using EfSait.Entity;
using EfSait.Entity.EducationDirection;

namespace EfSait.Service.ModelsRequest.EducationDirection;

public class DirectionRequest: BaseModelRequest
{
    public string Name { get; set; }
    public string? PathImage { get; set; }
    public Guid GeneralDirectionId { get; set; }
}