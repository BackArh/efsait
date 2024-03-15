using EfSait.Entity;
using EfSait.Entity.EducationDirection;

namespace EfSait.Service.ModelsRequest.EducationDirection;

public class GeneralDirectionRequest: BaseModelRequest
{
    public string Name { get; set; }
    public string? PathImage { get; set; }
    public Guid DivisionId { get; set; }
}