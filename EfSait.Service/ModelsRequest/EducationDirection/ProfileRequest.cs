
namespace EfSait.Service.ModelsRequest.EducationDirection;

public class ProfileRequest: BaseModelRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    
    public string Description { get; set; }
    public Guid DirectionId { get; set; }
    public List<SpecificationsRequest> SpecificationsList { get; set; }
    public List<YearRecruitmentRequest> YearRecruitments { get; set; }
}