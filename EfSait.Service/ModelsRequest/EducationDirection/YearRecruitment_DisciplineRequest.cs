
namespace EfSait.Service.ModelsRequest.EducationDirection;

public class YearRecruitment_DisciplineRequest: BaseModelRequest 
{
    public Guid YearRecruitmentId { get; set; }
    public Guid DisciplineId { get; set; }
}