using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;

public class YearRecruitmentDisciplineController : BaseController<YearRecruitment_Discipline,YearRecruitment_DisciplineRequest, IYearRecruitmentsDisciplineService>
{
    public YearRecruitmentDisciplineController(IYearRecruitmentsDisciplineService service) : base(service)
    {
    }

    [HttpPost("Attach")]
    public async Task<IActionResult> Attach(Guid idStaff, Guid idYearRecruitmentsDiscipline)
    {
        await _service.AttachAsync(idStaff, idYearRecruitmentsDiscipline,
            new CancellationToken());
        return Ok();
    }
}