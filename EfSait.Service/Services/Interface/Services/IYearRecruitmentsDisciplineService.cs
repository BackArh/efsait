using EfSait.Entity.EducationDirection;
using EfSait.Service.ModelsRequest.EducationDirection;

namespace EfSait.Service.Services.Interface.Services;

public interface IYearRecruitmentsDisciplineService: IBaseService<YearRecruitment_Discipline, YearRecruitment_DisciplineRequest>
{
    Task AttachAsync(Guid idStaff, Guid idYearRecruitmentsDiscipline, CancellationToken cancellationToken);
}