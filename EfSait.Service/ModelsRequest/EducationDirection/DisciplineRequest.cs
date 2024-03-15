using EfSait.Entity;
using EfSait.Entity.EducationDirection;

namespace EfSait.Service.ModelsRequest.EducationDirection;

public class DisciplineRequest: BaseModelRequest
{
    public string Name { get; set; }
}