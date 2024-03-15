using EfSait.Entity;
using EfSait.Entity.Enum;

namespace EfSait.Service.ModelsRequest.EducationDirection;

public class SpecificationsRequest: BaseModelRequest
{
    public string FormEducation { get; set; }
    public string LevelEducation { get; set; }
    public double Price { get; set; }
    public int PeriodEducation { get; set; }
    public string LanguageEducation { get; set; }
    
}