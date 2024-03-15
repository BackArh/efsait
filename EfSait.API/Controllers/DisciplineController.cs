using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;

public class DisciplineController: BaseController<Discipline,DisciplineRequest, IDisciplineService>
{
    public DisciplineController(IDisciplineService service) : base(service)
    {
    }
}

