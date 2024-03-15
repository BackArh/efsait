using EfSait.Entity;
using EfSait.Entity.EducationDirection;

namespace EfSait.Service.ModelsRequest.EducationDirection;

public class YearRecruitmentRequest: BaseModelRequest 
{
    public List<NumberSeatsRequest> NumberSeatsList { get; set; }
    public DateOnly Year { get; set; }
}