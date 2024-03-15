using EfSait.Entity.EmploeeDivision;
using EfSait.Service.ModelsRequest.EmploeeDivision;

namespace EfSait.Service.Services.Interface.Services;

public interface IStaffService: IBaseService<Staff, StaffRequest>
{
    Task AttachAsync(Guid idStaff, Guid idYearRecruitmentDiscipline, CancellationToken cancellationToken);
}